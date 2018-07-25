using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using SerializationTests.Objects;

namespace SerializationTests
{
    [TestFixture]
    public class JsonSerializationTests
    {
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PublicSettersNoConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PrivateSettersNoConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PrivateSettersOneToOneConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PrivatePropertiesNoConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PartialSettersPartialConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PartialSettersPartialConstructorWithBsonAttribute>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersOneToOneConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersDefaultAndOneToOneConstructorWithJsonAttribute>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersDefaultAndOneToOneConstructorWithBsonAttribute>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersDefaultAndOneToOneConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<PrivateSettersDefaultAndOneToOneConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersPrivateOneToOneConstructor>(json);
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
            var json = JsonConvert.SerializeObject(obj);
            var deserializedObj = JsonConvert.DeserializeObject<NoSettersPrivateOneToOneConstructorWithAttribute>(json);
            Assert.That(deserializedObj, Is.Not.Null);
            Assert.That(deserializedObj.Id, Is.EqualTo(obj.Id));
            Assert.That(deserializedObj.Number, Is.EqualTo(obj.Number));
            CollectionAssert.AreEqual(obj.Values, deserializedObj.Values);
            Assert.That(deserializedObj.SubClass, Is.Not.Null);
            Assert.That(deserializedObj.SubClass.Name, Is.EqualTo(obj.SubClass.Name));
        }
    }
}
