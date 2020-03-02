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
        UpravCoef upravCoef = new UpravCoef();
        SqlConnection sqlConnection = new SqlConnection("Data source=303-1\\NEW_MSSQLSERVER; Initial Catalog=EsoftDBZP; Integrated Security=true;");
        public Form1()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            //создание sql запроса
            SqlCommand sqlCommand = new SqlCommand(
                $"SELECT" +
                    $" executor.Логин," +
                    $" managers.Логин " +
                $"FROM" +
                    $" executor, managers " +
                $"WHERE" +
                    $" (executor.Логин = '{login.Text}' AND executor.Пароль = '{password.Text}') OR " +
                    $" (managers.Логин = '{login.Text}' AND managers.Пароль = '{password.Text}')",
                sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                upravCoef.Show();//открытие формы
            }
            else
            {
                MessageBox.Show("Некорректные логин или пароль");
            }
            sqlConnection.Close();
        }
    }
}
