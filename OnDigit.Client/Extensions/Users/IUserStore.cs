using System;
using OnDigit.Core.Models.UserModel;

namespace OnDigit.Client.Extensions.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        event Action StateChanged;
    }
}
