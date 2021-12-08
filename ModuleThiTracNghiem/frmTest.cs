using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace ModuleThiTracNghiem
{
    public partial class frmTest : Form
    {
        List<uscQuestion> listCauHoi = new List<uscQuestion>();
        string maDe;

        private int currentIndex = 0;

        public int CurrentIndex
        {
            get { return currentIndex; }
            set
            {
                currentIndex = value;
                this.Controls.Add(listCauHoi[currentIndex]);
                listCauHoi[currentIndex].Location = new Point(270, 200);
                listCauHoi[currentIndex].display(currentIndex + 1);
                listCauHoi[currentIndex].BringToFront();
                
            }
        }
        public frmTest()
        {
            InitializeComponent();
            uscClock.uscEClock_Exit += new uscClock.uscEClock_ExitHandle(uscClock_uscEClock_Exit);

        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            btnStart.Enabled = false;
            btnSubmit.Enabled = false;

            btnBack.Visible = false;
            btnNext.Visible = false;
        }

        private string openFileXMLPath()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Chon tap tin .xml|*.xml";

            string filePath = "";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
            }
            return filePath;
        }
        private void loadDeXML(string filePath)
        {
            listCauHoi.Clear();

            string xmlFile = filePath;
            XmlReader xml = XmlReader.Create(xmlFile);

            xml.ReadToFollowing("De");

            xml.MoveToAttribute("num");
            int n = int.Parse(xml.Value);

            xml.MoveToAttribute("id");
            maDe = xml.Value;
            lbMaDe.Text = maDe;


            for (int i = 0; i < n; i++)
            {
                uscQuestion temp = new uscQuestion();

                xml.ReadToFollowing("question");
                xml.MoveToAttribute("content");
                temp.Content = xml.Value;

                xml.ReadToFollowing("A");
                temp.optionList.Add(xml.ReadElementContentAsString());

                xml.ReadToFollowing("B");
                temp.optionList.Add(xml.ReadElementContentAsString());

                xml.ReadToFollowing("C");
                temp.optionList.Add(xml.ReadElementContentAsString());

                xml.ReadToFollowing("D");
                temp.optionList.Add(xml.ReadElementContentAsString());

                listCauHoi.Add(temp);

                temp.uscQuestion_check += new uscQuestion.uscQuestion_checkHandle(uscQuestion_uscEquestion_check);
                temp.uscQuestion_Uncheck += new uscQuestion.uscQuestion_checkHandle(uscQuestion_uscEquestion_Uncheck);
                temp.uscQuestion_Choose += new uscQuestion.uscQuestion_chooseHandle(uscQuestion_uscEquestion_Choose);
            }

        }

        private void btnChonDe_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                string filePath = openFileXMLPath();

                try
                {
                    loadDeXML(filePath);
                    btnStart.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid xml format file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter your name !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int secs = listCauHoi.Count * 15;


            if (MessageBox.Show($"Đề: {maDe}" + $"\nSố câu hỏi: {listCauHoi.Count}" + $"\nThời gian: {secs}s", "Application message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                fillQuestion();
                this.CurrentIndex = 0;
                secondConvert(secs);
                uscClock.Start();

                btnNext.Visible = true;
                btnBack.Visible = true;

                btnStart.Enabled = false;
                btnSubmit.Enabled = true;

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (CurrentIndex <= 0)
            {
                MessageBox.Show("You are at Question 1!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                CurrentIndex--;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CurrentIndex >= listCauHoi.Count - 1)
            {
                MessageBox.Show("No more question!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                CurrentIndex++;
        }

        private void randomList()
        {
            List<int> used = new List<int>();
            List<uscQuestion> temp = new List<uscQuestion>();

            int n = this.listCauHoi.Count;

            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                int index = r.Next(0, n);
                if (used.Contains(index) == false)
                {
                    used.Add(index);
                    temp.Add(listCauHoi[index]);

                }
                else { i--; }
            }

            this.listCauHoi.Clear();
            this.listCauHoi.AddRange(temp);
        }

        private void fillQuestion()
        {
            Font f = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);

            for (int i = 0; i < listCauHoi.Count; i++)
            {

                ListViewItem item = new ListViewItem("  " + (i + 1).ToString());

                item.SubItems.Add("");
                item.Font = f;

                lstviewStatus.Items.Add(item);
            }
        }

        private void secondConvert(int secs)
        {
            uscClock._hour = secs / 3600;
            secs = secs % 3600;
            uscClock._minute = secs / 60;
            uscClock._second = secs % 60;
        }

        void uscClock_uscEClock_Exit()
        {
            uscClock.Stop();

            if (MessageBox.Show("Over time", "Application message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string filename = saveFileXMLPath("made_hoten_DapAn");
                XmlWriter xml_result = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true });
                saveResult(xml_result);
            }

            btnSubmit.Enabled = false;
            btnStart.Enabled = false;
        }

        List<int> used = new List<int>();
        void uscQuestion_uscEquestion_check()
        {
            for (int i = 0; i < listCauHoi.Count; i++)
            {
                if (listCauHoi[i].checkXemLai() == true && used.Contains(i) == false)
                {
                    lstviewStatus.Items[i].UseItemStyleForSubItems = false;
                    lstviewStatus.Items[i].SubItems[1].BackColor = Color.Thistle;

                    used.Add(i);
                }

            }

        }

        void uscQuestion_uscEquestion_Uncheck()
        {
            for (int i = 0; i < listCauHoi.Count; i++)
            {
                if (listCauHoi[i].checkXemLai() == false && used.Contains(i) == true)
                {
                    lstviewStatus.Items[i].UseItemStyleForSubItems = false;
                    lstviewStatus.Items[i].SubItems[1].BackColor = default;

                    used.Remove(i);
                }

            }

        }

        void uscQuestion_uscEquestion_Choose()
        {

            for (int i = 0; i < listCauHoi.Count; i++)
            {
                if (listCauHoi[i].checkOption() == true && listCauHoi[i].checkXemLai() == false)
                {
                    lstviewStatus.Items[i].UseItemStyleForSubItems = false;
                    lstviewStatus.Items[i].SubItems[1].BackColor = Color.DarkSeaGreen;

                }
            }
        }

        private void saveResult(XmlWriter xml)
        {
            xml.WriteStartElement("Info");
            xml.WriteAttributeString("id", maDe);
            xml.WriteAttributeString("num", listCauHoi.Count.ToString());
            xml.WriteAttributeString("name", txtName.Text);
            xml.WriteAttributeString("date", DateTime.Now.ToString());

            int n = int.Parse(listCauHoi.Count.ToString());
            for (int i = 0; i < n; i++)
            {
                xml.WriteStartElement("question");

                xml.WriteAttributeString("content", listCauHoi[i].Content);

                if (listCauHoi[i].checkOption() == true)
                {
                    xml.WriteStartElement("answer");
                    xml.WriteValue(listCauHoi[i].Answer);
                    xml.WriteEndElement();
                }

                xml.WriteEndElement(); 
            }

            xml.WriteEndElement(); 
            xml.Close();

        }

        private string saveFileXMLPath(string filename)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = filename;
            dlg.Filter = "Luu tap tin .xml|*.xml";

            string filePath = "";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // lấy đường dẫn tập tin sẽ lưu
                filePath = dlg.FileName;
            }
            return filePath;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận nộp bài", "Application message", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string filename = saveFileXMLPath("made_hoten_DapAn");
                XmlWriter xml_result = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true });
                saveResult(xml_result);

                uscClock.Stop();
                btnSubmit.Enabled = false;
            }
        }

        private void lstviewStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (lstviewStatus.SelectedItems.Count > 0)
                index = lstviewStatus.SelectedIndices[0];

            CurrentIndex = index;
        }

       
    }
}
