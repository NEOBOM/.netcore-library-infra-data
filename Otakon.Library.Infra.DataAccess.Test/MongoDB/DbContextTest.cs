using Otakon.Library.Infra.DataAccess.Test.Entities;
using System;
using System.Linq;
using Xunit;

namespace Otakon.Library.Infra.DataAccess.Test.MongoDB
{
    public class DbContextTest
    {
        private readonly PersonRepositories<Person> _db = null;

        public DbContextTest()
        {
            _db = new PersonRepositories<Person>("mongodb://192.168.50.202:27017", "mongo_dev", "Person");
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
            var input = new Person { Id = 3, Age = 30, Name = "Ciclana" };

            Assert.True(_db.Update(c => c.Id.Equals(1), input));
        }

        [Fact]
        public void Delete_One_Item()
        {
            Assert.True(_db.Delete(c => c.Id.Equals(3)));
        }

    }
}
