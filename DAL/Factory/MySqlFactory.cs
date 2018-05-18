using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Factory
{
    public class MySqlFactory : AbstractFactory, IDisposable
    {
        private IDbConnection _conn;
        public override IDbConnection DataBaseConnection(string sqlConnectionString)
        {
            _conn = new MySqlConnection(sqlConnectionString);
            _conn.Open();
            return _conn;
        }

        public void Dispose()
        {
            if (_conn.State == ConnectionState.Open)
            {
                _conn.Close();
            }
        }
    }
}
