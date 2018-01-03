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
    [RoutePrefix("ExercicioFisico")]
    public class ExercicioFisicoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExercicioFisicoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Listagem")]
        public ViewResult Index()
        {
            var usuarioId = User.Identity.GetUserId();
            var ExercicioFisicos = _unitOfWork.ExercicioFisicoRepository.ObterPorUsuario(usuarioId);
            var viewModel = Mapper.Map<List<ExercicioFisicoViewModel>>(ExercicioFisicos);
            return View(viewModel);
        }

        [HttpGet]
        [Route("Deletar/{id}")]
        public ActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var exercicioFisico = _unitOfWork.ExercicioFisicoRepository.Get(id);

            if (exercicioFisico == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);

            var viewModel = Mapper.Map<ExercicioFisicoViewModel>(exercicioFisico);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Deletar/{id}")]
        public ActionResult Delete(string id)
        {
            var ExercicioFisico = _unitOfWork.ExercicioFisicoRepository.Get(id);
            _unitOfWork.ExercicioFisicoRepository.Remove(ExercicioFisico);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Editar/{id}")]
        [Route("Cadastrar")]
        public ViewResult Form(string id)
        {
            var viewModel = new ExercicioFisicoViewModel();
            if (!string.IsNullOrWhiteSpace(id))
            {
                var ExercicioFisico = _unitOfWork.ExercicioFisicoRepository.Get(id);
                viewModel = Mapper.Map<ExercicioFisicoViewModel>(ExercicioFisico);
                viewModel.Data = ExercicioFisico.DataHora;
                viewModel.Hora = ExercicioFisico.DataHora;
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
        public ActionResult Form(ExercicioFisicoViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var exercicioFisico = Mapper.Map<ExercicioFisico>(viewModel);
            exercicioFisico.UsuarioId = User.Identity.GetUserId();
            exercicioFisico.DataHora = viewModel.ObterDataCompleta();

            var result = exercicioFisico.Validar();
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

            if (string.IsNullOrEmpty(exercicioFisico.Id))
            {
                _unitOfWork.ExercicioFisicoRepository.Add(exercicioFisico);
            }
            else
                _unitOfWork.ExercicioFisicoRepository.Update(exercicioFisico);

            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}