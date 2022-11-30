using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace IT_Lab_Stage_2
{
    public class Database
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public List<Table> Tables { get; set; } = new List<Table>();
        public Database(string name, string path)
        {
            Name = name;
            Path = path;
        }
        public Database() { }
        public Database(Database database)
        {
            Name = database.Name;
            Path = database.Path;
        }
    }

    public class Table
    {
        public Table() { }
        public string Name { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
        public List<Row> Rows { get; set; } = new List<Row>();
        public Table(string name)
        {
            Name = name;
        }
    }
    public class Column
    {
        public Column() { }
        public Column(string name, ColumnType type, List<string> availableValues = null)
        {
            Name = name;
            Type = type;
            AvailableValues = availableValues ?? new List<string>();
        }
        public string Name { get; set; }
        public List<string> AvailableValues { get; set; }
        public ColumnType Type { get; set; }
        private const string EmailRegex = @"^[\d\w\._\-\+]+@([\d\w\._\-]+\.)+[\w]+$";
        public bool IsValid(string value)
        {
            if (Type == ColumnType.Integer)
                return Int32.TryParse(value, out _);
            if (Type == ColumnType.Real)
                return Double.TryParse(value, out _);
            if (Type == ColumnType.Char)
                return Char.TryParse(value, out _);
            if (Type == ColumnType.String)
                return true;
            if (Type == ColumnType.String)
                return true;
            if (Type == ColumnType.Enum)
                return AvailableValues?.Contains(value) ?? false;
            if (Type == ColumnType.Email)
                return !string.IsNullOrEmpty(value) &&
                                    Regex.IsMatch(value, EmailRegex, RegexOptions.IgnoreCase);
            return true;
        }
    }

    public enum ColumnType
    {
        Integer,
        Real,
        Char,
        String,
        Enum,
        Email
    }

    public class Row
    {
        public Row() { }
        public List<string> Values { get; set; } = new List<string>();
    }

    public class DataBaseManager
    {
        private Database _database;
        public Database Database { get => _database; set => _database = value; }
        private static DataBaseManager _instance;

        private const char _tablesSeparator = '$';
        private const char _columnsSeparator = '%';

        public static DataBaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataBaseManager();
                }

                return _instance;
            }
        }
        private DataBaseManager() { }
        #region Database
        public bool OpenDatabase(string path)
        {
            try
            {
                var streamReader = new StreamReader(path);
                _database = new Database(streamReader.ReadLine(), path);
                string file = streamReader.ReadToEnd();
                ReadTables(file.Split(_tablesSeparator, (char)StringSplitOptions.RemoveEmptyEntries));
                streamReader.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool CreateDatabase(string name, string path)
        {
            _database = new Database(name, path);
            return true;
        }
        public bool SaveDatabase()
        {
            try
            {
                var file = new FileStream(_database.Path, FileMode.Create);
                var streamWriter = new StreamWriter(file);
                streamWriter.WriteLine(_database.Name);
                WriteTables(streamWriter);
                streamWriter.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteDataBase()
        {
            try
            {
                _database = null;

                if (!string.IsNullOrEmpty(_database.Path))
                {
                    File.Delete(_database.Path);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region Table

        public bool CreateTable(string tableName)
        {
            if (_database.Tables.Select(i => i.Name).Contains(tableName))
            {
                return false;
            }

            _database.Tables.Add(new Table(tableName));
            return true;
        }
        public void DeleteTable(Table table)
        {
            _database.Tables.Remove(table);
        }
        private void ReadTables(string[] tables)
        {
            foreach (var table in tables)
            {
                var tableData = table.Replace("\r\n", "\n").Split('\n', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                var newTable = new Table(tableData[0]);
                _database.Tables.Add(newTable);
                ReadColumns(tableData[1], newTable);
                tableData.RemoveAt(0);
                tableData.RemoveAt(0);
                ReadRows(tableData, newTable);

            }

        }
        private void WriteTables(StreamWriter streamWriter)
        {
            foreach (var table in _database.Tables)
            {
                streamWriter.WriteLine(table.Name);
                WriteColumns(streamWriter, table);
                WriteRows(streamWriter, table);
                streamWriter.WriteLine(_tablesSeparator);
            }

        }
        #endregion

        #region Columns
        public bool CreateColumn(Table table, string columnName, ColumnType columnType, List<string> availableTypes)
        {
            if (table.Columns.Select(i => i.Name).Contains(columnName))
            {
                return false;
            }

            table.Columns.Add(new Column(columnName, columnType, availableTypes));
            foreach (var row in table.Rows)
            {
                row.Values.Add("");
            }
            return true;
        }
        public void DeleteColumn(Table table, int column)
        {
            table.Columns.RemoveAt(column);

            foreach (var row in table.Rows)
            {
                row.Values.RemoveAt(column);
            }

            if (table.Columns.Count == 0)
            {
                table.Rows.Clear();
            }
        }
        private void ReadColumns(string data, Table table)
        {
            var columns = data.Split(_columnsSeparator, (char)StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var column in columns)
            {
                var columnData = column.Split('\t', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                Enum.TryParse(columnData[1], out ColumnType columnType);
                var availableValues = new List<string>();
                if (columnData.Count > 2)
                    availableValues = columnData[2]?.Split(',', (char)StringSplitOptions.RemoveEmptyEntries).ToList();
                table.Columns.Add(new Column(columnData[0], columnType, availableValues));
            }
        }
        private void WriteColumns(StreamWriter streamWriter, Table table)
        {
            foreach (var column in table.Columns)
            {
                streamWriter.Write(column.Name + '\t' + column.Type.ToString() + '\t' + string.Join(Convert.ToString(','), column.AvailableValues) + _columnsSeparator);

            }

        }
        #endregion

        #region Rows
        public void CreateRow(Table table)
        {
            var newRow = new Row();
            foreach (var column in table.Columns)
            {
                newRow.Values.Add("");
            }
            table.Rows.Add(newRow);

        }
        public void DeleteRow(Table table, int row)
        {
            table.Rows.RemoveAt(row);

        }
        private void ReadRows(List<string> rows, Table table)
        {

            foreach (var row in rows)
            {
                var rowData = row.Split('\t', (char)StringSplitOptions.RemoveEmptyEntries).ToList();

                table.Rows.Add(new Row() { Values = rowData });
            }
        }

        private void WriteRows(StreamWriter streamWriter, Table table)
        {
            foreach (var row in table.Rows)
            {
                streamWriter.WriteLine(string.Join(Convert.ToString('\t'), row.Values));

            }

        }
        #endregion

        public bool EditCell(Table table, int column, int row, string newValue)
        {
            if (table.Columns[column].IsValid(newValue))
            {
                table.Rows[row].Values[column] = newValue;

                return true;
            }

            return false;
        }

        public Table Intersection(Table firstTable, Table secondTable)
        {
            var sameColumns = new List<Column>();
            var result = new Table("intersection");
            foreach (var column in firstTable.Columns)
            {
                if (secondTable.Columns.FirstOrDefault(i => i.Name == column.Name && i.Type == column.Type) != null)
                {
                    result.Columns.Add(column);
                }
            }
            if (!result.Columns.Any())
                return null;

            var tempRows = new List<Row>();
            foreach (var row in secondTable.Rows)
            {
                var newRow = new Row();
                for (var i = 0; i < row.Values.Count; i++)
                {
                    if (result.Columns.FirstOrDefault(c => c.Name == secondTable.Columns[i].Name && c.Type == secondTable.Columns[i].Type) != null)
                    {
                        newRow.Values.Add(row.Values[i]);
                    }
                }
                tempRows.Add(newRow);
            }
            foreach (var row in firstTable.Rows)
            {
                var newRow = new Row();
                for (var i = 0; i < row.Values.Count; i++)
                {
                    if (result.Columns.Contains(firstTable.Columns[i]))
                    {
                        newRow.Values.Add(row.Values[i]);
                    }
                }
                if (tempRows.Any(r => r.Values.SequenceEqual(newRow.Values)))
                    result.Rows.Add(newRow);
            }
            return result;
        }
    }
}
