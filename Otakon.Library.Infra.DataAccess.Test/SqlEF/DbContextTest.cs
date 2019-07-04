using Microsoft.Extensions.Configuration;
using Otakon.Library.Infra.DataAccess.Test.Entities;
using System;
using System.Linq;
using Xunit;

namespace Otakon.Library.Infra.DataAccess.Test.SqlEF
{
    public class DbContextTest
    {
        private readonly PersonRepositories<Person> _db = null;

        public DbContextTest(IConfiguration configuration)
        {
            _db = new PersonRepositories<Person>(configuration);
        }

        [Fact]
        public void Find_One_Item()
        {
            var obj = _db.Find(c => c.Id.Equals(1));

            Assert.NotNull(obj);
        }

        [Fact]
        public void Select_Itens_By_Age_Condition()
        {
            var list = _db.FindMany(c => c.Age > 20);

            Assert.NotNull(list);
            Assert.True(list.Count() > 0);
        }

        [Fact]
        public void Insert_One_Item()
        {
            var input = new Person { Id = 3, Age = 23, Name = "Ciclana" };

            _db.Insert(input);

            Assert.NotNull(_db.Find(p => p.Id == input.Id));
        }


        [Fact]
        public void Update_One_Item()
        {
            var input = new Person { Id = 3, Age = 25, Name = "Ciclana" };

            _db.Update(input);

            Assert.NotNull(_db.Find(p => p.Id == input.Id && p.Age == input.Age));
        }

        [Fact]
        public void Delete_One_Item()
        {
            var input = new Person { Id = 3, Age = 25, Name = "Ciclana" };

            _db.Delete(input);

            Assert.Null(_db.Find(p => p.Id == input.Id));
        }

    }
}
