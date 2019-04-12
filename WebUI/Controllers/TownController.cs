using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class TownController : Controller
	{
		ITownService _service; public TownController(ITownService _service) { this._service = _service; }

		public IActionResult InsertOrUpdate(Town postModel)
		{
			var result = _service.InsertOrUpdate(postModel);
			return Json(result);
		}

		public IActionResult InsertOrUpdatePage()
		{
			return View();
		}

		public IActionResult Get(int id)
		{
			var result = _service.Find(id);
			return Json(result);
		}

		public IActionResult GetPage(int CityId)
		{
			var result = _service.Where(o=>o.CityId == CityId);
			return Json(result);
		}

		public IActionResult Delete(int id)
		{
			var result = _service.Delete(id);
			_service.SaveChanges();
			return Json(result);
		}


		public IActionResult Index()
		{
			return View();
		}

	}
}