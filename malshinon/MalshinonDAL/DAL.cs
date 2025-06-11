using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using Mysqlx.Crud;
using MySqlX.XDevAPI.CRUD;
using static System.Net.Mime.MediaTypeNames;

namespace malshinon
{
    internal class DAL
    {
        private string connStr;
        private MySqlConnection DataBase;

        public DAL(string server = "localhost", string username = "root", string password = "")
        {
            connStr = $"server={server};username={username};password={password};database=malshinon";

            this.DataBase = new MySqlConnection(connStr);
        }


        public MySqlDataReader sqlForGetPersonByName(string firstName, string lastName)
        {
            string query = "SELECT * " +
                           "FROM `people` " +
                           "WHERE first_name = @firstName AND last_name = @lastName";
            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);

            MySqlDataReader Reader = cmd.ExecuteReader();

            return Reader;
        }

        public MySqlDataReader sqlForGetPersonBySecretCode(string secretCode)
        {
            string query = "SELECT * " +
                           "FROM `people` " +
                           "WHERE secret_code = @secretCode";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@secretCode", secretCode);

            MySqlDataReader Reader = cmd.ExecuteReader();

            return Reader;
        }

        public void InsertNewPerson(string firstName, string lastName, string secretCode, string type)
        {
            string query = "INSERT INTO people (first_name, last_name, secret_code, type) " +
                           "VALUES (@first_name, @last_name, @secret_code, @type)";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@first_name", firstName);
            cmd.Parameters.AddWithValue("@last_name", lastName);
            cmd.Parameters.AddWithValue("@secret_code", secretCode);
            cmd.Parameters.AddWithValue("@type", type);

            cmd.ExecuteNonQuery();
        }


        public void InsertIntelReport(int ReporterId, int TargetId, string text)
        {
            string query = "INSERT INTO intelreports (reporter_id, target_id, text) " +
                           "VALUES (@reporter_id, @target_id, @text)";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@reporter_id", ReporterId);
            cmd.Parameters.AddWithValue("@target_id", TargetId);
            cmd.Parameters.AddWithValue("@text", text);

            cmd.ExecuteNonQuery();
        }



        public void UpdateReportCount(int id)
        {
            string query = "UPDATE people " +
                           "SET num_reports = num_reports + 1 " +
                           "WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public void UpdateMentionCount(int id)
        {
            string query = "UPDATE people " +
                           "SET num_mentions = num_mentions + 1 " +
                           "WHERE id = @id";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }



        public MySqlDataReader sqlForGetReporterStats(int id)
        {
            string query = "SELECT AVG(CHAR_LENGTH(text)) AS avg_text, " +
                                   "COUNT(*) AS row_count " +
                           "FROM `intelreports` " +
                           "WHERE reporter_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader Reader = cmd.ExecuteReader();

            return Reader;
        }

        public MySqlDataReader sqlForGetTargetStats(int id)
        {
            string query = "SELECT timestamp " +
                           "FROM `intelreports` " +
                           "WHERE target_id = @id";

            MySqlCommand cmd = new MySqlCommand(query, this.DataBase);

            cmd.Parameters.AddWithValue("@id", id);

            MySqlDataReader Reader = cmd.ExecuteReader();

            return Reader;
        }

    }
}
