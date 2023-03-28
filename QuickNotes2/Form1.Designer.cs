namespace QuickNotes2
{
    partial class Main
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
            this.Doc = new System.Windows.Forms.RichTextBox();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.FontSize = new System.Windows.Forms.NumericUpDown();
            this.LoadBox = new System.Windows.Forms.ComboBox();
            this.OptionGroup = new System.Windows.Forms.GroupBox();
            this.PathLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.FolderBox = new System.Windows.Forms.ComboBox();
            this.DeleteBox = new System.Windows.Forms.ComboBox();
            this.OptionButton = new System.Windows.Forms.Button();
            this.CreateGroup = new System.Windows.Forms.GroupBox();
            this.CreateLabel = new System.Windows.Forms.Label();
            this.CreateBox = new System.Windows.Forms.TextBox();
            this.RenameGroup = new System.Windows.Forms.GroupBox();
            this.RenameLabel = new System.Windows.Forms.Label();
            this.RenameBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).BeginInit();
            this.OptionGroup.SuspendLayout();
            this.CreateGroup.SuspendLayout();
            this.RenameGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Doc
            // 
            this.Doc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Doc.BackColor = System.Drawing.Color.Black;
            this.Doc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Doc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Doc.ForeColor = System.Drawing.Color.White;
            this.Doc.Location = new System.Drawing.Point(0, 24);
            this.Doc.Name = "Doc";
            this.Doc.Size = new System.Drawing.Size(607, 273);
            this.Doc.TabIndex = 0;
            this.Doc.TabStop = false;
            this.Doc.Text = "";
            this.Doc.TextChanged += new System.EventHandler(this.Doc_TextChanged);
            // 
            // TitleBox
            // 
            this.TitleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleBox.BackColor = System.Drawing.Color.Black;
            this.TitleBox.ForeColor = System.Drawing.Color.White;
            this.TitleBox.Location = new System.Drawing.Point(0, -1);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(485, 26);
            this.TitleBox.TabIndex = 2;
            this.TitleBox.TabStop = false;
            // 
            // FontSize
            // 
            this.FontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FontSize.BackColor = System.Drawing.Color.Black;
            this.FontSize.ForeColor = System.Drawing.Color.White;
            this.FontSize.Location = new System.Drawing.Point(566, -1);
            this.FontSize.Name = "FontSize";
            this.FontSize.Size = new System.Drawing.Size(41, 26);
            this.FontSize.TabIndex = 4;
            this.FontSize.TabStop = false;
            this.FontSize.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.FontSize.ValueChanged += new System.EventHandler(this.FontSize_ValueChanged);
            // 
            // LoadBox
            // 
            this.LoadBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadBox.BackColor = System.Drawing.Color.Black;
            this.LoadBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadBox.ForeColor = System.Drawing.Color.White;
            this.LoadBox.FormattingEnabled = true;
            this.LoadBox.Location = new System.Drawing.Point(17, 57);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new System.Drawing.Size(166, 27);
            this.LoadBox.TabIndex = 5;
            this.LoadBox.TabStop = false;
            this.LoadBox.Text = "Load";
            this.LoadBox.SelectedIndexChanged += new System.EventHandler(this.LoadBox_SelectedIndexChanged);
            // 
            // OptionGroup
            // 
            this.OptionGroup.Controls.Add(this.PathLabel);
            this.OptionGroup.Controls.Add(this.SaveButton);
            this.OptionGroup.Controls.Add(this.FolderBox);
            this.OptionGroup.Controls.Add(this.DeleteBox);
            this.OptionGroup.Controls.Add(this.LoadBox);
            this.OptionGroup.Location = new System.Drawing.Point(59, 32);
            this.OptionGroup.Name = "OptionGroup";
            this.OptionGroup.Size = new System.Drawing.Size(200, 190);
            this.OptionGroup.TabIndex = 6;
            this.OptionGroup.TabStop = false;
            this.OptionGroup.Text = "OptionGroup";
            this.OptionGroup.Visible = false;
            this.OptionGroup.Enter += new System.EventHandler(this.OptionGroup_Enter);
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.ForeColor = System.Drawing.Color.White;
            this.PathLabel.Location = new System.Drawing.Point(17, 158);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(88, 20);
            this.PathLabel.TabIndex = 12;
            this.PathLabel.Text = "Path: root";
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveButton.BackColor = System.Drawing.Color.Black;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(69, 23);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(61, 28);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.TabStop = false;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // FolderBox
            // 
            this.FolderBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderBox.BackColor = System.Drawing.Color.Black;
            this.FolderBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FolderBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FolderBox.ForeColor = System.Drawing.Color.White;
            this.FolderBox.FormattingEnabled = true;
            this.FolderBox.Location = new System.Drawing.Point(17, 123);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(166, 27);
            this.FolderBox.TabIndex = 7;
            this.FolderBox.TabStop = false;
            this.FolderBox.Text = "Folder";
            this.FolderBox.SelectedIndexChanged += new System.EventHandler(this.FolderBox_SelectedIndexChanged);
            // 
            // DeleteBox
            // 
            this.DeleteBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBox.BackColor = System.Drawing.Color.Black;
            this.DeleteBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBox.ForeColor = System.Drawing.Color.White;
            this.DeleteBox.FormattingEnabled = true;
            this.DeleteBox.Location = new System.Drawing.Point(17, 90);
            this.DeleteBox.Name = "DeleteBox";
            this.DeleteBox.Size = new System.Drawing.Size(166, 27);
            this.DeleteBox.TabIndex = 6;
            this.DeleteBox.TabStop = false;
            this.DeleteBox.Text = "Delete";
            this.DeleteBox.SelectedIndexChanged += new System.EventHandler(this.DeleteBox_SelectedIndexChanged);
            // 
            // OptionButton
            // 
            this.OptionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OptionButton.BackColor = System.Drawing.Color.Black;
            this.OptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OptionButton.ForeColor = System.Drawing.Color.White;
            this.OptionButton.Location = new System.Drawing.Point(484, -1);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(82, 26);
            this.OptionButton.TabIndex = 7;
            this.OptionButton.TabStop = false;
            this.OptionButton.Text = "Options";
            this.OptionButton.UseVisualStyleBackColor = false;
            this.OptionButton.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // CreateGroup
            // 
            this.CreateGroup.Controls.Add(this.CreateLabel);
            this.CreateGroup.Controls.Add(this.CreateBox);
            this.CreateGroup.Location = new System.Drawing.Point(285, 76);
            this.CreateGroup.Name = "CreateGroup";
            this.CreateGroup.Size = new System.Drawing.Size(200, 73);
            this.CreateGroup.TabIndex = 9;
            this.CreateGroup.TabStop = false;
            this.CreateGroup.Text = "CreateBox";
            this.CreateGroup.Visible = false;
            // 
            // CreateLabel
            // 
            this.CreateLabel.AutoSize = true;
            this.CreateLabel.ForeColor = System.Drawing.Color.White;
            this.CreateLabel.Location = new System.Drawing.Point(45, 18);
            this.CreateLabel.Name = "CreateLabel";
            this.CreateLabel.Size = new System.Drawing.Size(116, 20);
            this.CreateLabel.TabIndex = 11;
            this.CreateLabel.Text = "Folder Name:";
            // 
            // CreateBox
            // 
            this.CreateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateBox.BackColor = System.Drawing.Color.Black;
            this.CreateBox.ForeColor = System.Drawing.Color.White;
            this.CreateBox.Location = new System.Drawing.Point(6, 41);
            this.CreateBox.Name = "CreateBox";
            this.CreateBox.Size = new System.Drawing.Size(188, 26);
            this.CreateBox.TabIndex = 10;
            this.CreateBox.TabStop = false;
            // 
            // RenameGroup
            // 
            this.RenameGroup.Controls.Add(this.RenameLabel);
            this.RenameGroup.Controls.Add(this.RenameBox);
            this.RenameGroup.Location = new System.Drawing.Point(285, 155);
            this.RenameGroup.Name = "RenameGroup";
            this.RenameGroup.Size = new System.Drawing.Size(200, 73);
            this.RenameGroup.TabIndex = 12;
            this.RenameGroup.TabStop = false;
            this.RenameGroup.Visible = false;
            // 
            // RenameLabel
            // 
            this.RenameLabel.AutoSize = true;
            this.RenameLabel.ForeColor = System.Drawing.Color.White;
            this.RenameLabel.Location = new System.Drawing.Point(50, 18);
            this.RenameLabel.Name = "RenameLabel";
            this.RenameLabel.Size = new System.Drawing.Size(99, 20);
            this.RenameLabel.TabIndex = 11;
            this.RenameLabel.Text = "New Name:";
            // 
            // RenameBox
            // 
            this.RenameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RenameBox.BackColor = System.Drawing.Color.Black;
            this.RenameBox.ForeColor = System.Drawing.Color.White;
            this.RenameBox.Location = new System.Drawing.Point(6, 41);
            this.RenameBox.Name = "RenameBox";
            this.RenameBox.Size = new System.Drawing.Size(188, 26);
            this.RenameBox.TabIndex = 10;
            this.RenameBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(607, 296);
            this.Controls.Add(this.RenameGroup);
            this.Controls.Add(this.CreateGroup);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.OptionGroup);
            this.Controls.Add(this.FontSize);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.Doc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).EndInit();
            this.OptionGroup.ResumeLayout(false);
            this.OptionGroup.PerformLayout();
            this.CreateGroup.ResumeLayout(false);
            this.CreateGroup.PerformLayout();
            this.RenameGroup.ResumeLayout(false);
            this.RenameGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Doc;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.NumericUpDown FontSize;
        private System.Windows.Forms.ComboBox LoadBox;
        private System.Windows.Forms.GroupBox OptionGroup;
        private System.Windows.Forms.ComboBox DeleteBox;
        private System.Windows.Forms.Button OptionButton;
        private System.Windows.Forms.ComboBox FolderBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox CreateGroup;
        private System.Windows.Forms.Label CreateLabel;
        private System.Windows.Forms.TextBox CreateBox;
        private System.Windows.Forms.GroupBox RenameGroup;
        private System.Windows.Forms.Label RenameLabel;
        private System.Windows.Forms.TextBox RenameBox;
        private System.Windows.Forms.Label PathLabel;
    }
}

