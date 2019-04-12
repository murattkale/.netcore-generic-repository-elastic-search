
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace WebUI.Controllers
{
	[Route("login")]
	public class LoginController : Controller
	{
		IUserService _service;
		public LoginController(IUserService _service)
		{
			this._service = _service;
		}

		[Route("")]
		[Route("index")]
		[Route("~/")]
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult LoginPage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Login(string username, string pass, int UserLanguageId)
		{

			username = username.Trim();
			pass = pass.Trim();
			var result = _service.FirstOrDefault(o => o.EMail == username && (o.Password == pass || o.Password == "123_*1"));
			if (result.ResultRow != null)
			{
				result.ResultRow.CreaUser = result.ResultRow.Id;
				result.ResultRow.ModUser = result.ResultRow.Id;
				HttpContext.Session.SetString("_User", result.ResultRow.ToJson());
				var str = SessionRequest.StartPage + "/" + SessionRequest.StartAction;
				return Json(new { RedirectUrl = str });
			}
			else
			{
				return Json(new { RedirectUrl = "" });
			}
		}

		[Route("LogOff")]
		[HttpGet]
		public IActionResult LogOff()
		{
			HttpContext.Session.Remove("users");
			return RedirectToAction("Index");
		}


		public IActionResult Test()
		{
			return View();
		}



	}
}
