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
            this.DeleteBox = new System.Windows.Forms.ComboBox();
            this.OptionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).BeginInit();
            this.OptionGroup.SuspendLayout();
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
            this.Doc.Size = new System.Drawing.Size(317, 191);
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
            this.TitleBox.Size = new System.Drawing.Size(195, 26);
            this.TitleBox.TabIndex = 2;
            this.TitleBox.TabStop = false;
            // 
            // FontSize
            // 
            this.FontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FontSize.BackColor = System.Drawing.Color.Black;
            this.FontSize.ForeColor = System.Drawing.Color.White;
            this.FontSize.Location = new System.Drawing.Point(276, -1);
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
            this.LoadBox.Location = new System.Drawing.Point(18, 21);
            this.LoadBox.Name = "LoadBox";
            this.LoadBox.Size = new System.Drawing.Size(166, 27);
            this.LoadBox.TabIndex = 5;
            this.LoadBox.TabStop = false;
            this.LoadBox.Text = "Load";
            this.LoadBox.SelectedIndexChanged += new System.EventHandler(this.LoadBox_SelectedIndexChanged);
            // 
            // OptionGroup
            // 
            this.OptionGroup.Controls.Add(this.DeleteBox);
            this.OptionGroup.Controls.Add(this.LoadBox);
            this.OptionGroup.Location = new System.Drawing.Point(59, 69);
            this.OptionGroup.Name = "OptionGroup";
            this.OptionGroup.Size = new System.Drawing.Size(200, 95);
            this.OptionGroup.TabIndex = 6;
            this.OptionGroup.TabStop = false;
            this.OptionGroup.Text = "OptionGroup";
            this.OptionGroup.Visible = false;
            // 
            // DeleteBox
            // 
            this.DeleteBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteBox.BackColor = System.Drawing.Color.Black;
            this.DeleteBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DeleteBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBox.ForeColor = System.Drawing.Color.White;
            this.DeleteBox.FormattingEnabled = true;
            this.DeleteBox.Location = new System.Drawing.Point(18, 54);
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
            this.OptionButton.Location = new System.Drawing.Point(194, -1);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(82, 26);
            this.OptionButton.TabIndex = 7;
            this.OptionButton.TabStop = false;
            this.OptionButton.Text = "Options";
            this.OptionButton.UseVisualStyleBackColor = false;
            this.OptionButton.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(317, 214);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.OptionGroup);
            this.Controls.Add(this.FontSize);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.Doc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Main";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FontSize)).EndInit();
            this.OptionGroup.ResumeLayout(false);
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
    }
}

