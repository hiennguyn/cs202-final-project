using System;
using System.Drawing;
using System.Windows.Forms;

namespace ModuleThiTracNghiem
{
    public partial class uscClock : UserControl
    {
        int hour, minute, second;
        int _hourBegin, _minuteBegin, _secondBegin;
        public uscClock()
        {
            InitializeComponent();
        }

        public delegate void uscEClock_ExitHandle();
        public event uscEClock_ExitHandle uscEClock_Exit;

        public int _hour
        {
            get
            {
                return _hourBegin;
            }
            set
            {
                if (value < 0)
                    _hourBegin = 0;
                else
                    if (value > 99)
                    _hourBegin = 99;
                else
                    _hourBegin = value;

            }
        }

        private void uscClock_Paint(object sender, PaintEventArgs e)
        {
            string hour1 = (hour / 10).ToString();
            string hour2 = (hour % 10).ToString();
            string min1 = (minute / 10).ToString();
            string min2 = (minute % 10).ToString();
            string sec1 = (second / 10).ToString();
            string sec2 = (second % 10).ToString();

            string res = hour1 + hour2 + " : " + min1 + min2 + " : " + sec1 + sec2;

            lbTime.Text = res;

            Font f = new Font("FVF Fernando 08", 14, FontStyle.Bold);

            e.Graphics.DrawString(lbTime.Text, f, Brushes.White, 25, 125);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            second--;
            if (second < 0)
            {
                second = 59;
                minute--;
            }
            if (minute < 0)
            {
                minute = 59;
                hour--;
            }
            if (hour < 0)
                hour = 99;

            this.Invalidate();

            if (hour == 0 && minute == 0 && second == 0)
                uscEClock_Exit(); 
        }

        public int _minute
        {
            get
            {
                return _minuteBegin;
            }
            set
            {
                if (value < 0)
                    _minuteBegin = 0;
                else
                if (value > 99)
                    _minuteBegin = 99;
                else
                    _minuteBegin = value;

            }
        }

        public int _second
        {
            get
            {
                return _secondBegin;
            }
            set
            {
                if (value < 0)
                    _secondBegin = 0;
                else
                if (value > 99)
                    _secondBegin = 99;
                else
                    _secondBegin = value;

            }
        }


        public void Start()
        {
            timer.Enabled = true;
            
            if (_hourBegin != 0)
            {
                hour = _hourBegin;
               
            }
            if (_minuteBegin != 0)
            {
                minute = _minuteBegin;
                
            }

            if (_secondBegin != 0)
            {
                second = _secondBegin;
               
            }

        }
        public void Stop()
        {
            timer.Enabled = false;
            hour = minute = second = 0;

        }

    }
}
