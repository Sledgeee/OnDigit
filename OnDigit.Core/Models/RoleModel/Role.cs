using System.Collections.Generic;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces;
using System;

namespace OnDigit.Core.Models.RoleModel
{
    public class Role : IBaseEntity, IDisposable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
