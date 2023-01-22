using ELectron60MVC.Models;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ELectron60MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public void CloseWindow()
        {
           // Electron.WindowManager.
        }
        public IActionResult Index()
        {
            ViewData["userN"]= System.Environment.UserName;
            string viewPath = $"https://google.com";
            //string viewPath = $"http://localhost:{BridgeSettings.WebPort}/Home/Privacy";
            //Electron.App.SetLoginItemSettings(new LoginSettings() { })
            //Electron.ReadAuth();
            Electron.IpcMain.On("new-window", async (args) =>
            {
                //await Electron.WindowManager.CreateWindowAsync(viewPath);
                //await ElectronNET.API.WindowManager.CreateWindowAsync()
                //var mainWindow = Electron.WindowManager.BrowserWindows.FirstOrDefault();
                //Electron.Menu.ContextMenuPopup(mainWindow);
                var options = new BrowserWindowOptions
                {
                    Frame = false
                };
                await Electron.WindowManager.CreateWindowAsync(options, viewPath);
            });


            return View();
        }

        //[HttpPost]
        //public void Post()
        //{
        //    string viewPath = $"http://localhost:{BridgeSettings.WebPort}/Home/Privacy";
        //    Electron.IpcMain.On("my-channel", async (args) => {
        //        await Electron.WindowManager.CreateWindowAsync(viewPath);
        //        // Handle the message here
        //        //var data = args[0] as string;
        //        //var data = args[0] as dynamic;
        //        // do something with data
        //    });
        //}

        //[HttpPost]
        //public void Post()
        //{
        //    string viewPath = $"http://localhost:{BridgeSettings.WebPort}/Home/Privacy";

        //    Electron.IpcMain.On("new-window", async (args) =>
        //    {
        //        await Electron.WindowManager.CreateWindowAsync(viewPath);
        //        //await ElectronNET.API.WindowManager.CreateWindowAsync()
        //        //var mainWindow = Electron.WindowManager.BrowserWindows.FirstOrDefault();
        //        //Electron.Menu.ContextMenuPopup(mainWindow);
        //    });
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DemoWindow()
        {
            return View();
        }
    }
}