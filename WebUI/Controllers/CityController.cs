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
	public class CityController : Controller
	{
		ICityService _service; public CityController(ICityService _service) { this._service = _service; }

		public IActionResult InsertOrUpdate(City postModel)
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

		public IActionResult GetPage()
		{
			var result = _service.Where(null);
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