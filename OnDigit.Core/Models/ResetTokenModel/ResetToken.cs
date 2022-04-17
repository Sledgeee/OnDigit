﻿using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces;
using System;

namespace OnDigit.Core.Models.ResetTokenModel
{
    public class ResetToken : EntityObject, IBaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public string Token { get; set; }

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}