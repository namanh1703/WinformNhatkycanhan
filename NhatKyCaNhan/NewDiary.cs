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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NhatKyCaNhan
{
    public partial class NewDiary : Form
    {
        public int a;
        public NewDiary(int a1)
        {
            this.a = a1;
            InitializeComponent();
        }

        private void NewDiary_Load(object sender, EventArgs e)
        {
            
        }

        private void txtBack_Click(object sender, EventArgs e)
        {
            Main main = new Main(a);
            this.Hide();
            main.Show();
        }

        private void txtSubmit_Click(object sender, EventArgs e)
        {
            String Title = txtTitle.Text.Trim();
            String Description = txtDescription.Text.Trim();
            if (Title.Equals("") || Description.Equals(""))
            {
                MessageBox.Show("Vui lòng nhập chủ đề và nội dung, không được để trống!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DiaryDetail r = new DiaryDetail();
                r.Title = txtTitle.Text;
                r.Description = txtDescription.Text;
                r.CreateBy = a;
                r.DateCreate = dateTime.Value;
                using (var context = new MyDiaryContext())
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn thêm bài này vào mục yêu thích không?", "Thông báo", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        r.Favourite = true;
                    }
                    else
                    {
                        r.Favourite = false;
                    }
                    context.DiaryDetails.Add(r);
                    context.SaveChanges();
                    MessageBox.Show("Thêm mới thành công Nhật Ký");
                    Main m = new Main(a);
                    m.Show();
                    this.Hide();
                }
            }

        }

        private void NewDiary_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
