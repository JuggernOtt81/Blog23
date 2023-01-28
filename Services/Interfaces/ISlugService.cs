using Blog23.ViewModels;
using Blog23.Services;
using Blog23.Services.Interfaces;

namespace Blog23.Services;

public interface ISlugService
{
    string UrlFriendly(string title);
    bool IsUnique(string slug);
}
