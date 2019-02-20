using API.Models;
using API.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ConsumirApi consumirApi = new ConsumirApi();
            DtoExemplo meuExemplo = new DtoExemplo();
            meuExemplo.title = "titulo do meu post";
            meuExemplo.body = "corpo do meu post";

            var resultado = consumirApi.ObterRetornoDaAPI(meuExemplo);
            ViewBag.Message = resultado;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}