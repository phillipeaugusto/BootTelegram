using System;
using System.Collections.Generic;

namespace BootTelegram.Domain.Entities
{
    public class Group: Entity
    {
        public Group() { }

        public Group(Guid id, string description, long codeIndentifierGroup, long codeIndentifierGroupDestiny, char finalShippingType)
        {
            Description = description;
            CodeIndentifierGroup = codeIndentifierGroup;
            CodeIndentifierGroupDestiny = codeIndentifierGroupDestiny;
            FinalShippingType = finalShippingType;
            Id = id;
        }

        public string Description { get; set; }
        public long CodeIndentifierGroup { get; set; }
        public long CodeIndentifierGroupDestiny { get; set; }
        public IEnumerable<Reading> Reading { get; set;  }
        public char FinalShippingType { get; set; }
    }
}