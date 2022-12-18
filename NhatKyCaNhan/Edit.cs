using Microsoft.EntityFrameworkCore.Diagnostics;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NhatKyCaNhan
{
    public partial class Edit : Form
    {
        public int id;
        public int detail;
        public Edit(int id1, int detail1)
        {
            id = id1;
            detail = detail1;
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (MyDiaryContext context = new MyDiaryContext())
            {
                DiaryDetail d = context.DiaryDetails.FirstOrDefault(x => x.Id == detail);
                txtdate.Text = d.DateCreate.ToString("dd-MM-yyyy");
                txtTitle.Text = d.Title;
                txtDescription.Text = d.Description;
                d.CreateByNavigation = context.Accounts.FirstOrDefault(x => x.Id == d.CreateBy);
                showfullname.Text = d.CreateByNavigation.Username;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String Title = txtTitle.Text.Trim();
            String Description = txtDescription.Text.Trim();
            if (Title.Equals("") || Description.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập chủ đề và nội dung, không được để trống!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (MyDiaryContext context = new MyDiaryContext())
                {
                    DiaryDetail d = context.DiaryDetails.FirstOrDefault(x => x.Id == detail);

                    d.Title = txtTitle.Text;
                    d.Description = txtDescription.Text;
                    DialogResult r = MessageBox.Show("Bạn có muốn thêm bài này vào mục yêu thích không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (r == DialogResult.Yes)
                    {
                        d.Favourite = true;
                    }
                    else
                    {
                        d.Favourite = false;
                    }
                    MessageBox.Show("Cập nhật thành công", "Thông báo");
                    context.DiaryDetails.Update(d);
                    context.SaveChanges();
                    Main m = new Main(id);
                    m.Show();
                    this.Hide();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main m = new Main(id);
            m.Show();
            this.Hide();
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
