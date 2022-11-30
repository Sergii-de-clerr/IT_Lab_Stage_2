using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_Lab_Stage_2
{
    public partial class Form1 : Form
    {
        private const string _titleError = "Error";
        private const string _titleWarning = "Warning";

        private const string _messageDeleteDatabase = "Are you sure you want to delete this database?";
        private const string _messageDeleteTable = "Are you sure you want to delete this table?";
        private const string _messageDeleteColumn = "Are you sure you want to delete this column?";
        private const string _messageDeleteRow = "Are you sure you want to delete this row?";

        private const string _errorSomethingWentWrong = "Something went wrong";
        private const string _errorEmptyDatabaseName = "Database name cannot be empty";
        private const string _errorEmptyColumnName = "Column name cannot be empty";
        private const string _errorAvailableValues = "Available values cannot be empty";
        private const string _errorWrongPath = "Path cannot be empty";
        private const string _errorInvalidName = "Invalid name";
        private const string _errorEmptyTableName = "Table name cannot be empty";
        private const string _errorTableNameAlreadyExists = "Table with this name already exists";
        private const string _errorColumnNameAlreadyExists = "Column with this name already exists";
        private const string _errorInvalidValue = "Invalid value";
        private readonly DataBaseManager _dataBaseManager = DataBaseManager.Instance;
        private string _cellOldValue;
        private Table CurrentTable => _dataBaseManager.Database?.Tables?.ElementAtOrDefault(TablesTabs.SelectedIndex);
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenDatabase(object sender, EventArgs e)
        {
            try
            {
                if (openDatabaseDialog.ShowDialog() == DialogResult.OK)
                {
                    _dataBaseManager.OpenDatabase(openDatabaseDialog.FileName);
                    InitTabs();
                    Text = "Database manger " + _dataBaseManager.Database.Name;

                    if (_dataBaseManager.Database.Tables.Any())
                        RenderTable(_dataBaseManager.Database.Tables[0]);
                    createDatabaseMenuItem.Enabled = false;
                    openDatabaseMenuItem.Enabled = false;
                    saveDatabaseMenuItem.Enabled = true;
                    deleteMenuItem.Enabled = true;
                    deleteDatabaseMenuItem.Enabled = true;
                    addMenuItem.Enabled = true;
                    if (_dataBaseManager.Database.Tables.Count > 1)
                        intersectionMenuItem.Enabled = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateDatabase(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                string databaseName = "", path = "";
                while (!success)
                {
                    var dialog = new CreateDatabaseDialog(databaseName, path);
                    var dialogResult = dialog.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                        return;

                    if (dialogResult == DialogResult.OK)
                    {
                        databaseName = dialog.DatabaseName;
                        path = dialog.Path;
                        if (databaseName.Equals(""))
                        {
                            MessageBox.Show(_errorEmptyDatabaseName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (path.Equals(""))
                        {
                            MessageBox.Show(_errorWrongPath, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!(success = _dataBaseManager.CreateDatabase(databaseName, path)))
                        {
                            MessageBox.Show(_errorInvalidName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                Text = "Database manger " + _dataBaseManager.Database.Name;
                InitTabs();
                ClearTable();
                createDatabaseMenuItem.Enabled = false;
                openDatabaseMenuItem.Enabled = false;
                saveDatabaseMenuItem.Enabled = true;
                deleteMenuItem.Enabled = true;
                deleteDatabaseMenuItem.Enabled = true;
                addMenuItem.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteDatabase(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show(_messageDeleteDatabase, _titleWarning,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    _dataBaseManager.DeleteDataBase();

                    createDatabaseMenuItem.Enabled = true;
                    openDatabaseMenuItem.Enabled = true;
                    saveDatabaseMenuItem.Enabled = false;
                    deleteMenuItem.Enabled = false;
                    addMenuItem.Enabled = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SaveDatabase(object sender, EventArgs e)
        {
            try
            {
                _dataBaseManager.SaveDatabase();
            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Intersection(object sender, EventArgs e)
        {

            var dialog = new TablesIntersection();
            var dialogResult = dialog.ShowDialog();

            if (dialogResult == DialogResult.Cancel)
                return;

        }
        private void CreateTable()
        {
            try
            {
                bool success = false;
                string tableName = "";
                while (!success)
                {
                    var dialog = new CreateTable(tableName);
                    var dialogResult = dialog.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                        return;

                    if (dialogResult == DialogResult.OK)
                    {
                        tableName = dialog.TableName;
                        if (tableName.Equals(""))
                        {
                            MessageBox.Show(_errorEmptyTableName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!(success = _dataBaseManager.CreateTable(tableName)))
                        {
                            MessageBox.Show(_errorTableNameAlreadyExists, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                InitTabs();
                RenderTable(CurrentTable);
                if (_dataBaseManager.Database.Tables.Count > 1)
                    intersectionMenuItem.Enabled = true;
                deleteTableMenuItem.Enabled = true;
                addColumnMenuItem.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteTable(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show(_messageDeleteTable, _titleWarning,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    _dataBaseManager.DeleteTable(CurrentTable);
                    TablesTabs.TabPages.RemoveAt(TablesTabs.SelectedIndex);
                    if (TablesTabs.TabPages.Count == 0)
                    {
                        deleteTableMenuItem.Enabled = false;
                        addColumnMenuItem.Enabled = false;
                        deleteColumnMenuItem.Enabled = false;
                        addRowMenuItem.Enabled = false;
                        deleteRowMenuItem.Enabled = false;
                    }

                    RenderTable(CurrentTable);
                    if (_dataBaseManager.Database.Tables.Count > 1)
                        intersectionMenuItem.Enabled = true;
                }

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RenderTable(Table table)
        {
            ClearTable();
            if (table == null)
                return;
            foreach (var column in table.Columns)
            {
                if (column.Type == ColumnType.Enum)
                {
                    tablesDataGridView.Columns.Add(new DataGridViewComboBoxColumn() { Name = column.Name, HeaderText = $"{column.Name} ({column.Type})" });
                }
                else
                    tablesDataGridView.Columns.Add(new DataGridViewTextBoxColumn() { Name = column.Name, HeaderText = $"{column.Name} ({column.Type})" });
            }
            foreach (var row in table.Rows)
            {
                var newRow = new DataGridViewRow();
                for (int i = 0; i < row.Values.Count; i++)
                {
                    if (table.Columns[i].Type == ColumnType.Enum)
                    {
                        var cell = new DataGridViewComboBoxCell();
                        foreach (var value in table.Columns[i].AvailableValues)
                        {
                            cell.Items.Add(value);
                        }
                        cell.Value = row.Values[i];
                        newRow.Cells.Add(cell);
                    }
                    else
                        newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = row.Values[i] });
                }
                tablesDataGridView.Rows.Add(newRow);
            }
        }
        private void ClearTable()
        {
            tablesDataGridView.Columns.Clear();
            tablesDataGridView.Rows.Clear();
        }

        private void InitTabs()
        {
            TablesTabs.TabPages.Clear();
            List<string> tableNames = _dataBaseManager.Database.Tables.Select(i => i.Name).ToList();
            foreach (string name in tableNames)
                TablesTabs.TabPages.Add(name);
            TablesTabs.TabPages.Add("+");
            TablesTabs.SelectedIndex = 0;

        }
        private void TableChanged(object sender, EventArgs e)
        {
            if (_dataBaseManager.Database != null && TablesTabs.SelectedIndex == (_dataBaseManager.Database?.Tables?.Count ?? 0))
            {
                CreateTable();
            }
            else if (TablesTabs.SelectedIndex != -1)
            {
                RenderTable(_dataBaseManager.Database.Tables[TablesTabs.SelectedIndex]);
                addColumnMenuItem.Enabled = true;
                addRowMenuItem.Enabled = tablesDataGridView.ColumnCount > 0;
                deleteColumnMenuItem.Enabled = deleteRowMenuItem.Enabled = tablesDataGridView.ColumnCount > 0 && tablesDataGridView.RowCount > 0;
            }
        }

        private void CreateColumn(object sender, EventArgs e)
        {
            try
            {
                bool success = false;
                string name = "";
                ColumnType columnType = ColumnType.Integer;
                List<string> availableValues = new List<string>();
                while (!success)
                {
                    var dialog = new CreateColumn(name, columnType, availableValues);
                    var dialogResult = dialog.ShowDialog();

                    if (dialogResult == DialogResult.Cancel)
                        return;

                    if (dialogResult == DialogResult.OK)
                    {
                        name = dialog.ColumnName;
                        columnType = dialog.ColumnType;
                        availableValues = dialog.AvailableValues;
                        if (name.Equals(""))
                        {
                            MessageBox.Show(_errorEmptyColumnName, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (columnType == ColumnType.Enum && !availableValues.Any())
                        {
                            MessageBox.Show(_errorAvailableValues, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (!(success = _dataBaseManager.CreateColumn(CurrentTable, name, columnType, availableValues)))
                        {
                            MessageBox.Show(_errorColumnNameAlreadyExists, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                RenderTable(CurrentTable);
                deleteColumnMenuItem.Enabled = true;
                addRowMenuItem.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteColumn(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show(_messageDeleteColumn, _titleWarning,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    _dataBaseManager.DeleteColumn(CurrentTable, tablesDataGridView.CurrentCell.ColumnIndex);
                    if (tablesDataGridView.ColumnCount == 0)
                    {
                        deleteColumnMenuItem.Enabled = false;
                        addRowMenuItem.Enabled = false;
                        deleteRowMenuItem.Enabled = false;
                    }
                    RenderTable(CurrentTable);
                }

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateRow(object sender, EventArgs e)
        {
            try
            {
                _dataBaseManager.CreateRow(CurrentTable);
                RenderTable(CurrentTable);
                deleteRowMenuItem.Enabled = true;

            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteRow(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show(_messageDeleteRow, _titleWarning,
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    _dataBaseManager.DeleteRow(CurrentTable, tablesDataGridView.CurrentCell.RowIndex);
                    if (tablesDataGridView.RowCount == 0)
                        deleteRowMenuItem.Enabled = false;
                    RenderTable(CurrentTable);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BeginEditCell(object sender, DataGridViewCellCancelEventArgs e)
        {
            _cellOldValue = tablesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
        }
        private void EndEditCell(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (!_dataBaseManager.EditCell(CurrentTable, e.ColumnIndex, e.RowIndex, tablesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString() ?? ""))
                {
                    dynamic column = CurrentTable.Columns[e.ColumnIndex];

                    tablesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _cellOldValue;
                    MessageBox.Show(_errorInvalidValue + column.type, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(_errorSomethingWentWrong, _titleError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
