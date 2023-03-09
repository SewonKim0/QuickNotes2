using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickNotes2
{
    public partial class Main : Form
    {
        private const string Saves = "..\\..\\Saves";
        private System.Threading.Timer timer;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormClosing += Closing;
            TitleBox.KeyPress += GoDown;
            Doc.LinkClicked += ToLink;

            //data(posX posY sizeX sizeY fontSize)

            string[] data = File.ReadAllText("..\\..\\Data.txt").Split(' ');

            if (data.Length == 5)
            {
                this.Location = new Point(int.Parse(data[0]), int.Parse(data[1]));
                this.Size = new Size(int.Parse(data[2]), int.Parse(data[3]));

                FontSize.Value = int.Parse(data[4]);
                Doc.Font = new Font("Arial", int.Parse(data[4]), FontStyle.Bold);
            }

            //prepare load and delete options

            string[] files = Directory.GetFiles(Saves);
            foreach (string file in files)
            {
                LoadBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                DeleteBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
            }
        }

        private void ToLink(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void GoDown(object sender, KeyPressEventArgs e) { 
            if (e.KeyChar == (char) Keys.Enter)
            {
                Doc.Focus();
            }
        }

        private void Closing(object sender, EventArgs e)
        {
            //Save form data
            //data(posX posY sizeX sizeY fontSize)
            string formData = "";
            formData += this.Location.X + " ";
            formData += this.Location.Y + " ";
            formData += this.Size.Width + " ";
            formData += this.Size.Height + " ";
            formData += FontSize.Value;

            File.WriteAllText("..\\..\\Data.txt", formData);

            //Save

            if (!TitleBox.Text.Equals(""))
            {
                //save
                File.WriteAllText(Saves + "\\" + TitleBox.Text, Doc.Text);
            }
            else
            {
                if (Doc.Text.Equals(""))
                {
                    return;
                }

                //confirm, save untitled

                DialogResult result = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int saveNum = 0;
                    string savePath = Saves + "\\Untitled" + saveNum;

                    while (Directory.GetFiles(Saves).Contains(savePath))
                    {
                        saveNum++;
                        savePath = Saves + "\\Untitled" + saveNum;
                    }

                    File.WriteAllText(savePath, Doc.Text);
                }
            }
        }

        private void FontSize_ValueChanged(object sender, EventArgs e)
        {
            Doc.Font = new Font("Arial", (float)FontSize.Value, FontStyle.Bold);
        }

        private void Doc_TextChanged(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Dispose();
            }      
            timer = new System.Threading.Timer(new TimerCallback(Reload), null, 3000, 1000);
        }

        private void Reload(object state)
        {
            this.Invoke(new Action(() => { Doc.ReadOnly = true; }));

            int selectionStart = 0;
            int selectionLength = 0;

            this.Invoke(new Action(() => { selectionStart = Doc.SelectionStart; }));
            this.Invoke(new Action(() => { selectionLength = Doc.SelectionLength; }));

            string[] lines = null;
            this.Invoke(new Action(() => { lines = Doc.Text.Split('\n'); }));
            this.Invoke(new Action(() => { Doc.Text = ""; }));

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line.Length >= 2 && line[0] == '\t' && line[1] == '\t')
                {
                    this.Invoke(new Action(() => { Doc.SelectionColor = Color.FromArgb(80, 80, 80); }));                  
                }
                else if (line.Length >= 1 && line[0] =='\t')
                {
                    this.Invoke(new Action(() => { Doc.SelectionColor = Color.FromArgb(150, 150, 150); }));
                }
                else
                {
                    this.Invoke(new Action(() => { Doc.SelectionColor = Color.White; }));
                }

                if (i == lines.Length - 1)
                {
                    this.Invoke(new Action(() => { Doc.AppendText(line); }));
                }
                else
                {
                    this.Invoke(new Action(() => { Doc.AppendText(line + "\n"); }));
                }      
            }

            this.Invoke(new Action(() => { Doc.SelectionStart = selectionStart; }));     
            this.Invoke(new Action(() => { Doc.SelectionLength = selectionLength; }));
            this.Invoke(new Action(() => { Doc.ScrollToCaret(); }));

            timer.Dispose();
            this.Invoke(new Action(() => { Doc.ReadOnly = false; }));
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            if (OptionGroup.Visible == false)
            {
                OptionGroup.Visible = true;

                LoadBox.Text = "Load";
                DeleteBox.Text = "Delete";
            }
            else
            {
                OptionGroup.Visible = false;
            }
        }

        private void LoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validate input
            
            if (!Directory.GetFiles(Saves).Contains(Saves + "\\" + LoadBox.Text))
            {
                MessageBox.Show(Directory.GetFiles(Saves)[0]);
                MessageBox.Show(Saves + "\\" + LoadBox.Text);
                MessageBox.Show("Error: Invalid file name.");
                return;
            }

            //save currDoc
            
            if (!TitleBox.Text.Equals(""))
            {
                //save
                File.WriteAllText(Saves + "\\" + TitleBox.Text, Doc.Text);

                //update load/delete options

                if (!LoadBox.Items.Contains(TitleBox.Text))
                {
                    LoadBox.Items.Add(TitleBox.Text);
                    DeleteBox.Items.Add(TitleBox.Text);
                }
            }
            else if (!Doc.Text.Equals(""))
            {
                //confirm, save untitled

                DialogResult result = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int saveNum = 0;
                    string savePath = Saves + "\\Untitled" + saveNum;

                    while (Directory.GetFiles(Saves).Contains(savePath))
                    {
                        saveNum++;
                        savePath = Saves + "\\Untitled" + saveNum;
                    }

                    File.WriteAllText(savePath, Doc.Text);

                    //update load/delete options

                    if (!LoadBox.Items.Contains("Untitled" + saveNum))
                    {
                        LoadBox.Items.Add("Untitled" + saveNum);
                        DeleteBox.Items.Add("Untitled" + saveNum);
                    }
                }
            }

            OptionGroup.Visible = false;

            //load into doc

            TitleBox.Text = LoadBox.Text;
            Doc.Text = File.ReadAllText(Saves + "\\" + LoadBox.Text);
        }

        private void DeleteBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //confirm

            DialogResult confirm = MessageBox.Show("Do you want to delete (" + DeleteBox.Text + ")?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.No)
            {
                return;
            }

            //validate input

            if (!Directory.GetFiles(Saves).Contains(Saves + "\\" + DeleteBox.Text))
            {
                MessageBox.Show("Error: Invalid file name.");
                return;
            }

            //delete file

            File.Delete(Saves + "\\" + DeleteBox.Text);

            //delete file on doc

            if (TitleBox.Text.Equals(DeleteBox.Text))
            {
                TitleBox.Text = "";
                Doc.Text = "";
            }

            //delete load/delete entries

            if (LoadBox.Items.Contains(DeleteBox.Text))
            {
                LoadBox.Items.Remove(DeleteBox.Text);
                DeleteBox.Items.Remove(DeleteBox.Text);         
            }
        }
    }
}
