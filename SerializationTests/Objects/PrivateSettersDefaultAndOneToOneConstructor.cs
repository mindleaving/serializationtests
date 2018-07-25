using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PrivateSettersDefaultAndOneToOneConstructor
    {
        public PrivateSettersDefaultAndOneToOneConstructor() {}
        public PrivateSettersDefaultAndOneToOneConstructor(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            Id = id;
            Number = number;
            Values = values;
            SubClass = subClass;
        }

        [BsonId]
        public string Id { get; private set; }
        public int Number { get; private set; }
        public List<double> Values { get; private set; }
        public SubClass SubClass { get; private set; }
    }
}