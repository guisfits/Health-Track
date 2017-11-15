using System;
using System.Web.Mvc;
using AutoMapper;
using HealthTrack.Domain.Interfaces;
using HealthTrack.MVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace HealthTrack.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ViewResult Dashboard()
        {
            var user = _unitOfWork.UsuarioRepository.ObterDadosDashboard(User.Identity.GetUserId());
            var viewModel = Mapper.Map<UsuarioViewModel>(user);

            return View(viewModel);
        }

        [Route("Sobre")]
        public ViewResult About()
        {
            return View();
        }
    }
}