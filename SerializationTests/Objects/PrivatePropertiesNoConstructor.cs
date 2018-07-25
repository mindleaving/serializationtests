using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace SerializationTests.Objects
{
    public class PrivatePropertiesNoConstructor
    {
        [BsonId]
        private string Id { get; set; }
        private int Number { get; set; }
        private List<double> Values { get; set; }
        private SubClass SubClass { get; set; }

        public string GetId() => Id;
        public int GetNumber() => Number;
        public List<double> GetValues() => Values;
        public SubClass GetSubClass() => SubClass;

        public void SetId(string id) => Id = id;
        public void SetNumber(int number) => Number = number;
        public void SetValues(List<double> values) => Values = values;
        public void SetSubClass(SubClass subClass) => SubClass = subClass;
    }
}