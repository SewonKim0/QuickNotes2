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
using Microsoft.VisualBasic;

namespace QuickNotes2
{
    public partial class Main : Form
    {
        private const string saves = "..\\..\\Saves";
        private string currFolder = "";

        private Color color1 = Color.White;
        private Color color2 = Color.FromArgb(200, 200, 200);
        private Color color3 = Color.FromArgb(120, 120, 120);

        public Main()
        {
            InitializeComponent();
            //trash bin system for deleteds
            //path error: Colon in title
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormClosing += Closing;
            TitleBox.KeyPress += GoDown;
            Doc.LinkClicked += ToLink;

            //selectionChange: color change
            Doc.SelectionChanged += ColorChange;

            //data(posX posY sizeX sizeY fontSize)

            string[] data = File.ReadAllText("..\\..\\Data.txt").Split(' ');

            if (data.Length == 5)
            {
                this.Location = new Point(int.Parse(data[0]), int.Parse(data[1]));
                this.Size = new Size(int.Parse(data[2]), int.Parse(data[3]));

                FontSize.Value = int.Parse(data[4]);
                Doc.Font = new Font("Arial", int.Parse(data[4]), FontStyle.Bold);
            }

            //load and delete

            string[] files = Directory.GetFiles(saves);
            foreach (string file in files)
            {
                LoadBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                DeleteBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
            }

            //folder
            FolderBox.Items.Add("(Create New)");
            //folder subdirectories
            foreach (string dir in Directory.GetDirectories(saves))
            {
                FolderBox.Items.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
            }
        }

        private void ColorChange(object sender, EventArgs e)
        {
            string[] lines = Doc.Lines;
            int pos = Doc.SelectionStart;
            if (lines.Length == 0)
            {
                Doc.SelectionColor = color1;
                return;
            }

            int lineIndex = 0;
            int lineStart = 0;

            foreach (string line in lines)
            {
                if (lineStart + line.Length >= pos)
                {
                    break;
                }
                else
                {
                    lineStart += line.Length + 1;
                    lineIndex++;
                }
            }

            if (lines[lineIndex].Length >= 2 && lines[lineIndex][0] == '\t' && lines[lineIndex][1] == '\t')
            {
                Doc.SelectionColor = color3;
            }
            else if (lines[lineIndex].Length >= 1 && lines[lineIndex][0] == '\t')
            {
                Doc.SelectionColor = color2;
            }
            else
            {
                Doc.SelectionColor = color1;
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

        private void Closing(object sender, FormClosingEventArgs e)
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

            //if already exists as folder
            string[] subdirectories = Directory.GetDirectories(saves + currFolder);
            foreach (string subdirectory in subdirectories)
            {
                string subName = subdirectory.Substring(subdirectory.LastIndexOf('\\') + 1);
                if (subName.ToLower().Equals(TitleBox.Text.ToLower()))
                {
                    MessageBox.Show("Error: File name already exists as a folder");
                    e.Cancel = true;
                    return;
                }
            }

            //Save
            if (!TitleBox.Text.Equals(""))
            {
                //save
                File.WriteAllText(saves + currFolder + "\\" + TitleBox.Text, Doc.Text);
            }
        }

        private void FontSize_ValueChanged(object sender, EventArgs e)
        {
            Doc.Font = new Font("Arial", (float)FontSize.Value, FontStyle.Bold);

            //reload

            //load into doc
            string[] lines = Doc.Lines;
            Doc.Text = "";

            //color coding

            foreach (string line in lines)
            {
                if (line.Length >= 2 && line[0] == '\t' && line[1] == '\t')
                {
                    Doc.SelectionColor = color3;
                }
                else if (line.Length >= 1 && line[0] == '\t')
                {
                    Doc.SelectionColor = color2;
                }
                else
                {
                    Doc.SelectionColor = color1;
                }

                Doc.AppendText(line + "\n");
            }
        }

        private void Doc_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void OptionButton_Click(object sender, EventArgs e)
        {
            if (OptionGroup.Visible == false)
            {
                OptionGroup.Visible = true;

                LoadBox.Text = "Load";
                DeleteBox.Text = "Delete";
                FolderBox.Text = "Folder";
            }
            else
            {
                OptionGroup.Visible = false;
            }
        }

        private void LoadBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save
            if (!TitleBox.Text.Equals(""))
            {
                Save();
            }

            //validate input
            if (!Directory.GetFiles(saves + currFolder).Contains(saves + currFolder + "\\" + LoadBox.Text))
            {
                MessageBox.Show("Error: Invalid file name.");
                return;
            }

            OptionGroup.Visible = false;

            //load into doc
            Doc.Text = "";
            TitleBox.Text = LoadBox.Text;
            string[] lines = File.ReadAllText(saves + currFolder + "\\" + LoadBox.Text).Split('\n');

            //color coding
            foreach (string line in lines)
            {
                if (line.Length >= 2 && line[0] == '\t' && line[1] == '\t')
                {
                    Doc.SelectionColor = color3;
                }
                else if (line.Length >= 1 && line[0] == '\t')
                {
                    Doc.SelectionColor = color2;
                }
                else
                {
                    Doc.SelectionColor = color1;
                }

                Doc.AppendText(line + "\n");
            }
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

            if (!Directory.GetFiles(saves + currFolder).Contains(saves + currFolder + "\\" + DeleteBox.Text))
            {
                MessageBox.Show("Error: Invalid file name.");
                return;
            }

            //delete file

            File.Delete(saves + currFolder + "\\" + DeleteBox.Text);

            //delete file on doc

            if (TitleBox.Text.Equals(DeleteBox.Text))
            {
                TitleBox.Text = "";
                Doc.Text = "";
            }

            //update (load, delete)
            if (LoadBox.Items.Contains(DeleteBox.Text))
            {
                LoadBox.Items.Remove(DeleteBox.Text);
                DeleteBox.Items.Remove(DeleteBox.Text);         
            }
        }

