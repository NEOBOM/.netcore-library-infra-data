using Otakon.Library.Infra.DataAcess.MongoDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otakon.Library.Infra.DataAccess.Test.MongoDB
{
    public class PersonRepositories<Person> : DataContext<Person> where Person : class
    {
        public PersonRepositories(string connectionString, string dbName, string collectionName) : base(connectionString, dbName, collectionName)
        {
        }
    }
}
