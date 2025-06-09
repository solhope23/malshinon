using System;
using MySql.Data.MySqlClient;

public class DAL
{
    private string connStr;
    private MySqlConnection DataBase;

    public DAL(string server = "localhost", string username = "root", string password = "", string database = "malshinon")
    {
        connStr = $"server={server};username={username};password={password};database={database}";

        this.DataBase = new MySqlConnection(connStr);

        //this.TestConnection();
    }

}