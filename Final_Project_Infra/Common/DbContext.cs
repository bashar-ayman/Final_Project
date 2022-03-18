using Final_Project_Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Final_Project_Infra.Common
{
   public class DbContext:IDbContext
    {
        private DbConnection dbConnection;

        private readonly IConfiguration configuration;


        public DbContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbConnection Connection
        {
            get
            {
                if (dbConnection == null)
                {
                    dbConnection = new OracleConnection(configuration["ConnectionStrings:DBConnectionString"]);
                }

                else if (dbConnection.State != ConnectionState.Open)
                {
                    dbConnection.Open();
                }
                return dbConnection;
            }

        }
    }

}

