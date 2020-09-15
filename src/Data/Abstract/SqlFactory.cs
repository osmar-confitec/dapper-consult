using Domain.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Data.Abstract
{
    public class SqlFactory : AbstractFactoryData
    {
        public SqlFactory(IConfiguration configuration) : base(configuration)
        {


        }

        protected override DbConnection CriarConeccao()
        {
            return new SqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
        }
    }
}
