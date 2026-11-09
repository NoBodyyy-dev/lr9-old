using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab07_RazorPages.Pages;

public class HelloModel : PageModel
{
    [BindProperty(Name = "name", SupportsGet = true)]
    public string? UserName { get; set; }

    public string HelloMessage { get; private set; } = string.Empty;

    public void OnGet()
    {
        HelloMessage = !string.IsNullOrWhiteSpace(UserName)
            ? $"Здравствуйте, {UserName.Trim()}!"
            : "Пожалуйста, введите ваше имя через URL: /Hello?name=ВашеИмя";
    }
}
