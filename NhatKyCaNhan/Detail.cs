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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NhatKyCaNhan
{
    public partial class Detail : Form
    {
        public int id;
        public int detail;
        public Detail(int id1, int detail1)
        {
            id = id1;
            detail = detail1;
            InitializeComponent();
        }

        private void Detail_Load(object sender, EventArgs e)
        {
            using (MyDiaryContext context = new MyDiaryContext())
            {
                DiaryDetail d = context.DiaryDetails.FirstOrDefault(x => x.Id == detail);
                d.CreateByNavigation = context.Accounts.FirstOrDefault(x => x.Id == d.CreateBy);
                lbdate.Text = d.DateCreate.ToString("dd-MM-yyyy");
                afullname.Text = d.CreateByNavigation.FullName;
                lbTitle.Text = d.Title;
                txtdata.Text = d.Description;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main form = new Main(id);
            this.Hide();
            form.Show();
        }

        private void txtdata_DoubleClick(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn sửa bài viết không?", "Thông báo", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                using (MyDiaryContext context = new MyDiaryContext())
                {
                    var data = context.DiaryDetails.FirstOrDefault(d => d.Id == id);
                    Edit form = new Edit(id, detail);
                    form.Show();
                    this.Hide();
                }
            }
        }

        private void lbTitle_DoubleClick(object sender, EventArgs e)
        {

        }

        private void Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
