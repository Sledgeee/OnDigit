﻿using System;
using OnDigit.Core.Models.EditionModel;
using OnDigit.Core.Models.ReviewModel;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Core.Extensions
{
    public static class NullChecking
    {
        public static void UserNullChecking(this User user)
        {
            if (user is null)
                throw new ArgumentNullException($"{nameof(user)} not found"); 
        }

        public static void ReviewNullChecking(this Review review)
        {
            if (review is null)
                throw new ArgumentNullException($"{nameof(review)} not found");
        }

        public static void EditionNullChecking(this Edition edition)
        {
            if (edition is null)
                throw new ArgumentNullException($"{nameof(edition)} not found");
        }
    }
}
