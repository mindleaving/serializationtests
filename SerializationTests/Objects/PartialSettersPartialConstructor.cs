using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PartialSettersPartialConstructor
    {
        public PartialSettersPartialConstructor(
            int number,
            SubClass subClass)
        {
            Number = number;
            SubClass = subClass;
        }

        [BsonId]
        public string Id { get; set; }
        public int Number { get; }
        public List<double> Values { get; set; }
        public SubClass SubClass { get; }
    }
}