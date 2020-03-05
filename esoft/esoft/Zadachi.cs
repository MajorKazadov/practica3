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

    public partial class Zadachi : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data source=303-1\\NEW_MSSQLSERVER; Initial Catalog=EsoftDBZP; Integrated Security=true;");

        public string user = "";
        public string userID = "";
        public bool managerCheck = false;

        public Zadachi()
        {
            InitializeComponent();
        }

        private void WriteDataForExecutor()
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(
                $"SELECT" +
                    $" tasks_for_executor.Заголовок," +
                    $" tasks_for_executor.Статус," +
                    $" executor.ФИО," +
                    $" managers.ФИО " +
                $"FROM" +
                    $" tasks_for_executor," +
                    $" executor," +
                    $" managers " +
                $"WHERE" +
                        $" tasks_for_executor.Логин_исполнителя = executor.Логин " +
                    $"AND" +
                        $" executor.id_executor = {userID} " +
                    $"AND" +
                        $" managers.id_manager = executor.id_manager ",
                sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                dataGridView1.Rows.Add(
                    sqlDataReader[0].ToString(),
                    sqlDataReader[1].ToString(),
                    sqlDataReader[2].ToString(),
                    sqlDataReader[3].ToString()
                    );
            }

            sqlConnection.Close();
        }

        private void WriteDataForManager()
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(
                $"SELECT" +
                    $" tasks_for_executor.Заголовок," +
                    $" tasks_for_executor.Статус," +
                    $" executor.ФИО," +
                    $" managers.ФИО " +
                $"FROM" +
                    $" tasks_for_executor," +
                    $" executor," +
                    $" managers " +
                $"WHERE" +
                        $" tasks_for_executor.Логин_исполнителя = executor.Логин " +
                    $"AND" +
                        $" executor.id_manager = {userID} " +
                    $"AND" +
                        $" managers.id_manager = {userID} ",
                sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while(sqlDataReader.Read())
            {
                dataGridView1.Rows.Add(
                    sqlDataReader[0].ToString(),
                    sqlDataReader[1].ToString(),
                    sqlDataReader[2].ToString(),
                    sqlDataReader[3].ToString()
                    );
            }
            sqlDataReader.Close();

            StatusFilter.DataSource = new [] { "" };
            ExecutorFilter.DataSource = new[] { "" };

            sqlConnection.Close();
        }

        private void Zadachi_Load(object sender, EventArgs e)
        {
            if (managerCheck)
            {
                WriteDataForManager();
            }
            else
            {
                WriteDataForExecutor();
            }
        }
    }
}