        private string ShowDirectory(string curr = null, int depth = -1)
        {
            if (curr == null)
            {
                MessageBox.Show(ShowDirectory("", 0));
                return null;
            }
            else
            {
                string text = "";
                for (int x = 1; x <= depth - 1; x++)
                {
                    text += "   ";
                }
                if (depth >= 1)
                {
                    text += "-->";
                }

                if (curr == "")
                {
                    text += "root\n";
                    curr = saves;
                }
                else
                {
                    text += curr.Substring(curr.LastIndexOf('\\')) + "\n";
                }

                foreach (string dir in Directory.EnumerateDirectories(curr))
                {
                    text += ShowDirectory(dir, depth + 1);
                }
                foreach (string file in Directory.EnumerateFiles(curr))
                {
                    text += ShowDirectory(file, depth + 1);
                }
                return text;
            }
        }

        private void CreateFolder(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
            {
                return;
            }

            string folderName = CreateBox.Text;
            //prevent reserved names
            if (folderName[0] == '.' && folderName[1] =='.')
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Create New)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Rename Folder)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Delete Folder)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            //check folder-folder collision
            if (Directory.Exists(saves + currFolder + "\\" + folderName))
            {
                MessageBox.Show("Error: Folder already exists");
                return;
            }
            //check folder-file collision
            foreach (string file in Directory.GetFiles(saves + currFolder))
            {
                string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                if (fileName.ToLower().Equals(folderName.ToLower()))
                {
                    MessageBox.Show("Error: A file with the same name already exists");
                    return;
                }
            }

            //create folder
            Directory.CreateDirectory(saves + currFolder + "\\" + folderName);

            //upload folder
            FolderBox.Items.Add(folderName);

            //close
            CreateGroup.Visible = false;
            CreateBox.Text = "";
            CreateBox.KeyPress -= CreateFolder;
        }

        private void RenameFolder(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char) Keys.Enter)
            {
                return;
            }
            if (currFolder.Equals(""))
            {
                MessageBox.Show("Error: Cannot rename root directory");
                return;
            }
            
            string folderName = RenameBox.Text;
            //check for reserved values
            if (folderName[0] == '.' && folderName[1] == '.')
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Create New)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Rename Folder)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            else if (folderName.Equals("(Delete Folder)"))
            {
                MessageBox.Show("Error: Invalid name");
                return;
            }
            //check for folder-folder collision
            if (Directory.Exists(saves + currFolder.Substring(0, currFolder.LastIndexOf('\\') + 1) + folderName))
            {
                MessageBox.Show("Error: Folder already exists");
                return;
            }
            //check folder-file collision
            foreach (string file in Directory.GetFiles(saves + currFolder.Substring(0, currFolder.LastIndexOf('\\')))) {
                string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                if (fileName.ToLower().Equals(folderName.ToLower()))
                {
                    MessageBox.Show("Error: A file with the same name already exists in the parent folder");
                    return;
                }
            }

            //rename
            Directory.Move(saves + currFolder, saves + currFolder.Substring(0, currFolder.LastIndexOf('\\') + 1) + folderName);

            //update currFolder
            currFolder = currFolder.Substring(0, currFolder.LastIndexOf('\\') + 1) + folderName;
            //update pathLabel
            if (currFolder.Equals(""))
            {
                PathLabel.Text = "root";
            }
            else if (currFolder.IndexOf('\\') == currFolder.LastIndexOf('\\'))
            {
                PathLabel.Text = "root" + currFolder;
            }
            else
            {
                string parent = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                parent = parent.Substring(parent.LastIndexOf('\\') + 1);
                PathLabel.Text = parent + currFolder.Substring(currFolder.LastIndexOf('\\'));
            }

            //close
            RenameGroup.Visible = false;
            RenameBox.Text = "";
            RenameBox.KeyPress -= RenameFolder;
        }

        private void DeleteFolder()
        {
            if (currFolder.Equals(""))
            {
                MessageBox.Show("Error: Cannot delete root directory");
                return;
            }

            string folderName = currFolder.Substring(currFolder.LastIndexOf('\\') + 1);
            DialogResult res = MessageBox.Show("Are you sure you want to delete (" + folderName + ")?", "Confirm", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                //clear
                TitleBox.Text = "";
                Doc.Text = "";

                //delete
                Directory.Delete(saves + currFolder, true);
                //update currFolder
                currFolder = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                //update load
                LoadBox.Items.Clear();
                foreach (string file in Directory.GetFiles(saves + currFolder))
                {
                    LoadBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
                //update delete
                DeleteBox.Items.Clear();
                foreach (string file in Directory.GetFiles(saves + currFolder))
                {
                    DeleteBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
                //update folder
                FolderBox.Items.Clear();
                FolderBox.Items.Add("(Create New)");
                if (!currFolder.Equals("")) //if not root
                {
                    FolderBox.Items.Add("(Delete Folder)");
                    FolderBox.Items.Add("(Rename Folder)");
                    //parent option
                    string parent = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                    if (parent.Equals(""))
                    {
                        FolderBox.Items.Add(".. (root)");
                    }
                    else
                    {
                        FolderBox.Items.Add(".. (" + parent.Substring(parent.LastIndexOf('\\') + 1) + ")");
                    }
                }
                //subdirectories
                foreach (string dir in Directory.GetDirectories(saves + currFolder))
                {
                    FolderBox.Items.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
                }

                //update pathLabel
                if (currFolder.Equals(""))
                {
                    PathLabel.Text = "root";
                }
                else if (currFolder.IndexOf('\\') == currFolder.LastIndexOf('\\'))
                {
                    PathLabel.Text = "root" + currFolder;
                }
                else
                {
                    string parent = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                    parent = parent.Substring(parent.LastIndexOf('\\') + 1);
                    PathLabel.Text = parent + currFolder.Substring(currFolder.LastIndexOf('\\'));
                }
            }
        }

        private void FolderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //save
            if (!TitleBox.Text.Equals(""))
            {
                Save();
            }

            string folderName = FolderBox.Text;
            //(Create New Folder) new group
                //CreateGroup(reposition)

                //cannot create folder with reserved name
                //cannot create duplicate folder
            if (folderName.Equals("(Create New)"))
            {
                CreateGroup.Location = new Point(59, 76);
                CreateGroup.Visible = true;
                OptionGroup.Visible = false;

                CreateBox.KeyPress += CreateFolder;
                return;
            }
            //(Delete Folder) warning needed
                //cannot delete root
            if (folderName.Equals("(Delete Folder)"))
            {
                DeleteFolder();
                return;
            }
            //(Rename Folder)
                //RenameGroup(reposition)
            if (folderName.Equals("(Rename Folder)"))
            {
                RenameGroup.Location = new Point(59, 76);
                RenameGroup.Visible = true;
                OptionGroup.Visible = false;

                RenameBox.KeyPress += RenameFolder;
                return;
            }

            //.. (Parent)
            //update (load delete folder), change currPath

                //doesn't exist if in root directory
                    //if parent is root, display ..(root)
                    //if root, do not provide rename and delete options
            if (folderName[0] == '.' && folderName[1] == '.')
            {
                //clear doc
                TitleBox.Text = "";
                Doc.Text = "";
                //update currFolder
                currFolder = currFolder.Substring(0, currFolder.LastIndexOf('\\'));

                //load
                LoadBox.Items.Clear();
                foreach (string file in Directory.GetFiles(saves + currFolder))
                {
                    LoadBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
                //delete
                DeleteBox.Items.Clear();
                foreach (string file in Directory.GetFiles(saves + currFolder))
                {
                    DeleteBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
                }
                //folder
                FolderBox.Items.Clear();
                FolderBox.Items.Add("(Create New)");

                if (!currFolder.Equals("")) //if not at root
                {
                    FolderBox.Items.Add("(Delete Folder)");
                    FolderBox.Items.Add("(Rename Folder)");
                    string parentFolder = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                    if (parentFolder.Equals(""))
                    {
                        FolderBox.Items.Add(".. (root)");
                    }
                    else
                    {
                        FolderBox.Items.Add(".. (" + parentFolder.Substring(parentFolder.LastIndexOf('\\') + 1) + ")");
                    }
                }
                foreach (string dir in Directory.GetDirectories(saves + currFolder)) //subdirectories
                {
                    FolderBox.Items.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
                }

                //update label
                if (currFolder.Equals(""))
                {
                    PathLabel.Text = "root";
                }
                else if (currFolder.IndexOf('\\') == currFolder.LastIndexOf('\\'))
                {
                    PathLabel.Text = "root" + currFolder;
                }
                else
                {
                    string parent = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                    parent = parent.Substring(parent.LastIndexOf('\\') + 1);
                    PathLabel.Text = parent + currFolder.Substring(currFolder.LastIndexOf('\\'));
                }

                return;
            }
            //Folder
            //update (load delete folder), change currPath
            //if parent is root, display ..(root)

            //clear
            TitleBox.Text = "";
            Doc.Text = "";
            //update currFolder
            string parentName = currFolder.Substring(currFolder.LastIndexOf('\\') + 1);
            currFolder = currFolder + "\\" + FolderBox.Text;
            //load
            LoadBox.Items.Clear();
            foreach (string file in Directory.GetFiles(saves + currFolder))
            {
                LoadBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
            }
            //delete
            DeleteBox.Items.Clear();
            foreach (string file in Directory.GetFiles(saves + currFolder))
            {
                DeleteBox.Items.Add(file.Substring(file.LastIndexOf('\\') + 1));
            }
            //folder
                //if parent is root
            FolderBox.Items.Clear();
            FolderBox.Items.Add("(Create New)");
            FolderBox.Items.Add("(Delete Folder)");
            FolderBox.Items.Add("(Rename Folder)");
            if (currFolder.LastIndexOf('\\') == 0) //if parent is root
            {
                FolderBox.Items.Add(".. (root)");
            }
            else //if parent is not root
            {
                FolderBox.Items.Add(".. (" + parentName + ")");
            }
            foreach (string dir in Directory.GetDirectories(saves + currFolder))
            {
                FolderBox.Items.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
            }

            //update label
            if (currFolder.Equals(""))
            {
                PathLabel.Text = "root";
            }
            else if (currFolder.IndexOf('\\') == currFolder.LastIndexOf('\\'))
            {
                PathLabel.Text = "root" + currFolder;
            }
            else
            {
                string parent = currFolder.Substring(0, currFolder.LastIndexOf('\\'));
                parent = parent.Substring(parent.LastIndexOf('\\') + 1);
                PathLabel.Text = parent + currFolder.Substring(currFolder.LastIndexOf('\\'));
            }
        }

        private void Save()
        {
            //if no title
            if (TitleBox.Text.Equals(""))
            {
                MessageBox.Show("Error: No title provided");
                return;
            }
            //if already exists as folder
            string[] subdirectories = Directory.GetDirectories(saves + currFolder);
            foreach (string subdirectory in subdirectories)
            {
                string subName = subdirectory.Substring(subdirectory.LastIndexOf('\\') + 1);
                if (subName.ToLower().Equals(TitleBox.Text.ToLower()))
                {
                    MessageBox.Show("Error: File name already exists as a folder");
                    return;
                }
            }

            //save
            File.WriteAllText(saves + currFolder + "\\" + TitleBox.Text, Doc.Text);

            //update load
            List<string> loadItems = new List<string>();
            foreach (string item in LoadBox.Items)
            {
                loadItems.Add(item.ToLower());
            }
            if (!loadItems.Contains(TitleBox.Text.ToLower()))
            {
                LoadBox.Items.Add(TitleBox.Text);
            }
            //update delete
            List<string> deleteItems = new List<string>();
            foreach (string item in DeleteBox.Items)
            {
                deleteItems.Add(item.ToLower());
            }
            if (!deleteItems.Contains(TitleBox.Text.ToLower()))
            {
                DeleteBox.Items.Add(TitleBox.Text);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();

            //reload
            int selectionIndex = Doc.SelectionStart;
            string[] lines = Doc.Lines;
            Doc.Text = "";

            foreach (string line in lines)
            {
                if (line.Length >= 2 && line[0] == '\t' && line[1] == '\t')
                {
                    Doc.SelectionColor = color3;
                }
                else if (line.Length >= 1 && line[0] == '\t')
                {
                    Doc.SelectionColor = color2;
                }
                else
                {
                    Doc.SelectionColor = color1;
                }

                Doc.AppendText(line + "\n");
            }

            Doc.SelectionStart = selectionIndex;
            Doc.ScrollToCaret();
        }

        private void OptionGroup_Enter(object sender, EventArgs e)
        {
            //
        }
    }
}
