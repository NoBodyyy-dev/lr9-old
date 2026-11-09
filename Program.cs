using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Lab07_RazorPages.Data;
using Microsoft.Extensions.WebEncoders;

Console.OutputEncoding = Encoding.UTF8;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IPredictionRepository, InMemoryPredictionRepository>();

builder.Services.AddRazorPages()
    .AddMvcOptions(options =>
    {
        var messages = options.ModelBindingMessageProvider;
        messages.SetAttemptedValueIsInvalidAccessor((value, _) => $"Значение «{value}» недопустимо.");
        messages.SetValueMustBeANumberAccessor(_ => "Значение должно быть целым числом.");
    });

builder.Services.Configure<WebEncoderOptions>(options =>
    options.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.All));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStatusCodePagesWithReExecute("/Status", "?code={0}");

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();

app.Run();
