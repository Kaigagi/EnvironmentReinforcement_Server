﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Service;

namespace Server.Controllers
{
    public class UserController : Controller
    {
        UserService userService = new UserService();
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Validate/5
        public ActionResult Validate(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];

            try
            {

            } 
            catch
            {
                
            }

            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult AllVolunteer() 
        {
            return View();
        }

        public ActionResult AllCooperator()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
