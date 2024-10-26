using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }


        private int sss = 0;
        public int ShowTest() 
        {
            return sss;
        }

        double tpsValue;
        double phaseCurValue;
        double dutyValue;
        double angleWriteValue;

        private void convertControlParam(string str, out double value) 
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                value = Convert.ToDouble(str);
            }
            else 
            {
                value = 0;
            }
        }
        
        





        private void button_Confirm_Click(object sender, EventArgs e)
        {
            convertControlParam(textBox_PhaseCur.Text, out phaseCurValue);
            sss = 100000;
        }

        private void checkBox_TPSSimulation_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_TPSSimulation.Checked)
            {
                checkBox_PhaseCur.Enabled = false;
                checkBox_Duty.Enabled = false;
                checkBox_AngleWrite.Enabled = false;
            }
            else 
            {
                checkBox_PhaseCur.Enabled = true;
                checkBox_Duty.Enabled = true;
                checkBox_AngleWrite.Enabled = true;
            }
        }
        private void checkTPSCheckBox() 
        {
            if (checkBox_PhaseCur.Checked)
            {
                checkBox_TPSSimulation.Enabled = false;
            }
            else if (checkBox_Duty.Checked)
            {
                checkBox_TPSSimulation.Enabled = false;
            }
            else if (checkBox_AngleWrite.Checked)
            {
                checkBox_TPSSimulation.Enabled = false;
            }
            else
            {
                checkBox_TPSSimulation.Enabled = true;
            }
        }

        private void checkBox_PhaseCur_CheckedChanged(object sender, EventArgs e)
        {
            checkTPSCheckBox();
        }

        private void checkBox_Duty_CheckedChanged(object sender, EventArgs e)
        {
            checkTPSCheckBox();
        }

        private void checkBox_AngleWrite_CheckedChanged(object sender, EventArgs e)
        {
            checkTPSCheckBox();
        }
    }
}
