﻿using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class NoSettersOneToOneConstructor
    {
        public NoSettersOneToOneConstructor(string id,
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