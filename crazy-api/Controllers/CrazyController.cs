using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crazy_api.Service;

namespace crazy_api.Controllers
{
    [ApiController]
    [Route("/api/Course")]
    public class CrazyController : Controller
    {
        private CrazyService _course_service;

        public CrazyController(CrazyService _svc)
        {
            _course_service = _svc;
        }

        [HttpGet]
        [Route("GetPersons")]
        public IActionResult GetPerson()
        {
            return Ok(_course_service.GetPerson());
        }
        //[HttpPost]
        //public IActionResult PostPerson(Models.CrazyApi model)
        //{
        //    return Ok(_course_service.PostPerson(model));
        //}
    }
}
