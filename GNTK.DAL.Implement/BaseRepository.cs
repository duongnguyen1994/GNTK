using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GNTK.DAL.Implement
{
    public class BaseRepository
    {
        private readonly IConfiguration config;
        protected IDbConnection connection;

        public BaseRepository(IConfiguration config)
        {
            this.config = config;
            connection = new SqlConnection(this.config.GetConnectionString("DbConnection"));
        }
    }
}
