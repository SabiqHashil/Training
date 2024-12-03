namespace SimpleLoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = txtUser.Text;
            String password = txtPass.Text;
            if(username == "admin" && password == "admin" )
            {
                if (rememberMe.Checked)
                {
                    MessageBox.Show("Login Success! You will be remembered.");
                }
                else
                {
                    MessageBox.Show("Login Success!");
                }
            }
            else
            {
                MessageBox.Show("Login Error: Invalid credentials.");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
