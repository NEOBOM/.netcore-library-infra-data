using Library.Infra.DataAcess.ConsoleTest.Entity;
using Library.Infra.DataAcess.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.DataAcess.ConsoleTest.MongoDB
{
    public class CustumerRepository : DataContext<Custumer>
    {
        public CustumerRepository(IMongoClient mongoClient) : base(mongoClient, "mongotest", "custumer")
        {

        }

        public void Inset(Custumer custumer)
        {
            InsertOne(custumer);
        }

        public void Update(Custumer custumer)
        {
            Update(custumer);
        }

        public void Watch(Action<Custumer> action)
        {
            ChangeStreamsSync(ChangeStreamOperationType.Update, action);
        }
    }
}
