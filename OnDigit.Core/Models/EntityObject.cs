using System;

namespace OnDigit.Core.Models
{
    public class EntityObject : IDisposable
    {
        public EntityObject()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
    }
}
