using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SignalRTest.Data;
using AutoMapper;
using SignalRTest.Models;
using SignalRTest.Data.UnitOfWork;

namespace SignalRTest.Controllers
{
    public class DevTestsController : Controller
    {
        private DevTestUnitOfWork _unitOfWork;
        public DevTestsController(DevTestUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult IndexDynamic()
        {
            return View();
        }

        public ActionResult Index()
        {
            var devTests = _unitOfWork.DevTestRepository.All().ToList()
                .Select(x => Mapper.Map<DevTest, DevTestVM>(x));

            return View(devTests);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = _unitOfWork.DevTestRepository.GetById(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            return View(devTest);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DevTestVM devTestVm)
        {
            if (ModelState.IsValid)
            {
                var devTest = Mapper.Map<DevTestVM, DevTest>(devTestVm);
                _unitOfWork.DevTestRepository.Add(devTest);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(devTestVm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = _unitOfWork.DevTestRepository.GetById(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            var devTestVm = Mapper.Map<DevTest, DevTestVM>(devTest);

            return View(devTestVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DevTestVM devTestVm)
        {
            if (ModelState.IsValid)
            {
                var devTest = Mapper.Map<DevTestVM, DevTest>(devTestVm);
                _unitOfWork.DevTestRepository.Update(devTest);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(devTestVm);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DevTest devTest = _unitOfWork.DevTestRepository.GetById(id);
            if (devTest == null)
            {
                return HttpNotFound();
            }
            return View(devTest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DevTest devTest = _unitOfWork.DevTestRepository.GetById(id);
            _unitOfWork.DevTestRepository.Delete(devTest);
            _unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
