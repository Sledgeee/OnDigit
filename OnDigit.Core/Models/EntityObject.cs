using System;

namespace OnDigit.Core.Models
{
    public class EntityObject : IDisposable
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public virtual void Dispose()
        {
            GC.Collect();
        }
    }
}
