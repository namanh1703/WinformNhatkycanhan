using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.VisualBasic.ApplicationServices;
using NhatKyCaNhan.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NhatKyCaNhan
{
    public partial class Main : Form
    {
        public int a;
        public Main(int a1)
        {
            InitializeComponent();
            this.a = a1;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
            //foreach (Control txt in this.Controls)
            //{
            //    if (txt.GetType() == typeof(TextBox))
            //    {
            //        txt.Enter += Txt_Enter;
            //        txt.Leave += Txt_Leave;
            //    }
            //}
        }

        //private void Txt_Leave(object? sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    txt.BackColor = Color.White;
        //}

        //private void Txt_Enter(object? sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    txt.BackColor = Color.Pink;
        //}

        private void LoadData()
        {
            using (MyDiaryContext context = new MyDiaryContext())
            {
                List<DiaryDetail> list = context.DiaryDetails.Where(x => x.CreateBy == a).ToList();
                foreach (DiaryDetail item in list.OrderByDescending(x => x.DateCreate))
                {
                    dgData.Rows.Add(item.Id, item.DateCreate.ToString("MM-dd-yyyy"), item.Title, item.Description, item.Favourite == true ? "Yêu thích" : "");
                }
            }
        }

        private void dgData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgData.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
            dateTime.Value = DateTime.Parse(dgData.Rows[e.RowIndex].Cells["Column2"].Value.ToString());
            txtTitle.Text = dgData.Rows[e.RowIndex].Cells["Column3"].Value.ToString();
            txtDescription.Text = dgData.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                int iddetail = int.Parse(txtID.Text);
                Detail form = new Detail(a, iddetail);
                form.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Id không tồn tại, vui lòng nhập đúng ID hoặc chọn bài viết để xem chi tiết ", "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (MyDiaryContext context = new MyDiaryContext())
                {

                    var data = context.DiaryDetails.FirstOrDefault(d => d.Id == Int32.Parse(txtID.Text));
                    if (data != null)
                    {
                        txtID.Focus();
                    }
                    DialogResult r = MessageBox.Show("Bạn có chắc có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel);
                    if (r == DialogResult.OK)
                    {
                        DiaryDetail d = context.DiaryDetails.FirstOrDefault(x => x.Id == Int32.Parse(txtID.Text));
                        context.DiaryDetails.Remove(d);
                        context.SaveChanges();
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        dgData.Rows.Clear();
                        LoadData();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Id không tồn tại, vui lòng nhập đúng ID hoặc chọn bài viết để xóa ", "Thông báo");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            try
            {

                using (MyDiaryContext context = new MyDiaryContext())
                {

                    var data = context.DiaryDetails.FirstOrDefault(d => d.Id == Int32.Parse(txtID.Text));
                    if (data != null)
                    {
                        txtID.Focus();
                    }
                    int idDetail = int.Parse(txtID.Text);
                    Edit form = new Edit(a, idDetail);
                    form.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Id không tồn tại, vui lòng nhập đúng ID hoặc chọn bài viết!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewDiary form = new NewDiary(a);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users u = new Users(a);
            u.Show();
            this.Hide();
        }

        private void btnUpdatestatus_Click(object sender, EventArgs e)
        {
            if (txtStatus.Text == "")
            {
                MessageBox.Show("Tâm trạng của bạn thế nào, hãy nhập để lưu lại trạng thái nhé", "Thông báo");
            }
            else
            {
                using (MyDiaryContext context = new MyDiaryContext())
                {
                    Account account = context.Accounts.FirstOrDefault(x => x.Id == a);
                    account.Status = txtStatus.Text;
                    context.SaveChanges();
                    MessageBox.Show("Cập nhật trạng thái thành công", "Thông báo");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int year = int.Parse(txtYear.Text);
                using (MyDiaryContext context = new MyDiaryContext())
                {
                    dgData.Rows.Clear();
                    List<DiaryDetail> list = context.DiaryDetails.Where(x => x.DateCreate.Year == year && x.CreateBy == a).ToList();
                    foreach (DiaryDetail item in list.OrderByDescending(x => x.DateCreate))
                    {
                        dgData.Rows.Add(item.Id, item.DateCreate.ToString("dd-MM-yyyy"), item.Title, item.Description, item.Favourite == true ? "Yêu thích" : "");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không tìm kiếm được!!");
                dgData.Rows.Clear();
                LoadData();
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Main_Enter(object sender, EventArgs e)
        {

        }

        private void dgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iddetail = int.Parse(txtID.Text);
            Detail form = new Detail(a, iddetail);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                Form1 f = new Form1();
                this.Hide();
                f.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (MyDiaryContext context = new MyDiaryContext())
            {
                dgData.Rows.Clear();
                List<DiaryDetail> list = context.DiaryDetails.Where(x => x.Favourite == true).ToList();
                foreach (DiaryDetail item in list.OrderByDescending(x => x.DateCreate))
                {
                    dgData.Rows.Add(item.Id, item.DateCreate.ToString("dd-MM-yyyy"), item.Title, item.Description, item.Favourite == true ? "Yêu thích" : "");
                }
            }
        }

        private void btnload_Click(object sender, EventArgs e)
        {
            dgData.Rows.Clear();
            LoadData();
        }
    }
}
