using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using HealthTrack.Domain.Interfaces;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;
using Microsoft.AspNet.Identity;

namespace HealthTrack.MVC.Controllers
{
    [Authorize]
    [RoutePrefix("PressaoArterial")]
    public class PressaoArterialController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PressaoArterialController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Listagem")]
        public ViewResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            var PressaoArterials = _unitOfWork.PressaoArterialRepository.ObterPorUsuario(usuarioId);
            var viewModel = Mapper.Map<List<PressaoArterialViewModel>>(PressaoArterials);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Deletar/{id}")]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pressaoArterial = _unitOfWork.PressaoArterialRepository.Get(id);

            if (pressaoArterial == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = Mapper.Map<PressaoArterialViewModel>(pressaoArterial);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult Delete(string id)
        {
            var pressaoArterial = _unitOfWork.PressaoArterialRepository.Get(id);
            _unitOfWork.PressaoArterialRepository.Remove(pressaoArterial);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ViewResult Form(string id = null)
        {
            var viewModel = new PressaoArterialViewModel();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var pressaoArterial = _unitOfWork.PressaoArterialRepository.Get(id);
                viewModel = Mapper.Map<PressaoArterialViewModel>(pressaoArterial);
                viewModel.Data = pressaoArterial.DataHora;
                viewModel.Hora = pressaoArterial.DataHora;
                ViewBag.Titulo = "Editar";
                return View(viewModel);
            }

            viewModel.Data = DateTime.Now;
            viewModel.Hora = DateTime.Now;
            ViewBag.Titulo = "Cadastrar";
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ActionResult Form(PressaoArterialViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var pressaoArterial = Mapper.Map<PressaoArterial>(viewModel);
            pressaoArterial.DataHora = viewModel.ObterDataCompleta();
            pressaoArterial.ObterStatus();

            var validacao = pressaoArterial.Validar();
            if (!validacao.IsValid)
            {
                foreach (var validation in validacao.Errors)
                {
                    if(validation.PropertyName.Equals("Status") || validation.PropertyName.Equals("DataHora"))
                        ModelState.AddModelError("", validation.ErrorMessage);
                    else
                        ModelState.AddModelError(validation.PropertyName, validation.ErrorMessage);
                }
                return View(viewModel);
            }

            pressaoArterial.UsuarioId = User.Identity.GetUserId();

            if (string.IsNullOrEmpty(pressaoArterial.Id))
                _unitOfWork.PressaoArterialRepository.Add(pressaoArterial);
            else
                _unitOfWork.PressaoArterialRepository.Update(pressaoArterial);

            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}