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
using System.Xml;

namespace ModuleSoanDe
{
    public partial class frmChamBai : Form
    {
        List<string> listCauHoi = new List<string>();
        List<string> listDapAn = new List<string>();
        List<Employee> listEmployees = new List<Employee>();
        List<string> filenames = new List<string>();
        public frmChamBai()
        {
            InitializeComponent();
        }

        private void frmChamBai_Load(object sender, EventArgs e)
        {
            btnTinhDiem.Enabled = false;
            btnInBangDiem.Enabled = false;

            this.txtFolderPath.AllowDrop = true;
            this.txtFolderPath.DragEnter += new DragEventHandler(txtFolderPath_DragEnter);
            this.txtFolderPath.DragDrop += new DragEventHandler(txtFolderPath_DragDrop);
        }

        private void loadFileXML(string filePath)
        {
            listCauHoi.Clear();
            listDapAn.Clear();
            string xmlFile = filePath;
            XmlReader xml = XmlReader.Create(xmlFile);

            xml.ReadToFollowing("List");

            xml.MoveToAttribute("numOfQuestion");
            int n = int.Parse(xml.Value);

            xml.MoveToAttribute("numOfTopic");
            int numTopic = int.Parse(xml.Value);

            for (int i = 0; i < numTopic; i++)
            {
                xml.ReadToFollowing("topic");

                xml.MoveToAttribute("name");
                string t = xml.Value;

                xml.MoveToAttribute("numQuesInTopic");
                int m = int.Parse(xml.Value);

                for (int j = 0; j < m; j++)
                {
                    Question temp = new Question();
                    temp.Topic = t;

                    xml.ReadToFollowing("question");
                    xml.MoveToAttribute("content");
                    temp.Content = xml.Value;

                    xml.MoveToAttribute("correct");
                    string ans = xml.Value;
                    temp.RightAnswer = ans;


                    listCauHoi.Add(temp.Content);
                    listDapAn.Add(temp.RightAnswer);
                }


            }
        }

        private void btnChonFileDapAn_Click(object sender, EventArgs e)
        {
            string filePath = frmSoanCauHoi.openFileXMLPath();

            try
            {
                loadFileXML(filePath);
                btnTim.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid xml format file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            filenames.Clear();
            lbFile.Items.Clear();

            string folderPath = txtFolderPath.Text;

            if (Directory.Exists(folderPath) == true)
            {
                string[] files = Directory.GetFiles(folderPath);
                foreach (var filename in files)
                {
                    lbFile.Items.Add(filename);
                    filenames.Add(filename);
                }

                btnTinhDiem.Enabled = true;
            } 
                
            
        }

        private bool checkDapAn(Question q)
        {
            int index = listCauHoi.IndexOf(q.Content);
            if (frmSoanCauHoi.checkText(q.RightAnswer, listDapAn[index]) == true) return true;
            else
                return false;
        }

        private double scoreConvert(int right, int n)
        {
            return 10 * ((double)right / n);
        }

        private void loadFileDapAn(string filename)
        {
            Employee e = new Employee();

            string xmlFile = filename;
            XmlReader xml = XmlReader.Create(xmlFile);

            xml.ReadToFollowing("Info");

            xml.MoveToAttribute("date");
            e.Date = xml.Value;

            xml.MoveToAttribute("name");
            e.Name = xml.Value;

            xml.MoveToAttribute("num");
            int n = int.Parse(xml.Value);

            xml.MoveToAttribute("id");
            e.testID = xml.Value;

            int score = 0;

            for (int i = 0; i < n; i++)
            {
                Question q = new Question();
                xml.ReadToFollowing("question");
                xml.MoveToAttribute("content");
                q.Content = xml.Value;

                xml.ReadToFollowing("answer");
                q.RightAnswer = xml.ReadElementContentAsString();

                if (checkDapAn(q) == true) 
                {
                    score++;
                }
            }
            e.rightAnswer = score.ToString() + "/" + n.ToString();

            e.Score = scoreConvert(score, n);

            listEmployees.Add(e);
            
        }

        private void listviewConvert()
        {
            listEmployees.Sort(new ScoreDescendingComparer());

            foreach (Employee e in listEmployees)
            {
                ListViewItem item = new ListViewItem(e.Date);

                item.SubItems.Add(e.testID);
                item.SubItems.Add(e.Name);
                item.SubItems.Add(e.rightAnswer);
                item.SubItems.Add(String.Format("{0:0.##}", e.Score));

                listviewScore.Items.Add(item);
            }    
        }

        class ScoreDescendingComparer : IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                if (x.Score.CompareTo(y.Score) > 0) return -1;
                else
                    return 1;
            }
        }

        private string saveFileTextPath(string filename)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = filename;
            dlg.Filter = "Luu tap tin .txt|*.txt";

            string filePath = "";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
            }
            return filePath;
        }
        private void btnInBangDiem_Click(object sender, EventArgs e)
        {
            string filename = saveFileTextPath("bangDiem");

            StreamWriter sw = File.CreateText(filename);

            sw.WriteLine(listEmployees.Count);

            listEmployees.Sort(new ScoreDescendingComparer());

            foreach (var emp in listEmployees)
            {
                String line = emp.ToString();
                sw.WriteLine(line);
            }
            sw.Close();
        }

        private void btnTinhDiem_Click(object sender, EventArgs e)
        {
            foreach (var filename in filenames)
            {
                try
                {
                    loadFileDapAn(filename);
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid xml format file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            
            listviewConvert();
            btnInBangDiem.Enabled = true;
        }

        private void txtFolderPath_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (Directory.Exists(files[0]))
                {
                    txtFolderPath.Text = files[0];
                }
            }
        }

        private void txtFolderPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
