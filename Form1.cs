using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace baitapnhom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "select * from khachhang";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dataGridView1.DataSource = tbl;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = dataGridView1.CurrentRow.Index;
            txtmakhach.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txttenkhach.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtngaysinh.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
            txtgioitinh.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtmakhach.Clear();
            txttenkhach.Clear();
            txtngaysinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
            txtmakhach.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(txtmakhach.TextLength==0)
            {
                MessageBox.Show("chua chon dong xoa");
            }
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "delete from khachhang where makhach='" + txtmakhach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtmakhach.ReadOnly = true;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "update khachhang set tenkhach='" + txttenkhach.Text + "',ngaysinh='" + txtngaysinh.Text + "',gioitinh='" + txtgioitinh.Text + "',diachi='" + txtdiachi.Text + "' where makhach='" + txtmakhach.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            txtmakhach.ReadOnly = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
                con.Open();
                string sql = "insert into phong values('" + txtmakhach.Text + "','" + txttenkhach.Text + "','" + txtngaysinh.Text + "','" + txtgioitinh.Text + "','" + txtdiachi.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
            }
            catch
            {
                MessageBox.Show("không thêm được vì trùng mã khách hàng");
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
                con.Close();
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmakhach.Clear();
            txttenkhach.Clear();
            txtngaysinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
