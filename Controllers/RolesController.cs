﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectApp.Models;
using System.Web.Mvc;

namespace ProjectApp.Controllers
{
    public class RolesController : Controller
    {
        // GET: Roles
        public ActionResult Index()
        {
            return View();
        }
    }
}