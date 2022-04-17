using System;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.UserModel;
using OnDigit.Core.Interfaces;

namespace OnDigit.Core.Models.ReviewModel
{
    public class Review : EntityObject, IBaseEntity
    {
        public string Text { get; set; }
        public int Stars { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string EditionId { get; set; }
        public Edition Edition { get; set; }

        public override void Dispose()
        {
            GC.Collect();
            base.Dispose();
        }
    }
}
