using System;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces;

namespace OnDigit.Core.Models.UserLoginHistoryModel
{
    public class UserLoginHistory : EntityObject
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime DateLogined { get; set; }

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}
