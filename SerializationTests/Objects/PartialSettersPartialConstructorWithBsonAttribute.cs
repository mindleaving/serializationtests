using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PartialSettersPartialConstructorWithBsonAttribute
    {
        [BsonConstructor]
        public PartialSettersPartialConstructorWithBsonAttribute(
            int number,
            SubClass subClass)
        {
            Number = number;
            SubClass = subClass;
        }

        [BsonId]
        public string Id { get; set; }
        public int Number { get; private set; }
        public List<double> Values { get; set; }
        public SubClass SubClass { get; private set; }
    }
}