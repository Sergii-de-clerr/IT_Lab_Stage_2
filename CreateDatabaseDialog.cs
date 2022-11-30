using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_Lab_Stage_2
{
    public partial class CreateDatabaseDialog : Form
    {
        public string DatabaseName { get; set; } = "";
        public string Path { get; set; } = "";
        public CreateDatabaseDialog(string databaseName, string path)
        {
            InitializeComponent();
            databasePathTextBox.Text = Path = path;
            databaseNameTextBox.Text = DatabaseName = databaseName;
        }
        private void SelectDatabasePath(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Stream stream;
                if ((stream = saveFileDialog.OpenFile()) != null)
                {
                    stream.Close();
                    Path = saveFileDialog.FileName;
                    databasePathTextBox.Text = Path;
                }
            }
        }
        private void Create_of_Database(object sender, EventArgs e)
        {
            DatabaseName = databaseNameTextBox.Text;
        }
    }
}
