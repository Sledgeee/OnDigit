using System;

namespace OnDigit.Core.Models
{
    public class EntityObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }
}
