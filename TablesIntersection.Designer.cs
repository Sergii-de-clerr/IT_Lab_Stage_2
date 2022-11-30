
namespace IT_Lab_Stage_2
{
    partial class TablesIntersection
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
            this.firstTableComboBox = new System.Windows.Forms.ComboBox();
            this.secondTableComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // firstTableComboBox
            // 
            this.firstTableComboBox.FormattingEnabled = true;
            this.firstTableComboBox.Location = new System.Drawing.Point(12, 12);
            this.firstTableComboBox.Name = "firstTableComboBox";
            this.firstTableComboBox.Size = new System.Drawing.Size(345, 21);
            this.firstTableComboBox.TabIndex = 0;
            // 
            // secondTableComboBox
            // 
            this.secondTableComboBox.FormattingEnabled = true;
            this.secondTableComboBox.Location = new System.Drawing.Point(374, 12);
            this.secondTableComboBox.Name = "secondTableComboBox";
            this.secondTableComboBox.Size = new System.Drawing.Size(345, 21);
            this.secondTableComboBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SearchIntersection);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 371);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(707, 317);
            this.dataGridView1.TabIndex = 4;
            // 
            // TablesIntersection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 424);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.secondTableComboBox);
            this.Controls.Add(this.firstTableComboBox);
            this.Name = "TablesIntersection";
            this.Text = "TablesIntersection";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox firstTableComboBox;
        private System.Windows.Forms.ComboBox secondTableComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}