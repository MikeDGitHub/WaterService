using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.Factory
{
    public abstract class AbstractFactory
    {
        public abstract IDbConnection DataBaseConnection(string sqlConnectionString);
    }
}
