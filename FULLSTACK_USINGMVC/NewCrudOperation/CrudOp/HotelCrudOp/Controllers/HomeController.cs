using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HotelCrudOp.Models;
using BOL;
namespace HotelCrudOp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Hotel> allhote=Hotelmanger.GetallHotels();
        this.ViewBag.hotel=allhote;
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }
     public IActionResult Contact()
    {
        return View();
    }
     public IActionResult HotelList()
    {
       List<Hotel> allhotel=Hotelmanger.GetallHotels();
       this.ViewBag.Hotel=allhotel;
       return View();

    }
    [HttpGet]
     public IActionResult Insert()
    {
      
        return View();
    }
    [HttpPost]
     public IActionResult Insert(Hotel h1)
    {
       Hotelmanger.InsertHotel(h1);
        return RedirectToAction("Index");
    }

    [HttpGet]
     public IActionResult Delete(int id)
    {
       Hotelmanger.DeleteHotel(id);
        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
