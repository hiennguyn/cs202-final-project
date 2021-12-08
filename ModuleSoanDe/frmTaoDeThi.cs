using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ModuleSoanDe
{
    public partial class frmTaoDeThi : Form
    {
        private List<Question> listCauHoi = new List<Question>();
        private List<Question> listCauHoiTrongDe = new List<Question>();

        private List<RadioButton> listBtn = new List<RadioButton>();

        private List<string> listDapAn = new List<string>();
        public frmTaoDeThi()
        {
            InitializeComponent();
        }

        private void frmTaoDeThi_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 13; i++)
            {
                cmbThang.Items.Add(i.ToString());
            }

            cmbNam.Items.Add("2021");
            cmbNam.Items.Add("2022");
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
        private void loadFileXML(string filePath)
        {
            listCauHoi.Clear();
            lbDanhSachCauHoi.Items.Clear();

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
                if (frmSoanCauHoi.checkExistComboBox(cmbChuDe ,t) == false)
                {
                    cmbChuDe.Items.Add(t);
                }

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

                    xml.ReadToFollowing("A");
                    string a = xml.ReadElementContentAsString();
                    Option ansA = new Option(frmSoanCauHoi.checkText(ans, a), a);
                    temp.AnswerList.Add(ansA);

                    xml.ReadToFollowing("B");
                    string b = xml.ReadElementContentAsString();
                    Option ansB = new Option(frmSoanCauHoi.checkText(ans, b), b);
                    temp.AnswerList.Add(ansB);

                    xml.ReadToFollowing("C");
                    string c = xml.ReadElementContentAsString();
                    Option ansC = new Option(frmSoanCauHoi.checkText(ans, c), c);
                    temp.AnswerList.Add(ansC);

                    xml.ReadToFollowing("D");
                    string d = xml.ReadElementContentAsString();
                    Option ansD = new Option(frmSoanCauHoi.checkText(ans, d), d);
                    temp.AnswerList.Add(ansD);

                    listCauHoi.Add(temp);
                    lbDanhSachCauHoi.Items.Add(temp);
                }
            }

        }

        private void btnLoadNganHangCauHoi_Click(object sender, EventArgs e)
        {
            string filePath = frmSoanCauHoi.openFileXMLPath();

            try
            {
                loadFileXML(filePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid xml format file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int countQuestioninTopic(List<Question> list, string topic)
        {
            int count = 0;
            foreach (Question ques in list)
            {
                if (frmSoanCauHoi.checkText(ques.Topic, topic) == true)
                    count++;
            }
            return count;
        }

        private List<Question> exactTopicFromList(List<Question> list, string topic)
        {
            List<Question> temp = new List<Question>();
            
            foreach (Question ques in list)
            {
                if (frmSoanCauHoi.checkText(ques.Topic, topic) == true)
                    temp.Add(ques);
                    
            }
            return temp;
        }

        private List<Question> exactQuestFromList(List<Question> de)
        {
            List<Question> temp = new List<Question>();

            foreach (Question ques in listCauHoi)
            {
                if (de.Contains(ques) == false) 
                    temp.Add(ques);

            }
            return temp;
        }




        private void btnTaoDeNgauNhien_Click(object sender, EventArgs e)
        {
           
            List<Question> temp1 = new List<Question>();
            temp1 = exactQuestFromList(listCauHoiTrongDe);
            List<int> used = new List<int>();

            int n = int.Parse(txtSoLuongCauHoi.Text);
            Random r = new Random();
            if (cmbChuDe.Text == "") 
            {
                if (n <= temp1.Count) 
                {
                    for (int i = 0; i < n; i++)
                    {
                        int index = r.Next(0, temp1.Count);
                        if (used.Contains(index) == false)
                        {
                            used.Add(index);
                            Question temp = new Question();
                            temp = temp1[index];
                            listCauHoiTrongDe.Add(temp1[index]);
                            lbDe.Items.Add((listCauHoiTrongDe.IndexOf(temp1[index]) + 1).ToString() + " | " + temp);

                        }
                        else { i--; }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number of question!!");
                }
                
            }
            else
            {
                if (n <= countQuestioninTopic(temp1, cmbChuDe.Text)) 
                {
                    List<Question> temp = new List<Question>();
                    temp = exactTopicFromList(temp1, cmbChuDe.Text).ToList();
                    for (int i = 0; i < n; i++)
                    {
                        int index = r.Next(0, temp.Count);
                        if (used.Contains(index) == false)
                        {
                            used.Add(index);
                            listCauHoiTrongDe.Add(temp[index]);
                            lbDe.Items.Add((i + 1).ToString() + " | " + listCauHoiTrongDe[i]);

                        }
                        else { i--; }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid number of question!!");
                }
                    
            }
            
        }

        private void btnXoaDe_Click(object sender, EventArgs e)
        {
            listCauHoiTrongDe.Clear();
            lbDe.Items.Clear();
        }

        private void SortOrder()
        {
            for (int i = 0; i < lbDe.Items.Count; i++)
            {
                lbDe.Items[i] = ((i + 1).ToString() + " | " + listCauHoiTrongDe[i]);
            }
        }
        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            int index = lbDanhSachCauHoi.SelectedIndex;

            if (index > -1)
            {
                lbDe.Items.Add((lbDe.Items.Count + 1).ToString() + " | " + lbDanhSachCauHoi.Items[index]);

                listCauHoiTrongDe.Add(listCauHoi[index]);
                SortOrder();
            }
        }

        private void btnXoaCauHoi_Click(object sender, EventArgs e)
        {
            int index = lbDe.SelectedIndex;


            if (index > -1)
            {
                lbDe.Items.RemoveAt(index);
                listCauHoiTrongDe.RemoveAt(index);
                SortOrder();
            }
        }

        private void saveDe(XmlWriter xml, bool coDapAn)
        {
            xml.WriteStartElement("De");
            xml.WriteAttributeString("id", txtMaDe.Text);
            xml.WriteAttributeString("month", cmbThang.SelectedItem.ToString());
            xml.WriteAttributeString("year", cmbNam.SelectedItem.ToString());
            xml.WriteAttributeString("num", lbDe.Items.Count.ToString());

            int n = int.Parse(lbDe.Items.Count.ToString());

            for (int i = 0; i < n; i++)
            {
                xml.WriteStartElement("question");

                if (coDapAn == true)
                {
                    foreach (var anws in listCauHoiTrongDe[i].AnswerList)
                    {
                        if (anws.isCorrect == true)
                            xml.WriteAttributeString("correct", anws.Value);
                    }
                }

                xml.WriteAttributeString("content", listCauHoiTrongDe[i].Content);


                foreach (var cont in listCauHoiTrongDe[i].AnswerList)
                {
                    switch (listCauHoiTrongDe[i].AnswerList.IndexOf(cont))
                    {
                        case 0:
                            xml.WriteStartElement("A");
                            xml.WriteValue(cont.Value);
                            xml.WriteEndElement();
                            break;

                        case 1:
                            xml.WriteStartElement("B");
                            xml.WriteValue(cont.Value);
                            xml.WriteEndElement();
                            break;
                        case 2:
                            xml.WriteStartElement("C");
                            xml.WriteValue(cont.Value);
                            xml.WriteEndElement();
                            break;
                        case 3:
                            xml.WriteStartElement("D");
                            xml.WriteValue(cont.Value);
                            xml.WriteEndElement();
                            break;
                    }
                }

                xml.WriteEndElement(); // End of Ques


            }
            xml.WriteEndElement(); // End of De
            xml.Close();

        }

        private bool checkTextEmpty()
        {
            if (txtMaDe.Text == string.Empty || cmbThang.Text == "" || cmbNam.Text == "") 
                return true;
            else
                return false;
        }

        private void btnLuuDe_Click(object sender, EventArgs e)
        {
            if (checkTextEmpty() == false)
            {
                DeThi de = new DeThi();

                de.Thang = cmbThang.SelectedItem.ToString();
                de.Nam = cmbNam.SelectedItem.ToString();
                de.ID = txtMaDe.Text;

                string filename = de.ToString();

                string filepath1 = frmSoanCauHoi.saveFileXMLPath("De_" + filename + "_Thi");
                XmlWriter xml_De = XmlWriter.Create(filepath1, new XmlWriterSettings() { Indent = true });
                saveDe(xml_De, false);

                string filepath2 = frmSoanCauHoi.saveFileXMLPath("De_" + filename + "_coDapAn");
                XmlWriter xml_coDapAn = XmlWriter.Create(filepath2, new XmlWriterSettings() { Indent = true });
                saveDe(xml_coDapAn, true);
            } 

            else
                MessageBox.Show("Fill all the blank space!!");


        }

        private void randomList()
        {
            List<int> used = new List<int>();
            List<Question> temp = new List<Question>();

            int n = this.listCauHoiTrongDe.Count;

            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                int index = r.Next(0, n);
                if (used.Contains(index) == false)
                {
                    used.Add(index);
                    temp.Add(listCauHoiTrongDe[index]);

                }
                else { i--; }
            }

            this.listCauHoiTrongDe.Clear();
            this.listCauHoiTrongDe.AddRange(temp);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            lbDanhSachCauHoi.Items.Clear();

            foreach (Question q in listCauHoi)
            {
                if (q.Content.ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    lbDanhSachCauHoi.Items.Add(q);
                }
            }
        }

        private void btnRandom_Click(object sender, EventArgs e)
        {
            randomList();
            SortOrder();
        }
    }
}
