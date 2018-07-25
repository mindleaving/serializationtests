using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SerializationTests.Objects
{
    public class NoSettersPrivateOneToOneConstructorWithAttribute
    {
        [JsonConstructor]
        [BsonConstructor]
        private NoSettersPrivateOneToOneConstructorWithAttribute(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            Id = id;
            Number = number;
            Values = values;
            SubClass = subClass;
        }

        public static NoSettersPrivateOneToOneConstructorWithAttribute Create(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            return new NoSettersPrivateOneToOneConstructorWithAttribute(id, number, values, subClass);
        }

        [BsonId]
        public string Id { get; }
        public int Number { get; }
        public List<double> Values { get; }
        public SubClass SubClass { get; }
    }
}