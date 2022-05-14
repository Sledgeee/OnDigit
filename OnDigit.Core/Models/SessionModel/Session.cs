using System;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.SessionModel
{
    public sealed class Session : EntityObject
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string MACHINE_KEY { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCanceledInAdvance { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}