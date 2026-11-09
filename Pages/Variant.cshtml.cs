using Lab07_RazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab07_RazorPages.Pages;

public class VariantModel : PageModel
{
    [BindProperty]
    public int? StudentId { get; set; } = StudentInfo.Id;

    [BindProperty]
    public int? Total { get; set; } = StudentInfo.TotalVariants;

    public int? Variant { get; private set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        if (IsBound(nameof(StudentId)) && StudentId is null or < 0)
        {
            ModelState.AddModelError(nameof(StudentId),
                "Номер зачётной книжки должен быть целым неотрицательным числом.");
        }

        if (IsBound(nameof(Total)) && Total is null or <= 0)
        {
            ModelState.AddModelError(nameof(Total),
                "Количество вариантов должно быть целым числом больше нуля.");
        }

        if (ModelState.IsValid)
        {
            Variant = StudentInfo.CalculateVariant(StudentId!.Value, Total!.Value);
        }
    }

    private bool IsBound(string key) =>
        ModelState[key] is not { Errors.Count: > 0 };
}
