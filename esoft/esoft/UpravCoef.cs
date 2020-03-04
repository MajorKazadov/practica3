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
    public partial class UpravCoef : Form
    {
        SqlConnection sqlConnection = new SqlConnection("Data source=303-1\\NEW_MSSQLSERVER; Initial Catalog=EsoftDBZP; Integrated Security=true;");
        public string managerID;

        public UpravCoef()
        {
            InitializeComponent();
        }

        private void ReadDataFromBD()
        {
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(
               $"SELECT" +
                   $" id_coefficient," +
                   $" Junior_мин_ЗП," +
                   $" Middle_мин_ЗП," +
                   $" Senior_мин_ЗП," +
                   $" Коэффициент_для_Анализ_и_проектирование," +
                   $" Коэффициент_для_Установка_оборудования," +
                   $" Коэффициент_для_Техническое_обслуживание_и_сопровождение," +
                   $" Коэффициент_времени," +
                   $" Коэффициент_сложности," +
                   $" Коэффициент_для_перевода_в_денежный_эквивалент " +
               $"FROM" +
                   $" coefficient ",
               sqlConnection);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if(sqlDataReader[0].ToString() == managerID)
                {
                    Junior.Text = sqlDataReader[1].ToString();
                    Middle.Text = sqlDataReader[2].ToString();
                    Senior.Text = sqlDataReader[3].ToString();
                    AnalyzAndProekt.Text = sqlDataReader[4].ToString();
                    UstanovkaOborud.Text = sqlDataReader[5].ToString();
                    TehobsluzAndSoprovoz.Text = sqlDataReader[6].ToString();
                    TimeK.Text = sqlDataReader[7].ToString();
                    SlozK.Text = sqlDataReader[8].ToString();
                    PerevToDenzEcvival.Text = sqlDataReader[9].ToString();
                }
            }

            sqlConnection.Close();
        }

        private bool CheckUpdate(string checkData)
        {
            try
            {
                float.Parse(checkData);
            }
            catch
            {
                MessageBox.Show("Ошибка, недопустимое значение " + checkData);
                return false;
            }
            return true;
        }

        private bool CheckHaraktVipRab(string checkData)
        {
            try
            {
                if (float.Parse(checkData) > 1 || float.Parse(checkData) < 0)
                {
                    MessageBox.Show("Ошибка, недопустимое значение " + checkData);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, недопустимое значение " + checkData);
                return false;
            }
            return true;
        }

        private bool CheckMoney(string checkData)
        {
            try
            {
                if (float.Parse(checkData) < 0)
                {
                    MessageBox.Show("Ошибка, недопустимое значение " + checkData);
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, недопустимое значение " + checkData);
                return false;
            }
            return true;
        }

        private void Update_Button_Click(object sender, EventArgs e)
        {
            if (!CheckMoney(Junior.Text))
                return;
            if (!CheckMoney(Middle.Text))
                return;
            if (!CheckMoney(Senior.Text))
                return;
            if (!CheckHaraktVipRab(AnalyzAndProekt.Text))
                return;
            if (!CheckHaraktVipRab(UstanovkaOborud.Text))
                return;
            if (!CheckHaraktVipRab(TehobsluzAndSoprovoz.Text))
                return;
            if (!CheckUpdate(TimeK.Text))
                return;
            if (!CheckUpdate(SlozK.Text))
                return;
            if (!CheckUpdate(PerevToDenzEcvival.Text))
                return;

            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(
                $"UPDATE" +
                    $" coefficient " +
                $"SET" +
                    $" Junior_мин_ЗП = {Junior.Text.Replace(",", ".")}," +
                    $" Middle_мин_ЗП = {Middle.Text.Replace(",", ".")}," +
                    $" Senior_мин_ЗП = {Senior.Text.Replace(",", ".")}," +
                    $" Коэффициент_для_Анализ_и_проектирование = {AnalyzAndProekt.Text.Replace(",", ".")}," +
                    $" Коэффициент_для_Установка_оборудования = {UstanovkaOborud.Text.Replace(",", ".")}," +
                    $" Коэффициент_для_Техническое_обслуживание_и_сопровождение = {TehobsluzAndSoprovoz.Text.Replace(",", ".")}," +
                    $" Коэффициент_времени = {TimeK.Text.Replace(",", ".")}," +
                    $" Коэффициент_сложности = {SlozK.Text.Replace(",", ".")}," +
                    $" Коэффициент_для_перевода_в_денежный_эквивалент = {PerevToDenzEcvival.Text.Replace(",", ".")} " +
                $"WHERE" +
                    $" id_coefficient = {managerID}",
                sqlConnection);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            ReadDataFromBD();
        }

        private void Close_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpravCoef_Load(object sender, EventArgs e)
        {
            ReadDataFromBD();
        }
    }
}
