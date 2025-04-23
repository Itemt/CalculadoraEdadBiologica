using EdadBiologicaCalculadora.Services;

var builder = WebApplication.CreateBuilder(args);

// Add essential services
builder.Services.AddRazorPages();
builder.Services.AddSingleton<HistorialService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

app.Run();
