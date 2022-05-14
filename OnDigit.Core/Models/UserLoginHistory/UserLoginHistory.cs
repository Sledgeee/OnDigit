using System;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.UserLoginHistoryModel
{
    public sealed class UserLoginHistory : EntityObject
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime DateLogined { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}
