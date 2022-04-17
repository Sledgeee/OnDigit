using System;
using OnDigit.Core.Interfaces;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.SessionModel
{
    public class Session : EntityObject, IBaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string MACHINE_KEY { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public bool IsCanceledInAdvance { get; set; }

        public override void Dispose()
        {
            GC.Collect();
        }
    }
}