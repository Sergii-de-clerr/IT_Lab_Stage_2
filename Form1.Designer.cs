
namespace IT_Lab_Stage_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addColumnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDatabaseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteColumnMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intersectionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tablesDataGridView = new System.Windows.Forms.DataGridView();
            this.TablesTabs = new System.Windows.Forms.TabControl();
            this.openDatabaseDialog = new System.Windows.Forms.OpenFileDialog();
            this.createDatabaseDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataGridView)).BeginInit();
            this.TablesTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseMenuItem,
            this.addMenuItem,
            this.deleteMenuItem,
            this.intersectionMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseMenuItem
            // 
            this.databaseMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDatabaseMenuItem,
            this.createDatabaseMenuItem,
            this.saveDatabaseMenuItem});
            this.databaseMenuItem.Name = "databaseMenuItem";
            this.databaseMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseMenuItem.Text = "Database";
            // 
            // openDatabaseMenuItem
            // 
            this.openDatabaseMenuItem.Name = "openDatabaseMenuItem";
            this.openDatabaseMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openDatabaseMenuItem.Text = "Open";
            this.openDatabaseMenuItem.Click += new System.EventHandler(this.OpenDatabase);
            // 
            // createDatabaseMenuItem
            // 
            this.createDatabaseMenuItem.Name = "createDatabaseMenuItem";
            this.createDatabaseMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createDatabaseMenuItem.Text = "Create";
            this.createDatabaseMenuItem.Click += new System.EventHandler(this.CreateDatabase);
            // 
            // saveDatabaseMenuItem
            // 
            this.saveDatabaseMenuItem.Enabled = false;
            this.saveDatabaseMenuItem.Name = "saveDatabaseMenuItem";
            this.saveDatabaseMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveDatabaseMenuItem.Text = "Save";
            this.saveDatabaseMenuItem.Click += new System.EventHandler(this.SaveDatabase);
            // 
            // addMenuItem
            // 
            this.addMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addColumnMenuItem,
            this.addRowMenuItem});
            this.addMenuItem.Enabled = false;
            this.addMenuItem.Name = "addMenuItem";
            this.addMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addMenuItem.Text = "Add";
            // 
            // addColumnMenuItem
            // 
            this.addColumnMenuItem.Enabled = false;
            this.addColumnMenuItem.Name = "addColumnMenuItem";
            this.addColumnMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addColumnMenuItem.Text = "Column";
            this.addColumnMenuItem.Click += new System.EventHandler(this.CreateColumn);
            // 
            // addRowMenuItem
            // 
            this.addRowMenuItem.Enabled = false;
            this.addRowMenuItem.Name = "addRowMenuItem";
            this.addRowMenuItem.Size = new System.Drawing.Size(117, 22);
            this.addRowMenuItem.Text = "Row";
            this.addRowMenuItem.Click += new System.EventHandler(this.CreateRow);
            // 
            // deleteMenuItem
            // 
            this.deleteMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDatabaseMenuItem,
            this.deleteTableMenuItem,
            this.deleteColumnMenuItem,
            this.deleteRowMenuItem});
            this.deleteMenuItem.Enabled = false;
            this.deleteMenuItem.Name = "deleteMenuItem";
            this.deleteMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteMenuItem.Text = "Delete";
            // 
            // deleteDatabaseMenuItem
            // 
            this.deleteDatabaseMenuItem.Enabled = false;
            this.deleteDatabaseMenuItem.Name = "deleteDatabaseMenuItem";
            this.deleteDatabaseMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteDatabaseMenuItem.Text = "Database";
            this.deleteDatabaseMenuItem.Click += new System.EventHandler(this.DeleteDatabase);
            // 
            // deleteTableMenuItem
            // 
            this.deleteTableMenuItem.Enabled = false;
            this.deleteTableMenuItem.Name = "deleteTableMenuItem";
            this.deleteTableMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteTableMenuItem.Text = "Table";
            this.deleteTableMenuItem.Click += new System.EventHandler(this.DeleteTable);
            // 
            // deleteColumnMenuItem
            // 
            this.deleteColumnMenuItem.Enabled = false;
            this.deleteColumnMenuItem.Name = "deleteColumnMenuItem";
            this.deleteColumnMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteColumnMenuItem.Text = "Column";
            this.deleteColumnMenuItem.Click += new System.EventHandler(this.DeleteColumn);
            // 
            // deleteRowMenuItem
            // 
            this.deleteRowMenuItem.Enabled = false;
            this.deleteRowMenuItem.Name = "deleteRowMenuItem";
            this.deleteRowMenuItem.Size = new System.Drawing.Size(122, 22);
            this.deleteRowMenuItem.Text = "Row";
            this.deleteRowMenuItem.Click += new System.EventHandler(this.DeleteRow);
            // 
            // intersectionMenuItem
            // 
            this.intersectionMenuItem.Enabled = false;
            this.intersectionMenuItem.Name = "intersectionMenuItem";
            this.intersectionMenuItem.Size = new System.Drawing.Size(81, 20);
            this.intersectionMenuItem.Text = "Intersection";
            this.intersectionMenuItem.Click += new System.EventHandler(this.Intersection);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 0);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "+";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tablesDataGridView
            // 
            this.tablesDataGridView.AllowUserToAddRows = false;
            this.tablesDataGridView.AllowUserToDeleteRows = false;
            this.tablesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablesDataGridView.Location = new System.Drawing.Point(12, 54);
            this.tablesDataGridView.Name = "tablesDataGridView";
            this.tablesDataGridView.Size = new System.Drawing.Size(776, 384);
            this.tablesDataGridView.TabIndex = 0;
            this.tablesDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.BeginEditCell);
            this.tablesDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.EndEditCell);
            // 
            // TablesTabs
            // 
            this.TablesTabs.Controls.Add(this.tabPage1);
            this.TablesTabs.Location = new System.Drawing.Point(12, 32);
            this.TablesTabs.Name = "TablesTabs";
            this.TablesTabs.SelectedIndex = 0;
            this.TablesTabs.Size = new System.Drawing.Size(776, 23);
            this.TablesTabs.TabIndex = 2;
            this.TablesTabs.Click += new System.EventHandler(this.TableChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tablesDataGridView);
            this.Controls.Add(this.TablesTabs);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablesDataGridView)).EndInit();
            this.TablesTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDatabaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDatabaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDatabaseMenuItem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView tablesDataGridView;
        private System.Windows.Forms.TabControl TablesTabs;
        private System.Windows.Forms.OpenFileDialog openDatabaseDialog;
        private System.Windows.Forms.SaveFileDialog createDatabaseDialog;
        private System.Windows.Forms.ToolStripMenuItem addMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addColumnMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDatabaseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteColumnMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intersectionMenuItem;
    }
}

