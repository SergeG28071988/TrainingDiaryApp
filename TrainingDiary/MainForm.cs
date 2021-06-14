using System;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TrainingDiary
{
    public partial class MainForm : Form
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Дневник тренировок.mdb"; // создали подключение к БД
        private readonly OleDbConnection dbConnection; // задали имя подключению
        public MainForm()
        {
            InitializeComponent();
            dbConnection = new OleDbConnection(connectString); // инициализируем подключение
            dbConnection.Open(); // открываем соединение
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "дневник_тренировокDataSet.Упражнения". При необходимости она может быть перемещена или удалена.
            this.упражненияTableAdapter.Fill(this.дневник_тренировокDataSet.Упражнения);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbConnection.Close(); // закрываем соединение
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            // Удаляем упражнение из базы

            int kod = Convert.ToInt32(textBox13.Text);
            string query = "DELETE FROM Упражнения WHERE [код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Упражнение удалено");
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            this.упражненияTableAdapter.Fill(this.дневник_тренировокDataSet.Упражнения); // обновление данных
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Изменяем дату упражнения

            int kod = Convert.ToInt32(textBox7.Text);
            string query = "UPDATE Упражнения SET Дата = '" + textBox8.Text + "'WHERE [Код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Дата изменена");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            // Изменяем название упражнения

            int kod = Convert.ToInt32(textBox7.Text);
            string query = "UPDATE Упражнения SET Наименование = '" + textBox9.Text + "'WHERE [Код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Наименование изменено");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Изменяем подходы (количество)

            int kod = Convert.ToInt32(textBox7.Text);
            string query = "UPDATE Упражнения SET Подходы = '" + textBox10.Text + "'WHERE [Код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Подходы изменены");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            // Изменяем вес

            int kod = Convert.ToInt32(textBox7.Text);
            string query = "UPDATE Упражнения SET Вес = '" + textBox11.Text + "'WHERE [Код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Вес изменен");
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Изменяем время

            int kod = Convert.ToInt32(textBox7.Text);
            string query = "UPDATE Упражнения SET Время = '" + textBox12.Text + "'WHERE [Код упражнения]=" + kod;
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Время изменено");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Добавляем данные в БД

            int kod = Convert.ToInt32(textBox1.Text);
            string date = textBox2.Text;
            string name = textBox3.Text;
            string approaches = textBox4.Text;
            string weight = textBox5.Text;
            string time = textBox6.Text;

            string query = "INSERT INTO Упражнения ([Код упражнения], Дата, Наименование, Подходы, Вес, Время) VALUES (" + kod + " , '" + date + "', '" + name + "', '" + approaches + "', '" + weight + "', '" + time + "')";
            OleDbCommand command = new OleDbCommand(query, dbConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("Данные добавлены");
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // выходим из приложения 
        }

        private void ОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Автор программы Дневник тренировок: Сергей Галкин, \nДата релиза: 05.06.2021 г.", "Внимание!!");
        }
    }
}
