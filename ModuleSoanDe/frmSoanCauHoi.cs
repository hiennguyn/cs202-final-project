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
    public partial class frmSoanCauHoi : Form
    {
        private List<Question> listCauHoi = new List<Question>();
        
        private List<RadioButton> listBtn = new List<RadioButton>();
        
        public frmSoanCauHoi()
        {
            InitializeComponent();
        }

        private void frmSoanCauHoi_Load(object sender, EventArgs e)
        {
            listBtn.Add(radioButtonA);
            listBtn.Add(radioButtonB);
            listBtn.Add(radioButtonC);
            listBtn.Add(radioButtonD);

            cmbTopic.Items.Add("Phần mềm");
            cmbTopic.Items.Add("Phần cứng");
            cmbTopic.Items.Add("Mạng");
            cmbTopic.Items.Add("Bảo mật");

            cmbSearchTopic.Items.Clear();
        }

        private void clearText()
        {
            txtQuestion.Text = String.Empty;
            txtA.Text = String.Empty;
            txtB.Text = String.Empty;
            txtC.Text = String.Empty;
            txtD.Text = String.Empty;

            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
            radioButtonD.Checked = false;

            cmbTopic.SelectedIndex = -1;

        }

        public static bool checkText(string x, string y)
        {
            if (string.Equals(x, y)) return true;
            else
                return false;
        }

        private bool checkEmpty()
        {
            if (radioButtonA.Checked == false && radioButtonB.Checked == false && radioButtonC.Checked == false && radioButtonD.Checked == false)
                return true;
            else if (txtQuestion.Text == string.Empty || txtA.Text == string.Empty || txtB.Text == string.Empty || txtC.Text == string.Empty || txtD.Text == string.Empty)
                return true;
            else if (cmbTopic.SelectedIndex < 0 || cmbTopic.Text == "") return true;

            else
                return false;
        }
        private int countQuestioninTopic(string topic)
        {
            int count = 0;
            foreach (Question ques in listCauHoi)
            {
                if (checkText(ques.Topic, topic) == true)
                    count++;
            }
            return count;
        }

        public static bool checkExistComboBox(ComboBox cmb, string topic)
        {
            if (cmb.Items.Count != 0)
            {
                foreach (var item in cmb.Items)
                {
                    if (checkText(topic, item.ToString()) == true)
                        return true;
                }
            }

            return false;
        }

        class TopicDescendingComparer : IComparer<Question>
        {
            public int Compare(Question x, Question y)
            {
                if (x.Topic.CompareTo(y.Topic) < 0) return -1;
                else
                    return 1;
            }
        }

        private void textBoxToQuestion(Question question)
        {
            question.Content = txtQuestion.Text;
            question.Topic = cmbTopic.Text;

            if (checkExistComboBox(cmbSearchTopic, question.Topic) == false) 
            {
                cmbSearchTopic.Items.Add(question.Topic);
            }

            Option ansA = new Option(radioButtonA.Checked, txtA.Text);
            Option ansB = new Option(radioButtonB.Checked, txtB.Text);
            Option ansC = new Option(radioButtonC.Checked, txtC.Text);
            Option ansD = new Option(radioButtonD.Checked, txtD.Text);

            question.AnswerList.Add(ansA);
            question.AnswerList.Add(ansB);
            question.AnswerList.Add(ansC);
            question.AnswerList.Add(ansD);

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkEmpty() == false)
            {
                Question question = new Question();
                textBoxToQuestion(question);

                listCauHoi.Add(question);
                lbNganHangCauHoi.Items.Add(question);
                clearText();
            }
            else
                MessageBox.Show("Fill all the blank space !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int index = lbNganHangCauHoi.SelectedIndex;
            Question question = new Question();

            if (index > -1 && checkEmpty() == false) 
            {
                textBoxToQuestion(question);
                listCauHoi[index] = question;
                lbNganHangCauHoi.Items[index] = question;

                clearText();
            }
            else
                MessageBox.Show("Fill all the blank space !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lbNganHangCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lbNganHangCauHoi.SelectedIndex;

            if (index > -1)
            {
                txtQuestion.Text = listCauHoi[index].Content;
                cmbTopic.Text = listCauHoi[index].Topic;

                foreach (var option in listCauHoi[index].AnswerList)
                {
                    switch (listCauHoi[index].AnswerList.IndexOf(option))
                    {
                        case 0:
                            radioButtonA.Checked = option.isCorrect;
                            txtA.Text = option.Value;
                            break;

                        case 1:
                            radioButtonB.Checked = option.isCorrect;
                            txtB.Text = option.Value;
                            break;
                        case 2:
                            radioButtonC.Checked = option.isCorrect;
                            txtC.Text = option.Value;
                            break;
                        case 3:
                            radioButtonD.Checked = option.isCorrect;
                            txtD.Text = option.Value;
                            break;
                    }

                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int index = lbNganHangCauHoi.SelectedIndex;

            if (index > -1)
            {
                listCauHoi.RemoveAt(index);
                lbNganHangCauHoi.Items.RemoveAt(index);
            }

            clearText();
        }

        public static string saveFileXMLPath(string filename)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.FileName = filename;
            dlg.Filter = "Luu tap tin .xml|*.xml";
            
            string filePath = "";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                filePath = dlg.FileName;
            }
            return filePath;
        }


        private void btnInDanhSachCauHoi_Click(object sender, EventArgs e)
        {
            if (listCauHoi.Count > 0) 
            {
                string filename = saveFileXMLPath("questionList");

                XmlWriter xml = XmlWriter.Create(filename, new XmlWriterSettings() { Indent = true });

                listCauHoi.Sort(new TopicDescendingComparer());

                xml.WriteStartElement("List");
                xml.WriteAttributeString("numOfQuestion", lbNganHangCauHoi.Items.Count.ToString());
                xml.WriteAttributeString("numOfTopic", cmbTopic.Items.Count.ToString());

                int count = 0;
                for (int j = 0; j < cmbTopic.Items.Count; j++)
                {
                    xml.WriteStartElement("topic");
                    int num = countQuestioninTopic(cmbTopic.Items[j].ToString());

                    xml.WriteAttributeString("numQuesInTopic", num.ToString());
                    xml.WriteAttributeString("name", cmbTopic.Items[j].ToString());

                    for (int i = 0; i < num; i++)
                    {

                        xml.WriteStartElement("question");
                        foreach (Option opt in listCauHoi[count].AnswerList)
                        {
                            if (opt.isCorrect == true)
                                xml.WriteAttributeString("correct", opt.Value);
                        }

                        xml.WriteAttributeString("content", listCauHoi[count].Content);

                        foreach (Option option in listCauHoi[count].AnswerList)
                        {
                            switch (listCauHoi[count].AnswerList.IndexOf(option))
                            {
                                case 0:
                                    xml.WriteStartElement("A");
                                    xml.WriteValue(option.Value);
                                    xml.WriteEndElement();
                                    break;

                                case 1:
                                    xml.WriteStartElement("B");
                                    xml.WriteValue(option.Value);
                                    xml.WriteEndElement();
                                    break;
                                case 2:
                                    xml.WriteStartElement("C");
                                    xml.WriteValue(option.Value);
                                    xml.WriteEndElement();
                                    break;
                                case 3:
                                    xml.WriteStartElement("D");
                                    xml.WriteValue(option.Value);
                                    xml.WriteEndElement();
                                    break;
                            }

                        }
                        count++;
                        xml.WriteEndElement(); // End of Ques
                    }
                    xml.WriteEndElement(); // End of Topic
                }

                xml.WriteEndElement(); // End of Ans

                xml.Close();
            }   
            else
                MessageBox.Show("Empty list !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
        public static string openFileXMLPath()
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "Chọn file .xml|*.xml";

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
                if (checkExistComboBox(cmbSearchTopic, t) == false) 
                {
                    cmbSearchTopic.Items.Add(t);
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
                    Option ansA = new Option(checkText(ans, a), a);
                    temp.AnswerList.Add(ansA);

                    xml.ReadToFollowing("B");
                    string b = xml.ReadElementContentAsString();
                    Option ansB = new Option(checkText(ans, b), b);
                    temp.AnswerList.Add(ansB);

                    xml.ReadToFollowing("C");
                    string c = xml.ReadElementContentAsString();
                    Option ansC = new Option(checkText(ans, c), c);
                    temp.AnswerList.Add(ansC);

                    xml.ReadToFollowing("D");
                    string d = xml.ReadElementContentAsString();
                    Option ansD = new Option(checkText(ans, d), d);
                    temp.AnswerList.Add(ansD);

                    listCauHoi.Add(temp);
                    lbNganHangCauHoi.Items.Add(temp);
                }
            }

        }

        private void btnLoadDanhSachCauHoi_Click(object sender, EventArgs e)
        {
            string filePath = openFileXMLPath();

            try
            {
                loadFileXML(filePath);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid xml format file !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtSearchBar_TextChanged(object sender, EventArgs e)
        {
            lbNganHangCauHoi.Items.Clear();

            foreach (Question q in listCauHoi)
            {
                if (q.Content.ToUpper().Contains(txtSearchBar.Text.ToUpper()))
                {
                    lbNganHangCauHoi.Items.Add(q);
                }
            }
        }

        private void cmbSearchTopic_TextChanged(object sender, EventArgs e)
        {
            int index = cmbSearchTopic.SelectedIndex;
            string topic = cmbSearchTopic.Text.ToString();

            if (topic != string.Empty)
            {
                lbNganHangCauHoi.Items.Clear();

                foreach (Question q in listCauHoi)
                {
                    if (q.Topic.ToUpper().Contains(topic.ToUpper()))
                    {
                        lbNganHangCauHoi.Items.Add(q);
                    }
                }
            }
            else
            {
                lbNganHangCauHoi.Items.Clear();

                foreach (Question q in listCauHoi)
                {
                    lbNganHangCauHoi.Items.Add(q);
                }
            }
        }

        private void cmbTopic_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbTopic.Text != string.Empty)
                {
                    for (int i = 0; i < cmbTopic.Items.Count; i++)
                    {
                        if (cmbTopic.Text == cmbTopic.Items[i].ToString())
                            return;
                    }
                    cmbTopic.Items.Add(cmbTopic.Text);
                }
            }
        }
    }
}
