using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapko_IKM722a_1
{
    public partial class Form1 : Form
    {
        private DateTime startTime;
        private bool Mode; 
        private MajorWork MajorObject;
        public Form1()
        {
            InitializeComponent();
        }

        private void tClock_Tick(object sender, EventArgs e)
        {
            tClock.Stop();
            MessageBox.Show("Минуло 25 секунд", "Увага");
            tClock.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startTime = DateTime.Now;
            MessageBox.Show("Програма почала роботу о " + startTime.ToString());
            MajorObject = new MajorWork();
            MajorObject.SetTime();
            About A = new About(); 
            A.tAbout.Start();
            A.ShowDialog(); 
            MajorObject = new MajorWork();
            this.Mode = true;
        }
        private void bStart_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                tbInput.Enabled = true;
                tbInput.Focus();
                tClock.Start();
                bStart.Text = "Стоп"; 
                this.Mode = false;
            }
            else
            {
                tbInput.Enabled = false;
                tClock.Stop();
                bStart.Text = "Пуск";
                this.Mode = true;
                MajorObject.Write(tbInput.Text);
                MajorObject.Task();
                label1.Text = MajorObject.Read();
            }
        }

        private void tbInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            tClock.Stop();
            tClock.Start();
            if ((e.KeyChar >= '0') & (e.KeyChar <= '9') | (e.KeyChar == (char)8))
            {
                return;
            }
            else
            {
                tClock.Stop();
                MessageBox.Show("Неправильний символ", "Помилка");
                tClock.Start();
                e.KeyChar = (char)0;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
         
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            MessageBox.Show("Час роботи програми: " + duration.ToString(), "Час роботи програми");
           /* string s;
            s = (System.DateTime.Now - MajorObject.GetTime()).ToString();
            MessageBox.Show(s, "Час роботи програми");
            
            DateTime endTime = DateTime.Now;
            TimeSpan totalDuration = endTime - startTime;
            MessageBox.Show("Загальний час роботи програми: " + totalDuration.ToString(), "Час роботи програми");*/
        }
    }
}
