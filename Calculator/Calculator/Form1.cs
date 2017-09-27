using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool isTypingNumber = false;
        enum PhepToan {None, Cong, Tru, Nhan, Chia}
        PhepToan pheptoan;
        double nho;
        private void NhapSo(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            NhapSo(btn.Text);
        }
        private void NhapSo(string so)
        {
            if (isTypingNumber)
                lblShow.Text += so;
            else
            {
                lblShow.Text = so;
                isTypingNumber = true;
            }
        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            if(nho!=0)
            TinhKetQua();
            Button btn = (Button)sender;
            switch(btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong;break;
                case "-": pheptoan = PhepToan.Tru;break;
                case "*": pheptoan = PhepToan.Nhan;break;
                case "/":pheptoan = PhepToan.Chia;break;
            }
            nho = double.Parse(lblShow.Text);
            isTypingNumber = false;
        }
        private void TinhKetQua()
        {
            double tam = double.Parse(lblShow.Text);
            double ketqua = 0.0;
            switch(pheptoan)
            {
                case PhepToan.Cong: ketqua = nho + tam;break;
                case PhepToan.Tru: ketqua = nho - tam;break;
                case PhepToan.Nhan: ketqua = nho * tam;break;
                case PhepToan.Chia: ketqua = nho / tam;break;
            }
            lblShow.Text = ketqua.ToString();
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
            nho = 0;
            pheptoan = PhepToan.None;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    NhapSo("" + e.KeyChar);
                    break;
            }
        }

        private void Xoahet(object sender, EventArgs e)
        {
            nho = 0;
            lblShow.Text = "0.";
        }

        private void PhanTram(object sender, EventArgs e)
        {
            lblShow.Text = (double.Parse(lblShow.Text) / 100).ToString();
        }

        private void Can(object sender, EventArgs e)
        {
            lblShow.Text = Math.Sqrt(double.Parse(lblShow.Text)).ToString();
        }

        private void Xoamotkitu(object sender, EventArgs e)
        {
            if (lblShow.Text != "")
                lblShow.Text = (lblShow.Text).Substring(0, lblShow.Text.Length - 1);
            if(lblShow.Text=="")
                lblShow.Text="0.";
        }

        private void DoiDau(object sender, EventArgs e)
        {
            lblShow.Text = (-1 * double.Parse(lblShow.Text)).ToString();
        }

        private void ThapPhan(object sender, EventArgs e)
        {
            lblShow.Text = (double.Parse(lblShow.Text) / 10).ToString();
        }
    }
}
