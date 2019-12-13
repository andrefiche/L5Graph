using System;
using System.Collections.Generic;
using Dapper;
using graphConnect.Models;
using MySql.Data.MySqlClient;

namespace graphConnect.Repository
{
    public class AccessLogsRepository : IAccessLogsRepository
    {
        private readonly string _connectionString;

        public AccessLogsRepository(string connectionString)
        {
            _connectionString = connectionString;  
        }

        public IEnumerable<AccessLogs> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<AccessLogs>("SELECT Id, TenantID, Token, DataHora FROM AccessLogs ORDER BY Id ASC");
            }
        }
    }
}
