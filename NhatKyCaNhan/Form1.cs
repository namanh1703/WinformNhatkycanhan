using NhatKyCaNhan.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NhatKyCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn muốn thoát phải không :((", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void btnInfor_Click(object sender, EventArgs e)
        {
            var messageLines = new string[]
                    {
                     "Thông Tin!",
                     "Version: 1.0.1",
                     "Cập nhật lần cuối: 15/12/2022",
                     "Develop Designed: Anhdhnhe153381 ",};

            MessageBox.Show(string.Join(Environment.NewLine, messageLines), "Thông báo", MessageBoxButtons.OK);

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            String Ruser = txtRegisterUser.Text.Trim();
            String Rpass = txtRegisterPass.Text.Trim();
            String Rrpass = txtRegisterRePass.Text.Trim();
            String Rfullname = txtRegisterFullName.Text.Trim();
            String Remail = txtRegisterEmail.Text.Trim();
            if (Ruser.Equals("") || Rpass.Equals("") || Rrpass.Equals("") || Rfullname.Equals("") || Remail.Equals(""))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin, không được để trống!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String pass = txtRegisterPass.Text;
                String repass = txtRegisterRePass.Text;
                if (pass != repass)
                {
                    MessageBox.Show("Nhập lại mật khẩu không trùng khớp, vui lòng nhập lại!!", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    String user = txtRegisterUser.Text;
                    using (MyDiaryContext context = new MyDiaryContext())
                    {
                        Account ac = context.Accounts.FirstOrDefault(a => a.Username == user);
                        if (ac != null)
                        {
                            MessageBox.Show("Tên tài khoản đã có người sử dụng, vui lòng chọn tên khác!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                        else
                        {
                            DialogResult r = MessageBox.Show("Bạn có chắc thông tin của bạn đã chính xác? " +
                                "Thông tin sau khi đăng ký sẽ không thể chỉnh sửa", "Thông báo", MessageBoxButtons.OKCancel);
                            if (r == DialogResult.OK)
                            {
                                Account newacc = new Account();
                                newacc.Username = txtRegisterUser.Text;
                                newacc.Password = txtRegisterPass.Text;
                                newacc.FullName = txtRegisterFullName.Text;
                                newacc.Email = txtRegisterEmail.Text;
                                newacc.Dob = dateTime.Value;
                                string sex = cbsex.SelectedValue.ToString();
                                newacc.Sex = cbsex.SelectedValue.ToString() == "Nam" ? true : false;
                                context.Accounts.Add(newacc);
                                context.SaveChanges();
                                MessageBox.Show("Thêm mới thành công Tài Khoản", "Thông báo", MessageBoxButtons.OK);
                            }
                        }
                        txtUsername.Text = txtRegisterUser.Text;
                        txtPassword.Text = txtRegisterPass.Text;
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control txt in this.Controls)
            {
                if (txt.GetType() == typeof(TextBox))
                {
                    txt.Enter += Txt_Enter;
                    txt.Leave += Txt_Leave;
                }
            }
            List<string> list = new List<string>() { "Nam", "Nữ" };
            cbsex.DisplayMember = "string";
            cbsex.ValueMember = "string";
            cbsex.DataSource = list;
        }

        private void Txt_Leave(object? sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
        }

        private void Txt_Enter(object? sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.Pink;
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
            if (username.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu đang trống", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                String user = txtUsername.Text;
                String pass = txtPassword.Text;
                using (MyDiaryContext context = new MyDiaryContext())
                {
                    Account acc = context.Accounts.FirstOrDefault(x => x.Username == user && x.Password == pass);
                    if (acc != null)
                    {
                        Main main = new Main(acc.Id);
                        this.Hide();
                        main.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản và mật khẩu!!" +
                            "Nếu bạn chưa có! Hãy Đăng Ký <3", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtRegisterUser.Text = "";
            txtRegisterPass.Text = "";
            txtRegisterRePass.Text = "";
            txtRegisterFullName.Text = "";
            txtRegisterEmail.Text = "";
        }

        private void btnforgotpass_Click(object sender, EventArgs e)
        {

        }
    }
}
