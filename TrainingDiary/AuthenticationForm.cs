using System;
using System.Windows.Forms;

namespace TrainingDiary
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
            mainForm = new MainForm();
        }
        MainForm mainForm;
        string Login = "admin";
        string Password = "Qwery122";

        private void Enter_Btn_Click(object sender, EventArgs e)
        {
            string Log = login_txt.Text;
            string Pas = password_txt.Text; 

            // Проверка
            if(Log == Login && Pas == Password)
            {
                mainForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Ошибка в логине или пароле. Попробуйте еще раз!!");
            }
        }
    }
}
