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
    [RoutePrefix("Peso")]
    public class PesoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PesoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Listagem")]
        public ViewResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            var pesos = _unitOfWork.PesoRepository.ObterPorUsuario(usuarioId);
            var viewModel = Mapper.Map<List<PesoViewModel>>(pesos);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Deletar/{id}")]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var peso = _unitOfWork.PesoRepository.Get(id);

            if (peso == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = Mapper.Map<PesoViewModel>(peso);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult Delete(string id)
        {
            var peso = _unitOfWork.PesoRepository.Get(id);
            _unitOfWork.PesoRepository.Remove(peso);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ViewResult Form(string id = null)
        {
            var viewModel = new PesoViewModel();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var Peso = _unitOfWork.PesoRepository.Get(id);
                viewModel = Mapper.Map<PesoViewModel>(Peso);
                viewModel.Data = Peso.DataHora;
                viewModel.Hora = Peso.DataHora;
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
        public ActionResult Form(PesoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var peso = Mapper.Map<Peso>(viewModel);
            peso.UsuarioId = User.Identity.GetUserId();
            peso.DataHora = viewModel.ObterDataCompleta();

            var result = peso.Validar();
            if (!result.IsValid)
            {
                foreach (var validation in result.Errors)
                {
                    if (validation.PropertyName.Equals("DataHora"))
                        ModelState.AddModelError("", validation.ErrorMessage);
                    else
                        ModelState.AddModelError(validation.PropertyName, validation.ErrorMessage);
                }
                return View(viewModel);
            }

            if (string.IsNullOrEmpty(peso.Id))
            {
                peso.Id = Guid.NewGuid().ToString();
                _unitOfWork.PesoRepository.Add(peso);
            }
            else
                _unitOfWork.PesoRepository.Update(peso);

            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}