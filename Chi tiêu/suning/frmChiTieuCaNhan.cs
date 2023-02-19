using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace suning
{
    public partial class srm : Form
    {
        public srm()
        {
            InitializeComponent();
        }
        
        // Tổng.
        private void btnTong_Click(object sender, EventArgs e)
        {

            if (txtanuong.Text.Trim() == "" || txtdiennuoc.Text.Trim() == "" || txtmuasam.Text.Trim() == "" || txtduphong.Text.Trim() == "" || txttiennha.Text.Trim() == "" || txtgiaitri.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ số liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Thu gọn và Gán chi tiêu dưới dạng thập phân (decimal).
                decimal CTanuong = Convert.ToDecimal(txtanuong.Text);
                decimal CTdiennuoc = Convert.ToDecimal(txtdiennuoc.Text);
                decimal CTmuasam = Convert.ToDecimal(txtmuasam.Text);
                decimal CTqui = Convert.ToDecimal(txtduphong.Text);
                decimal CTtiennha = Convert.ToDecimal(txttiennha.Text);
                decimal CTgiaitri = Convert.ToDecimal(txtgiaitri.Text);

                // Số dư = Mức qui định - Chi tiêu.
                decimal sdanuong = Convert.ToDecimal(lbanuong2tr.Text.Replace(".", "")) - CTanuong;
                decimal sddiennuoc = Convert.ToDecimal(lbdiennuoc200.Text.Replace(".", "")) - CTdiennuoc;
                decimal sdmuasam = Convert.ToDecimal(lbmuasam500.Text.Replace(".", "")) - CTmuasam;
                decimal sdqui = Convert.ToDecimal(lbqui500.Text.Replace(".", "")) - CTqui;
                decimal sdtiennha = Convert.ToDecimal(lbtiennha4tr.Text.Replace(".", "")) - CTtiennha;
                decimal sdgiaitri = Convert.ToDecimal(lbgt2tr.Text.Replace(".", "")) - CTgiaitri;


                if (CTanuong % 500 != 0 || CTdiennuoc % 500 != 0 || CTmuasam % 500 != 0 || CTqui % 500 != 0 || CTtiennha % 500 != 0 || CTgiaitri % 500 != 0)
                {
                    MessageBox.Show("Số được nhập phải chia hết cho 500 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Hiện kết quả trong phần Số dư chi tiêu.
                    txtsdanuong.Text = sdanuong.ToString() + " VND\n";
                    txtsddiennuoc.Text = sddiennuoc.ToString() + " VND\n";
                    txtsdmuasam.Text = sdmuasam.ToString() + " VND\n";
                    txtsdquiduphong.Text = sdqui.ToString() + " VND\n";
                    txtsdtiennha.Text = sdtiennha.ToString() + " VND\n";
                    txtsdgiaitri.Text = sdgiaitri.ToString() + " VND\n";

                    // Tổng chi tiêu.
                    decimal TongChitieu = CTanuong + CTdiennuoc + CTmuasam + CTqui + CTtiennha + CTgiaitri;
                    txttongchitieu.Text = TongChitieu.ToString() + " VND\n";

                    // Tổng số dư chi tiêu.
                    decimal TongSoDuChiTieu = sdanuong + sddiennuoc + sdmuasam + sdqui + sdtiennha + sdgiaitri;
                    txttsdchitieu.Text = TongSoDuChiTieu.ToString() + " VND\n";

                    // Xem xét nếu là số âm.
                    if (sdanuong < 0)
                    {
                        // Nếu số âm, hiển thị màu đỏ.
                        txtsdanuong.ForeColor = Color.Red;
                    }
                    if (sddiennuoc < 0)
                    {
                        // Nếu số âm, hiển thị màu đỏ.
                        txtsddiennuoc.ForeColor = Color.Red;
                    }
                    if (sdmuasam < 0)
                    {
                        txtsdmuasam.ForeColor = Color.Red;
                    }
                    if (sdqui < 0)
                    {
                        txtsdquiduphong.ForeColor = Color.Red;
                    }
                    if (sdtiennha < 0)
                    {
                        txtsdtiennha.ForeColor = Color.Red;
                    }
                    if (sdanuong < 0)
                    {
                        txtsdtiennha.ForeColor = Color.Red;
                    }
                    if (sdgiaitri < 0)
                    {
                        txtsdgiaitri.ForeColor = Color.Red;
                    }
                   
                    if (TongSoDuChiTieu < 0)
                    {
                        txttsdchitieu.ForeColor = Color.Red;
                    }

                }
            }
        }
        
        // Tổng số dư.
        private void btndu_Click(object sender, EventArgs e)
        {
            if (txtthunhap.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Thu nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                decimal CTanuong = Convert.ToDecimal(txtanuong.Text);
                decimal CTdiennuoc = Convert.ToDecimal(txtdiennuoc.Text);
                decimal CTmuasam = Convert.ToDecimal(txtmuasam.Text);
                decimal CTqui = Convert.ToDecimal(txtduphong.Text);
                decimal CTtiennha = Convert.ToDecimal(txtduphong.Text);
                decimal CTgiaitri = Convert.ToDecimal(txtgiaitri.Text);

                decimal TongChitieu = CTanuong + CTdiennuoc + CTmuasam + CTqui + CTtiennha + CTgiaitri;

                decimal Thunhap = Convert.ToDecimal(txtthunhap.Text);
                if (Thunhap % 500 != 0)
                {
                    MessageBox.Show("Số được nhập phải chia hết cho 500 !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    decimal TongSoDuKhaDung = Thunhap - TongChitieu;
                    txttongsodukhadung.Text = TongSoDuKhaDung.ToString() + " VND\n";
                    
                    if (TongSoDuKhaDung < 0)
                    {
                        txttongsodukhadung.ForeColor = Color.Red;
                    }
                }
            }

        }
        
        // Reset chương trình.
        public void xoadulieu()
        {
            txtanuong.Text = "";
            txtdiennuoc.Text = "";
            txtduphong.Text = "";
            txtgiaitri.Text = "";
            txtmuasam.Text = "";
            txtthunhap.Text = "";
            txttiennha.Text = "";
            txtsdanuong.Text = "";
            cbmonth.Text = "";
            cbyear.Text = "";
            //so du.
            txtsddiennuoc.Text = "";
            txtsdgiaitri.Text = "";
            txtsdanuong.Text = "";
            txtsdquiduphong.Text = "";
            txtsdtiennha.Text = "";
            txtsdmuasam.Text = "";

            txttongchitieu.Text = "";
            txttongsodukhadung.Text = "";
            txttsdchitieu.Text = "";
            btnthem.Enabled = true;

        }
        
        // Nút "Thêm".
        private void cbmonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valuemonth = cbmonth.SelectedItem.ToString();
            MessageBox.Show("Bạn vừa chọn " + valuemonth, "Thông báo");

        }

        private void cbyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valueyear = cbyear.SelectedItem.ToString();
            MessageBox.Show("Bạn vừa chọn" + valueyear, "Thông báo");
        }

        private void btnthem_Click(object sender, EventArgs e)
        {

            if (cbmonth.Text.Trim() == "" || cbyear.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập ngày tháng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ListViewItem itemSochitieu = new System.Windows.Forms.ListViewItem(new string[]
                {
                    cbmonth.Text, cbyear.Text, txttongchitieu.Text, txttsdchitieu.Text, txttongsodukhadung.Text,
                }
               );
                lvttBangthongke.Items.AddRange(new System.Windows.Forms.ListViewItem[] { itemSochitieu });
                xoadulieu();
            }
        }
       
        // Chỉ cho phép nhập số.
        private void srm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}





