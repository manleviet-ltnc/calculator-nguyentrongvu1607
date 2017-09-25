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
        enum PhepToan { Cong, Tru, Nhan, Chia, Can, PhanTram}
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
                lblShow.Text = lblShow.Text + so;
            else
            {
                lblShow.Text = so;
                isTypingNumber = true;
            }
        }
        private void NhapPhepToan(object sender, EventArgs e)
        {
            TinhKetQua();
            Button btn = (Button)sender;
            switch(btn.Text)
            {
                case "+": pheptoan = PhepToan.Cong;break;
                case "-": pheptoan = PhepToan.Tru;break;
                case "*": pheptoan = PhepToan.Nhan;break;
                case "/":pheptoan = PhepToan.Chia;break;
                case "√":pheptoan = PhepToan.Can;break;
                case "%": pheptoan = PhepToan.PhanTram;break;
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
                case PhepToan.Can: ketqua = Math.Sqrt(nho);break;
                case PhepToan.PhanTram:ketqua = nho / 100;break;
            }
            lblShow.Text = ketqua.ToString();
        }

        private void btnBang_Click(object sender, EventArgs e)
        {
            TinhKetQua();
            isTypingNumber = false;
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

        
    }
}
