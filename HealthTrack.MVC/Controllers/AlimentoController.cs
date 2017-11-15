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
    [RoutePrefix("Alimento")]
    public class AlimentoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlimentoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Listagem")]
        public ViewResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            var alimentos = _unitOfWork.AlimentoRepository.ObterPorUsuario(usuarioId);
            var viewModel = Mapper.Map<List<AlimentoViewModel>>(alimentos);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Deletar/{id}")]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var alimento = _unitOfWork.AlimentoRepository.Get(id);

            if (alimento == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = Mapper.Map<AlimentoViewModel>(alimento);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult Delete(string id)
        {
            var alimento = _unitOfWork.AlimentoRepository.Get(id);
            _unitOfWork.AlimentoRepository.Remove(alimento);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ViewResult Form(string id = null)
        {
            var viewModel = new AlimentoViewModel();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var alimento = _unitOfWork.AlimentoRepository.Get(id);
                viewModel = Mapper.Map<AlimentoViewModel>(alimento);
                viewModel.Data = alimento.DataHora;
                viewModel.Hora = alimento.DataHora;
                ViewBag.Titulo = "Editar";
                return View(viewModel);
            }

            ViewBag.Titulo = "Cadastrar";
            viewModel.Data = DateTime.Now;
            viewModel.Hora = DateTime.Now;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ActionResult Form(AlimentoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var alimento = Mapper.Map<Alimento>(viewModel);
            alimento.UsuarioId = User.Identity.GetUserId();
            alimento.DataHora = viewModel.ObterDataCompleta();

            var result = alimento.Validar();
            if (!result.IsValid)
            {
                foreach (var validation in result.Errors)
                {
                    if(validation.PropertyName.Equals("DataHora"))
                        ModelState.AddModelError("", validation.ErrorMessage);
                    else
                        ModelState.AddModelError(validation.PropertyName, validation.ErrorMessage);
                }
                return View(viewModel);
            }

            if (string.IsNullOrEmpty(alimento.Id))
            {
                alimento.Id = Guid.NewGuid().ToString();
                _unitOfWork.AlimentoRepository.Add(alimento);
            }
            else
                _unitOfWork.AlimentoRepository.Update(alimento);

            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}