using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Domain.Interfaces
{
  public  interface IConn
    {
        public DbConnection GetCon  { get;  }
    }
}
