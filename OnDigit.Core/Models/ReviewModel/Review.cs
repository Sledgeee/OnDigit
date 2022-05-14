using System;
using OnDigit.Core.Models.BookModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Models.ReviewModel
{
    public sealed class Review : EntityObject
    {
        public string Text { get; set; }
        public int Stars { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }

        public override void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
            base.Dispose();
        }
    }
}
