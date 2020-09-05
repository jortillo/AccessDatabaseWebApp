using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Data.OleDb;

namespace DataLibrary
{
    public static class DataAccess
    {
        public static List<T> LoadData<T>(string sql, string connectionString)
        {
            using (IDbConnection connection = new OleDbConnection(connectionString))
            {
                //return connection.Query<T>(sql).ToList();
                List<T> rows = connection.Query<T>(sql).ToList();

                return rows;
            }
        }
    }
}
