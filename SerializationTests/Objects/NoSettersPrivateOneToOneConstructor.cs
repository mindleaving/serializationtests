using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class NoSettersPrivateOneToOneConstructor
    {
        private NoSettersPrivateOneToOneConstructor(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            Id = id;
            Number = number;
            Values = values;
            SubClass = subClass;
        }

        public static NoSettersPrivateOneToOneConstructor Create(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            return new NoSettersPrivateOneToOneConstructor(id, number, values, subClass);
        }

        [BsonId]
        public string Id { get; }
        public int Number { get; }
        public List<double> Values { get; }
        public SubClass SubClass { get; }
    }
}