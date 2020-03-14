namespace AdminForm.Views
{
    partial class Newsletter
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newsletterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.felhasznaloDataSet2 = new AdminForm.felhasznaloDataSet2();
            this.newsletterTableAdapter = new AdminForm.felhasznaloDataSet2TableAdapters.newsletterTableAdapter();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.asdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdasdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialRaisedButtonSendLetter = new MaterialSkin.Controls.MaterialRaisedButton();
            this.materialSingleLineTextFieldSubject = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.richTextBoxBody = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsletterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.felhasznaloDataSet2)).BeginInit();
            this.materialContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.newsletterBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(92, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(684, 256);
            this.dataGridView1.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Azonosító";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email-cím";
            this.emailDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // newsletterBindingSource
            // 
            this.newsletterBindingSource.DataMember = "newsletter";
            this.newsletterBindingSource.DataSource = this.felhasznaloDataSet2;
            // 
            // felhasznaloDataSet2
            // 
            this.felhasznaloDataSet2.DataSetName = "felhasznaloDataSet2";
            this.felhasznaloDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // newsletterTableAdapter
            // 
            this.newsletterTableAdapter.ClearBeforeFill = true;
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(92, 364);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(684, 223);
            this.materialDivider1.TabIndex = 1;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asdToolStripMenuItem,
            this.asdasdToolStripMenuItem});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(125, 52);
            // 
            // asdToolStripMenuItem
            // 
            this.asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            this.asdToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.asdToolStripMenuItem.Text = "asd";
            // 
            // asdasdToolStripMenuItem
            // 
            this.asdasdToolStripMenuItem.Name = "asdasdToolStripMenuItem";
            this.asdasdToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.asdasdToolStripMenuItem.Text = "asdasd";
            // 
            // materialRaisedButtonSendLetter
            // 
            this.materialRaisedButtonSendLetter.Depth = 0;
            this.materialRaisedButtonSendLetter.Location = new System.Drawing.Point(354, 537);
            this.materialRaisedButtonSendLetter.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButtonSendLetter.Name = "materialRaisedButtonSendLetter";
            this.materialRaisedButtonSendLetter.Primary = true;
            this.materialRaisedButtonSendLetter.Size = new System.Drawing.Size(128, 40);
            this.materialRaisedButtonSendLetter.TabIndex = 3;
            this.materialRaisedButtonSendLetter.Text = "Küldés";
            this.materialRaisedButtonSendLetter.UseVisualStyleBackColor = true;
            this.materialRaisedButtonSendLetter.Click += new System.EventHandler(this.materialRaisedButtonSendLetter_Click);
            // 
            // materialSingleLineTextFieldSubject
            // 
            this.materialSingleLineTextFieldSubject.BackColor = System.Drawing.Color.Black;
            this.materialSingleLineTextFieldSubject.Depth = 0;
            this.materialSingleLineTextFieldSubject.Hint = "";
            this.materialSingleLineTextFieldSubject.Location = new System.Drawing.Point(118, 386);
            this.materialSingleLineTextFieldSubject.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextFieldSubject.Name = "materialSingleLineTextFieldSubject";
            this.materialSingleLineTextFieldSubject.PasswordChar = '\0';
            this.materialSingleLineTextFieldSubject.SelectedText = "";
            this.materialSingleLineTextFieldSubject.SelectionLength = 0;
            this.materialSingleLineTextFieldSubject.SelectionStart = 0;
            this.materialSingleLineTextFieldSubject.Size = new System.Drawing.Size(262, 28);
            this.materialSingleLineTextFieldSubject.TabIndex = 4;
            this.materialSingleLineTextFieldSubject.Text = "Tárgy";
            this.materialSingleLineTextFieldSubject.UseSystemPasswordChar = false;
            // 
            // richTextBoxBody
            // 
            this.richTextBoxBody.Location = new System.Drawing.Point(118, 435);
            this.richTextBoxBody.Name = "richTextBoxBody";
            this.richTextBoxBody.Size = new System.Drawing.Size(624, 96);
            this.richTextBoxBody.TabIndex = 5;
            this.richTextBoxBody.Text = "";
            // 
            // Newsletter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 618);
            this.Controls.Add(this.richTextBoxBody);
            this.Controls.Add(this.materialSingleLineTextFieldSubject);
            this.Controls.Add(this.materialRaisedButtonSendLetter);
            this.Controls.Add(this.materialDivider1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Newsletter";
            this.Text = "Newsletter";
            this.Load += new System.EventHandler(this.Newsletter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newsletterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.felhasznaloDataSet2)).EndInit();
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private felhasznaloDataSet2 felhasznaloDataSet2;
        private System.Windows.Forms.BindingSource newsletterBindingSource;
        private felhasznaloDataSet2TableAdapters.newsletterTableAdapter newsletterTableAdapter;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem asdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdasdToolStripMenuItem;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButtonSendLetter;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextFieldSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.RichTextBox richTextBoxBody;
    }
}