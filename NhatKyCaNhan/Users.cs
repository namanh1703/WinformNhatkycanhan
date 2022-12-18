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

namespace NhatKyCaNhan
{
    public partial class Users : Form
    {
        public int a;
        public Users(int a1)
        {
            this.a = a1;
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            using (MyDiaryContext context = new MyDiaryContext())
            {
                Account ac = context.Accounts.FirstOrDefault(x => x.Id == a);
                txtName.Text = ac.Username;
                txtStatus.Text = ac.Status;
                txtFullname.Text = ac.FullName;
                txtsex.Text = ac.Sex == true ? "Nam" : "Nữ";
                txtBirth.Text = ac.Dob.Value.ToString("dd-MM-yyyy");
                txtEmail.Text = ac.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main(a);
            m.Show();
            this.Hide();
        }
    }
}
