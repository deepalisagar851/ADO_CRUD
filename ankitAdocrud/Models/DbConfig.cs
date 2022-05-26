using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace AdoMvc.Models
{
    public class DbConfig
    {
        public SqlConnection sql { get; set; }
        public DbConfig()
        {
            string cnn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            sql = new SqlConnection(cnn);
        }
    }
}