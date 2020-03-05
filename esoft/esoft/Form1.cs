using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace esoft
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data source=303-1\\NEW_MSSQLSERVER; Initial Catalog=EsoftDBZP; Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            UpravCoef upravCoef = new UpravCoef();
            Zadachi zadachi = new Zadachi();
            sqlConnection.Open();
            //создание sql запроса
            SqlCommand sqlCommandExecutor = new SqlCommand(
                $"SELECT" +
                    $" executor.id_executor, " +
                    $" executor.Логин " +
                $"FROM" +
                    $" executor " +
                $"WHERE" +
                    $" executor.Логин = '{login.Text}' AND executor.Пароль = '{password.Text}'",
                sqlConnection);

            SqlCommand sqlCommandManager = new SqlCommand(
                $"SELECT" +
                    $" managers.id_manager, " +
                    $" managers.Логин " +
                $"FROM" +
                    $" managers " +
                $"WHERE" +
                    $" managers.Логин = '{login.Text}' AND managers.Пароль = '{password.Text}'",
                sqlConnection);

            SqlDataReader sqlDataReaderManager = sqlCommandManager.ExecuteReader();

            if (sqlDataReaderManager.HasRows)
            {
                sqlDataReaderManager.Read();
                upravCoef.managerID = sqlDataReaderManager[0].ToString();
                upravCoef.Show();//открытие формы

                zadachi.userID       = sqlDataReaderManager[0].ToString();
                zadachi.user         = sqlDataReaderManager[1].ToString();
                zadachi.managerCheck = true;
                zadachi.Show();
            }
            else
            {
                sqlDataReaderManager.Close();
                SqlDataReader sqlDataReaderExecutor = sqlCommandExecutor.ExecuteReader();
                if (sqlDataReaderExecutor.HasRows)
                {
                    sqlDataReaderExecutor.Read();
                    zadachi.userID = sqlDataReaderExecutor[0].ToString();
                    zadachi.user   = sqlDataReaderExecutor[1].ToString();
                    zadachi.Show();
                }
                else
                {
                    MessageBox.Show("Некорректные логин или пароль");
                }
            }
            sqlConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
