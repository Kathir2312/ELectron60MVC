using ElectronNET.API;
using ElectronNET.API.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//ELECTRON
builder.Services.AddElectron();
builder.WebHost.UseElectron(args);
if (HybridSupport.IsElectronActive)
{
    // Open the Electron-Window here
    Task.Run(async () => {
        var browserWindowOptions = new BrowserWindowOptions
        {
            AutoHideMenuBar = true
        };

        //var browserWindow = await Electron.WindowManager.CreateWindowAsync(browserWindowOptions);
        var window = await Electron.WindowManager.CreateWindowAsync(browserWindowOptions);
        window.OnClosed += () => {
            Electron.App.Quit();
        };
    });
}
//./ELECTRON

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//if (app.Environment.IsProduction())
//{
//    app.UseHttpsRedirection();
//}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
