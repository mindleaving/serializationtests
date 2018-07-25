using System;
using System.Collections.Generic;
using MongoDB.Driver;
using NUnit.Framework;
using SerializationTests.Objects;

namespace SerializationTests
{
    [TestFixture]
    public class MongoDbSerializationTests
    {
        private MongoClient mongoClient;
        private IMongoDatabase database;

        [OneTimeSetUp]
        public void Connect()
        {
            mongoClient = new MongoClient("mongodb://localhost");
            database = mongoClient.GetDatabase("SerializationTests");
        }

        [Test]
        public void SerializePublicSettersNoConstructor()
        {
            var obj = new PublicSettersNoConstructor
            {
                Id = Guid.NewGuid().ToString(),
                Number = 43,
                SubClass = new SubClass { Name = "Hello, world!" },
                Values = new List<double> { 0.3, -20.3, 321.2 }
            };
            var collection = database.GetCollection<PublicSettersNoConstructor>(nameof(PublicSettersNoConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializePrivateSettersNoConstructor()
        {
            var obj = new PrivateSettersNoConstructor();
            obj.Set(
                Guid.NewGuid().ToString(),
                43,
                new SubClass {Name = "Hello, world!"},
                new List<double> {0.3, -20.3, 321.2});
            var collection = database.GetCollection<PrivateSettersNoConstructor>(nameof(PrivateSettersNoConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializePrivateSettersOneToOneConstructor()
        {
            var obj = new PrivateSettersOneToOneConstructor(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<PrivateSettersOneToOneConstructor>(nameof(PrivateSettersOneToOneConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializePrivatePropertiesNoConstructor()
        {
            var obj = new PrivatePropertiesNoConstructor();
            obj.SetId(Guid.NewGuid().ToString());
            obj.SetNumber(43);
            obj.SetSubClass(new SubClass {Name = "Hello, world!"});
            obj.SetValues(new List<double> { 0.3, -20.3, 321.2 });
            var collection = database.GetCollection<PrivatePropertiesNoConstructor>(nameof(PrivatePropertiesNoConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.GetId() == obj.GetId()).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.GetId(), Is.EqualTo(obj.GetId()));
            Assert.That(deserializedObj.GetNumber(), Is.EqualTo(obj.GetNumber()));
            CollectionAssert.AreEqual(obj.GetValues(), deserializedObj.GetValues());
            Assert.That(deserializedObj.GetSubClass(), Is.Not.Null);
            Assert.That(deserializedObj.GetSubClass().Name, Is.EqualTo(obj.GetSubClass().Name));
        }

        [Test]
        public void SerializePartialSettersPartialConstructor()
        {
            var obj = new PartialSettersPartialConstructor(43, new SubClass { Name = "Hello, world!" })
            {
                Id = Guid.NewGuid().ToString(),
                Values = new List<double> { 0.3, -20.3, 321.2 }
            };
            var collection = database.GetCollection<PartialSettersPartialConstructor>(nameof(PartialSettersPartialConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializePartialSettersPartialConstructorWithBsonAttribute()
        {
            var obj = new PartialSettersPartialConstructorWithBsonAttribute(43, new SubClass { Name = "Hello, world!" })
            {
                Id = Guid.NewGuid().ToString(),
                Values = new List<double> { 0.3, -20.3, 321.2 }
            };
            var collection = database.GetCollection<PartialSettersPartialConstructorWithBsonAttribute>(nameof(PartialSettersPartialConstructorWithBsonAttribute));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersOneToOneConstructor()
        {
            var obj = new NoSettersOneToOneConstructor(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersOneToOneConstructor>(nameof(NoSettersOneToOneConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersDefaultAndOneToOneConstructorWithJsonAttribute()
        {
            var obj = new NoSettersDefaultAndOneToOneConstructorWithJsonAttribute(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersDefaultAndOneToOneConstructorWithJsonAttribute>(nameof(NoSettersDefaultAndOneToOneConstructorWithJsonAttribute));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersDefaultAndOneToOneConstructorWithBsonAttribute()
        {
            var obj = new NoSettersDefaultAndOneToOneConstructorWithBsonAttribute(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersDefaultAndOneToOneConstructorWithBsonAttribute>(nameof(NoSettersDefaultAndOneToOneConstructorWithBsonAttribute));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersDefaultAndOneToOneConstructor()
        {
            var obj = new NoSettersDefaultAndOneToOneConstructor(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersDefaultAndOneToOneConstructor>(nameof(NoSettersDefaultAndOneToOneConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializePrivateSettersDefaultAndOneToOneConstructor()
        {
            var obj = new PrivateSettersDefaultAndOneToOneConstructor(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<PrivateSettersDefaultAndOneToOneConstructor>(nameof(PrivateSettersDefaultAndOneToOneConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersPrivateOneToOneConstructor()
        {
            var obj = NoSettersPrivateOneToOneConstructor.Create(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersPrivateOneToOneConstructor>(nameof(NoSettersPrivateOneToOneConstructor));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }

        [Test]
        public void SerializeNoSettersPrivateOneToOneConstructorWithAttribute()
        {
            var obj = NoSettersPrivateOneToOneConstructorWithAttribute.Create(
                Guid.NewGuid().ToString(),
                43,
                new List<double> {0.3, -20.3, 321.2},
                new SubClass {Name = "Hello, world!"});
            var collection = database.GetCollection<NoSettersPrivateOneToOneConstructorWithAttribute>(nameof(NoSettersPrivateOneToOneConstructorWithAttribute));
            collection.InsertOne(obj);
            var deserializedObj = collection.Find(x => x.Id == obj.Id).FirstOrDefault();
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }
    }
}
