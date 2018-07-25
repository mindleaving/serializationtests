using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SerializationTests.Objects
{
    public class NoSettersDefaultAndOneToOneConstructorWithJsonAttribute
    {
        public NoSettersDefaultAndOneToOneConstructorWithJsonAttribute() {}
        [JsonConstructor]
        public NoSettersDefaultAndOneToOneConstructorWithJsonAttribute(string id,
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
        public string Id { get; }
        public int Number { get; }
        public List<double> Values { get; }
        public SubClass SubClass { get; }
    }
}