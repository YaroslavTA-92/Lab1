using SampleModel.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleModel
{
    public partial class MainForm : Form
    {
        private Tank Block;
        private LimitBlock xLimit = new LimitBlock(0,100);
        private double y;
        private double x2;
        private double time = 0;
        private double dt = 0.1;

        public MainForm() {
            InitializeComponent();
            Block = new Tank(dt);
        }


        private void tmModel_Tick(object sender, EventArgs e) {
            y = Block.Calc(x2, y);
            time += dt; 
            lbY.Text = y.ToString("F2");
            chMainPlot.Series[0].Points.AddXY(time,y);
            chMainPlot.Series[1].Points.AddXY(time, x2);
        }

        private void btnStart_Click(object sender, EventArgs e) {
            time += dt;
            lbY.Text = y.ToString("F2");
            chMainPlot.Series[0].Points.AddXY(time, y);
            chMainPlot.Series[1].Points.AddXY(time, x2);
            tmModel.Start();
        }

        private void btnStop_Click(object sender, EventArgs e) {
            tmModel.Stop();
        }


        private void btnX1_Click(object sender, EventArgs e) {
            tmModel.Interval = 1000;
        }

        private void btnX10_Click(object sender, EventArgs e) {
            tmModel.Interval = 100;
        }

        private void lbYCaption_Click(object sender, EventArgs e) {

        }

        private void btnDn2_Click(object sender, EventArgs e) {
            x2 -= 1;
            x2 = xLimit.Calc(x2);
            tbX2.Text = x2.ToString("F2");
        }

        private void btnUp2_Click(object sender, EventArgs e) {
            x2 += 1;
            x2 = xLimit.Calc(x2);
            tbX2.Text = x2.ToString("F2");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbX2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
