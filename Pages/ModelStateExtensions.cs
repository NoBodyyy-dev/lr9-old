using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lab07_RazorPages.Pages;

public static class ModelStateExtensions
{
    public static void AddErrors(
        this ModelStateDictionary modelState, Dictionary<string, string[]> errors, string prefix)
    {
        foreach (var (field, messages) in errors)
        {
            string key = field == "body"
                ? string.Empty
                : $"{prefix}.{char.ToUpperInvariant(field[0])}{field[1..]}";

            if (modelState.TryGetValue(key, out var entry) && entry.Errors.Count > 0)
            {
                continue;
            }

            foreach (string message in messages)
            {
                modelState.AddModelError(key, message);
            }
        }
    }
}
