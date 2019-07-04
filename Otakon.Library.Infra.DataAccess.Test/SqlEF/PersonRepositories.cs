using Microsoft.Extensions.Configuration;
using Otakon.Library.Infra.DataAcess.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otakon.Library.Infra.DataAccess.Test.SqlEF
{
    public class PersonRepositories<Person> : Repository<Person> where Person : class
    {
        public PersonRepositories(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
