using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleSoanDe
{
    class Option
    {
        public bool isCorrect { get; set; }
        public string Value { get; set; }

        public Option(bool _isCorrect, string _value)
        {
            isCorrect = _isCorrect;
            Value = _value;
        }

        public override String ToString()
        {
            string result = this.isCorrect.ToString() + "-" + this.Value;

            return result;
        }
    }
    class Question
    {
        public string RightAnswer { get; set; }
        public string Content { get; set; }
        public string Topic { get; set; }
        public List<Option> AnswerList { get; set; }

        public Question()
        {
            Content = string.Empty;
            Topic = string.Empty;
            AnswerList = new List<Option>();
            RightAnswer = string.Empty;
        }
        public Question(string _question, string _topic, List<Option> _answerList)
        {
            Content = _question;
            Topic = _topic;
            AnswerList = new List<Option>();
            AnswerList = _answerList.ToList();
        }

        public override String ToString()
        {
            string result = this.Topic + " | " + this.Content;
            foreach (var ans in AnswerList)
            {
                if (ans.isCorrect == true)
                    result += " | " + ans.Value;
            }

            return result;
        }

    }

    class DeThi
    {
        public string Thang { get; set; }
        public string Nam { get; set; }
        public string ID { get; set; }

        public List<Question> ques = new List<Question>();

        public override string ToString()
        {
            char[] nam = Nam.ToCharArray();

            string two = nam[2].ToString() + nam[3].ToString();

            int t = int.Parse(Thang);
            Thang = String.Format("{0:00}", t);

            return two + Thang + ID;
        }
    }
}
