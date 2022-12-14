using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LPT;

namespace WindowsApplication9
{
    public partial class FormLPT : Form
    {
        //private int _value = 0;
        private int _index =0;
        private int _port_addr;
        int[] _arrPinValue = { 1, 2, 4, 8, 16, 32, 64, 128, 64, 32, 16, 8, 4, 2, 1, 0, 129, 66, 36, 24, 60, 126, 255/**/, 231, 195, 129, 0 };

        public FormLPT()
        {
            InitializeComponent();
        }

        private void ResetLPT()
        {
            CbD7.Checked = CbD6.Checked = CbD5.Checked = CbD4.Checked = CbD3.Checked =
                CbD2.Checked = CbD1.Checked = CbD0.Checked = false;
            PortAccess.output(_port_addr, 0);
            PortAccess.output(_port_addr + 1, 0);
            PortAccess.output(_port_addr + 2, 0);

        }
        private void Set_port_address()
        {
            _port_addr = int.Parse(mTxtPortAddr.Text);
            toolStripStatusLabel1.Text = "آدرس پورت در مبنای 16 : " + PortAccess.Int2Hex(_port_addr);
        }
        private void LED_Dance(int _speed)
        {
            ResetLPT();
            CbD6.Checked = true;

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetLPT();
            lblstatus.Text = " تمامی پین های کنترل و داده صفر شد";
        }

        private void FormLPT_Load(object sender, EventArgs e)
        {
            ResetLPT();
            Set_port_address();
            label1.Text =label1.Text + "\n" + "برای یک کردن هر کدام از پین های شماره 2 تا 9 که به صورت D0 تا D7 نشان داده شده اند ، بر روی پین مربوط کلیک کنید";
            NUDInterval.Value = timer1.Interval;
        }

        private void BtnDance_Click(object sender, EventArgs e)
        {

        }

        private void BtnSetAddr_Click(object sender, EventArgs e)
        {
            Set_port_address();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void CbD0_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD7.Checked == true)
                pictureBox1_0.Visible = true;
            else
                pictureBox1_0.Visible = false;
        }

