using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PrivateSettersNoConstructor
    {
        [BsonId]
        public string Id { get; private set; }
        public int Number { get; private set; }
        public List<double> Values { get; private set; }
        public SubClass SubClass { get; private set; }

        public void Set(string id, int number, SubClass subClass, List<double> values)
        {
            Id = id;
            Number = number;
            SubClass = subClass;
            Values = values;
        }
    }
}