using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace randompasscode.Controllers
{
    public class RandomController : Controller
    {

        [HttpGet]
        [Route("Home")]

        public IActionResult Home()
        {
            if( HttpContext.Session.GetInt32("Count") == null) 
            {
                HttpContext.Session.SetInt32( "Count", 1);
            } 
            else 
            {
                HttpContext.Session.SetInt32("Count", (int)HttpContext.Session.GetInt32("Count") + 1);
            }

           string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
           char[] randomString = new char[14];
           System.Random rand = new System.Random();
           for (int i = 0; i < randomString.Length; i++) 
           {
               randomString[i] = chars[rand.Next(chars.Length)];
           }
           string finalString = new string(randomString);

           ViewBag.Count = HttpContext.Session.GetInt32("Count");
           ViewBag.Passcode = finalString;
           return View();
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Home");
        }
    }
}