        private void CbD1_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD6.Checked == true)
                pictureBox1_1.Visible = true;
            else
                pictureBox1_1.Visible = false;
        }

        private void CbD2_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD5.Checked == true)
                pictureBox1_2.Visible = true;
            else
                pictureBox1_2.Visible = false;
        }

        private void CbD3_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD4.Checked == true)
                pictureBox1_3.Visible = true;
            else
                pictureBox1_3.Visible = false;
        }

        private void CbD4_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD3.Checked == true)
                pictureBox1_4.Visible = true;
            else
                pictureBox1_4.Visible = false;
        }

        private void CbD5_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD2.Checked == true)
                pictureBox1_5.Visible = true;
            else
                pictureBox1_5.Visible = false;
        }

        private void CbD6_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD1.Checked == true)
                pictureBox1_6.Visible = true;
            else
                pictureBox1_6.Visible = false;
        }

        private void CbD7_CheckedChanged(object sender, EventArgs e)
        {
            if (CbD0.Checked == true)
                pictureBox1_7.Visible = true;
            else
                pictureBox1_7.Visible = false;
        }

        private void BtnLedJoin_Click(object sender, EventArgs e)
        {
            ShowLEDsfrm a = new ShowLEDsfrm();
            a.ShowDialog();
            a.Dispose();
            a = null;
        }

        private void extbtn_Click(object sender, EventArgs e)
        {
            if ((NUDInterval.Value == 1366) & (CbD0.Checked==true) & (CbD7.Checked==true))
                MessageBox.Show("This Program Created By Mohammad Taghadosi in 1387-10-10", "Hidden Message");
            this.Close();
        }

        private void btnset_Click(object sender, EventArgs e)
        {
            if (DataPorts_chkbx.Enabled == true)
            {
                _index = 0;
                if (CbD0.Checked == Enabled)
                    _index++;
                if (CbD1.Checked == Enabled)
                    _index += 2;
                if (CbD2.Checked == Enabled)
                    _index += 4;
                if (CbD3.Checked == Enabled)
                    _index += 8;
                if (CbD4.Checked == Enabled)
                    _index += 16;
                if (CbD5.Checked == Enabled)
                    _index += 32;
                if (CbD6.Checked == Enabled)
                    _index += 64;
                if (CbD7.Checked == Enabled)
                    _index += 128;
                PortAccess.output(_port_addr, _index);
                lblstatus.Text = "عدد " + _index.ToString() + " بصورت باینری بر روی پین های داده قرار گرفت  ";
            }
            if (ControlPorts_chkbx.Enabled == true)
            {
                _index = 0;
                if (CbD3.Checked == Enabled)
                    _index += 8;
                if (CbD2.Checked == Enabled)
                    _index += 4;
                if (CbD1.Checked == Enabled)
                    _index += 2;
                if (CbD0.Checked == Enabled)
                    _index ++;
                PortAccess.output(_port_addr + 2, _index);
                lblstatus.Text = "عدد " + _index.ToString() + " بصورت باینری بر روی پین های کنترل قرار گرفت  ";
            }
        }

        private void DataPorts_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (DataPorts_chkbx.Checked == true)
            {
                StatusPorts_chkbx.Enabled = false;
                ControlPorts_chkbx.Enabled = false;
            }
            if (DataPorts_chkbx.Checked == false)
            {
                StatusPorts_chkbx.Enabled = true;
                ControlPorts_chkbx.Enabled = true;
            }
        }

        private void ControlPorts_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (ControlPorts_chkbx.Checked == true)
            {
                StatusPorts_chkbx.Enabled = false;
                DataPorts_chkbx.Enabled = false;
                CbD7.Enabled = false;
                CbD6.Enabled = false;
                CbD5.Enabled = false;
                CbD4.Enabled = false;
                CbD0.Text = "C0";
                CbD1.Text = "C1";
                CbD2.Text = "C2";
                CbD3.Text = "C3";
                CbD4.Text = "C4";
                CbD5.Text = "C5";
                CbD6.Text = "C6";
                CbD7.Text = "C7";
            }
            if (ControlPorts_chkbx.Checked == false)
            {
                StatusPorts_chkbx.Enabled = true;
                DataPorts_chkbx.Enabled = true;
                CbD7.Enabled = true;
                CbD6.Enabled = true;
                CbD5.Enabled = true;
                CbD4.Enabled = true;
                CbD0.Text = "D0";
                CbD1.Text = "D1";
                CbD2.Text = "D2";
                CbD3.Text = "D3";
                CbD4.Text = "D4";
                CbD5.Text = "D5";
                CbD6.Text = "D6";
                CbD7.Text = "D7";
            }
        }

        private void StatusPorts_chkbx_CheckedChanged(object sender, EventArgs e)
        {
            if (StatusPorts_chkbx.Checked == true)
            {
                DataPorts_chkbx.Enabled = false;
                ControlPorts_chkbx.Enabled = false;
                CbD0.Enabled = false;
                CbD1.Enabled = false;
                CbD2.Enabled = false;
                CbD3.Enabled = false;
                CbD4.Enabled = false;
                CbD5.Enabled = false;
                CbD6.Enabled = false;
                CbD7.Enabled = false;
                CbD0.Text = "S0";
                CbD1.Text = "S1";
                CbD2.Text = "S2";
                CbD3.Text = "S3";
                CbD4.Text = "S4";
                CbD5.Text = "S5";
                CbD6.Text = "S6";
                CbD7.Text = "S7";
                lblstatus.Text = "با شرایط پیش فرض، برنامه قادر به نوشتن بر روی این نوع پورت نمی باشد";
            }
            if (StatusPorts_chkbx.Checked == false)
            {
                DataPorts_chkbx.Enabled = true;
                ControlPorts_chkbx.Enabled = true;
                CbD0.Enabled = true;
                CbD1.Enabled = true;
                CbD2.Enabled = true;
                CbD3.Enabled = true;
                CbD4.Enabled = true;
                CbD5.Enabled = true;
                CbD6.Enabled = true;
                CbD7.Enabled = true;
                CbD0.Text = "C0";
                CbD1.Text = "C1";
                CbD2.Text = "C2";
                CbD3.Text = "C3";
                CbD4.Text = "C4";
                CbD5.Text = "C5";
                CbD6.Text = "C6";
                CbD7.Text = "C7";
                lblstatus.Text = " ";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}