using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsmqPublisher.Dal.Contexts
{
    public abstract class PostgresContext : IDisposable
    {
        protected NpgsqlConnection _conn { get; set; }

        public static string MainSchema
        {
            get { return ConfigurationManager.AppSettings["MainSchema"]; }
        }

        public static string SecondarySchema
        {
            get { return ConfigurationManager.AppSettings["SecondarySchema"]; }
        }

        public PostgresContext(string connString = null)
        {
            _conn = new NpgsqlConnection(connString ?? ConfigurationManager.AppSettings["ConnString"].ToString());
            _conn.Open();
        }

        ~PostgresContext()
        {
            if (_conn != null && (_conn.State == System.Data.ConnectionState.Open))
            {
                _conn.Close();
                _conn.Dispose();
            }
        }

        public void Dispose()
        {
            if (_conn != null && (_conn.State == System.Data.ConnectionState.Open))
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
    }
}