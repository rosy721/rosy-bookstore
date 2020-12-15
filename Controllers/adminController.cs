﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using rosy_bookstore;

namespace rosy_bookstore.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user usr)
        {
            //get username and password from the user
            //check it against the databse user table
            Rozy_bookshopEntities2 dbObject = new Rozy_bookshopEntities2();
            var checkUser = dbObject.users.Where(l => l.u_name.Equals(usr.u_name) && l.u_password.Equals(usr.u_password)).FirstOrDefault();
            if (checkUser != null)
            {
                var loggeduser = dbObject.users.Where(l => l.u_name.Equals(usr.u_name)).FirstOrDefault();
                Session["u_name"] = loggeduser.u_name.ToString();
                Session["u_id"] = loggeduser.u_id.ToString();
                Session["u_type"] = loggeduser.u_type.ToString();


                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View();
        }
        public ActionResult DashBoard()
        {
            return View();
        }
    }
}