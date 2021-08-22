using System;
using System.Drawing;
using System.Windows.Forms;

namespace PanelJump
{
    public partial class FormJump : Form
    {
        public FormJump()
        {
            InitializeComponent();
        }
        int maxX;
        int maxY;
        private int timer;

        Panel kwadrat = new Panel();

        private void FormJump_Load(object sender, EventArgs e)
        {
            Form frm = (Form)sender;
            maxX = frm.Size.Width;
            maxY = frm.Size.Height;

            kwadrat.Size = new Size(100, 100);           
            Controls.Add(kwadrat);
            PanelJump();
        }       
        
        private void PanelJump()
        {            
            var rand = new Random();
            int deltaX = rand.Next(0, maxX-100);
            int deltaY = rand.Next(0, maxY-100);
            if (deltaX > maxX || deltaY > maxY)
            {
                deltaX = maxX;
                deltaY = maxY;
                kwadrat.Location = new Point(deltaX, deltaY);
            }
            
            kwadrat.Location = new Point(deltaX, deltaY);
                        
            timerRun.Start();           

        }
        private void ColorSwitch()
        {            
            Random rand = new Random();
            kwadrat.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
            PanelJump();
            
        }

        private void timerRun_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timerRun.Interval == 150)
            {
                timerRun.Stop();
                timerRun.Dispose();
                ColorSwitch();
            }


        }
    }
}
