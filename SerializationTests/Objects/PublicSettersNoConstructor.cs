using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PublicSettersNoConstructor
    {
        [BsonId]
        public string Id { get; set; }
        public int Number { get; set; }
        public List<double> Values { get; set; }
        public SubClass SubClass { get; set; }
    }
}
