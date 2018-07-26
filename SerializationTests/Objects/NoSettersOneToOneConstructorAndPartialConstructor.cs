using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace SerializationTests.Objects
{
    public class NoSettersOneToOneConstructorAndPartialConstructor
    {
        [JsonConstructor]
        public NoSettersOneToOneConstructorAndPartialConstructor(string id,
            int number,
            List<double> values,
            SubClass subClass)
        {
            Id = id;
            Number = number;
            Values = values;
            SubClass = subClass;
        }

        public NoSettersOneToOneConstructorAndPartialConstructor(
            int number,
            List<double> values,
            SubClass subClass)
        {
            Id = Guid.NewGuid().ToString();
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