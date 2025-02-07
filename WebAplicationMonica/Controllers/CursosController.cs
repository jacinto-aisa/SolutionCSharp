﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAplicationMonica.CrossCuting.Logging;
using WebAplicationMonica.Models;
using WebAplicationMonica.Services;

namespace WebAplicationMonica.Controllers
{
    public class CursosController : Controller
    {
        private readonly IRepositorioCurso _repositorioCurso;
        private readonly ILoggerManager _loggerManager; 

        public CursosController(IRepositorioCurso repositorioCurso,ILoggerManager loggerManager)
        {
            _repositorioCurso = repositorioCurso;
            _loggerManager = loggerManager;
        }

        // GET: HomeController
        public ActionResult Index()
        {
            return View("Index",_repositorioCurso.ListaCursos());
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details",_repositorioCurso.TomaCurso(id));
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,string name)
        {
            try
            {
                _repositorioCurso.AddCurso(new Curso() { Name = name });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}