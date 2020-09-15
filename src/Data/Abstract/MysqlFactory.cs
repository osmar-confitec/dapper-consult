using Domain.Abstract;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data.Abstract
{
    public class MysqlFactory : AbstractFactoryData
    {
        public MysqlFactory(IConfiguration configuration) : base(configuration)
        {
        }

        protected override DbConnection CriarConeccao()
        {
            return new MySqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
        }
    }
}
