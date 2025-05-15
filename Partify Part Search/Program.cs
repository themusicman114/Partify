using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Automatically open the browser if running on Windows
if (OperatingSystem.IsWindows())
{
    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "cmd",
            Arguments = "/C start http://localhost:5000",
            CreateNoWindow = true
        }
    };
    process.Start();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();