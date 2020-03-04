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
            sqlConnection.Open();
            //создание sql запроса
            SqlCommand sqlCommandExecutor = new SqlCommand(
                $"SELECT" +
                    $" executor.id_executor " +
                $"FROM" +
                    $" executor " +
                $"WHERE" +
                    $" executor.Логин = '{login.Text}' AND executor.Пароль = '{password.Text}'",
                sqlConnection);

            SqlCommand sqlCommandManager = new SqlCommand(
                $"SELECT" +
                    $" managers.id_manager " +
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
            }
            else
            {
                sqlDataReaderManager.Close();
                SqlDataReader sqlDataReaderExecutor = sqlCommandExecutor.ExecuteReader();
                if (sqlDataReaderExecutor.HasRows)
                {

                }
                else
                {
                    MessageBox.Show("Некорректные логин или пароль");
                }
            }
            sqlConnection.Close();
        }
    }
}
