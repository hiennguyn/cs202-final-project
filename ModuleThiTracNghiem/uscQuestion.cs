using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleThiTracNghiem
{
    public partial class uscQuestion : UserControl
    {
        public string Content { get; set; }
        public List<string> optionList { get; set; }
        public string Answer { get; set; }

        List<RadioButton> button = new List<RadioButton>();

        public delegate void uscQuestion_checkHandle();
        public event uscQuestion_checkHandle uscQuestion_check;
        public event uscQuestion_checkHandle uscQuestion_Uncheck;

        public delegate void uscQuestion_chooseHandle();
        public event uscQuestion_chooseHandle uscQuestion_Choose;
        public uscQuestion()
        {
            InitializeComponent();

            this.optionList = new List<string>();

            radioButtonA.Checked = false;
            radioButtonB.Checked = false;
            radioButtonC.Checked = false;
            radioButtonD.Checked = false;

            button.Add(radioButtonA);
            button.Add(radioButtonB);
            button.Add(radioButtonC);
            button.Add(radioButtonD);

        }

        private void uscQuestion_Load(object sender, EventArgs e)
        {
            randomOption();

        }
        private bool checkText(string x, string y)
        {
            if (string.Equals(x, y)) return true;
            else
                return false;
        }

        public void display(int index)
        {
            lbQuestion.Text = $"Câu {index}";
            txtContent.Text = this.Content;

            //randomOption();

            txtA.Text = this.optionList[0];
            txtB.Text = this.optionList[1];
            txtC.Text = this.optionList[2];
            txtD.Text = this.optionList[3];
        }

        private void randomOption()
        {
            List<int> used = new List<int>();
            List<string> temp = new List<string>();

            int n = this.optionList.Count;

            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                int index = r.Next(0, n);
                if (used.Contains(index) == false)
                {
                    used.Add(index);
                    temp.Add(optionList[index]);
                }
                else { i--; }
            }

            this.optionList.Clear();
            this.optionList.AddRange(temp);
        }

        public bool checkXemLai()
        {
            if (checkBoxXemLai.Checked == true)
            {
                return true;
            }
            else
                return false;
        }

        public bool checkOption()
        {
            for (int i = 0; i < optionList.Count; i++)
            {
                if (button[i].Checked == true)
                {
                    Answer = optionList[i];
                    return true;
                }
            }
            return false;
        }

        private void checkBoxXemLai_CheckedChanged(object sender, EventArgs e)
        {
            if (checkXemLai() == true)
            {
                uscQuestion_check();
            }
            else
            {
                if (checkOption() == true)
                {
                    uscQuestion_Uncheck();
                    uscQuestion_Choose();
                }
                else
                    uscQuestion_Uncheck();
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (checkXemLai() == true)
                uscQuestion_check();
            else
                uscQuestion_Choose();
        }

        
    }
}
