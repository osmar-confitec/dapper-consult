using Domain.Abstract;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Data.Abstract
{
    public class FireBirdFactory : AbstractFactoryData
    {
        public FireBirdFactory(IConfiguration configuration) : base(configuration)
        {
        }

        protected override DbConnection CriarConeccao()
        {
            return new FbConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value);
        }
    }
}
