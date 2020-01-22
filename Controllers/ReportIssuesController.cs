using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BugTracker.Controllers
{
    [Authorize]
    public class ReportIssuesController : Controller
    {
        private readonly IReportIssuesRepository _reportIssuesRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ReportIssuesController(IReportIssuesRepository reportIssuesRepository,
            IWebHostEnvironment webhostingEnviroment)
        {
            _reportIssuesRepository = reportIssuesRepository;
            this.webHostEnvironment = webhostingEnviroment;

        }
        [AllowAnonymous]
        // Main Report Issues 
        public ViewResult MainReportIssuesPage()
        {
            var model = _reportIssuesRepository.GetAllReportIssues();
            return View(model);
        }
        [AllowAnonymous]
        // Report Issues Detail 
        public ViewResult ReportIssuesDetails(int? id)
        {
            ReportIssues reportIssues = _reportIssuesRepository.GetReportIssues(id.Value);

            if (reportIssues == null) 
            {
                Response.StatusCode = 404;
                return View("ReportIssuesNotFound", id.Value);
            }
            HomeReportIssuesDetailsViewModel homeReportIssuesDetailsViewModel = new HomeReportIssuesDetailsViewModel()
            {
                ReportIssues = reportIssues,
                Pagetitle = "Report Issues Details"
            };
            return View(homeReportIssuesDetailsViewModel);
        }
        [HttpGet]
        //add report Issues
        public ViewResult AddReportIssues()
        {
            return View();
        }
        // Edit Report Issues
        [HttpGet]
        public ViewResult EditReportIssues(int id)
        {
            ReportIssues reportIssues = _reportIssuesRepository.GetReportIssues(id);
            ReportIssuesEditViewModel reportIssuesEditViewModel = new ReportIssuesEditViewModel
            {

                Id = reportIssues.Id,
                ProjectName = reportIssues.ProjectName,
                Catagory = reportIssues.Catagory,
                Severity = reportIssues.Severity,
                Reproducibility = reportIssues.Reproducibility,
                Summary = reportIssues.Summary,
                Description = reportIssues.Description,
                ExistingPhotoPath = reportIssues.PhotoPath

            };
            return View(reportIssuesEditViewModel);       
        }
        // Edit Report Issues Edit View Model
        [HttpPost]
        public IActionResult EditReportIssues(ReportIssuesEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                ReportIssues reportIssues = _reportIssuesRepository.GetReportIssues(model.Id);
                reportIssues.ProjectName = model.ProjectName;
                reportIssues.Catagory = model.Catagory;
                reportIssues.Reproducibility = model.Reproducibility;
                reportIssues.Severity = model.Severity;
                reportIssues.Summary = model.Summary;
                reportIssues.Description = model.Description;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                    }

                    reportIssues.PhotoPath = ProcessUploadedFile(model);
                }

                _reportIssuesRepository.Update(reportIssues);
                return RedirectToAction("MainReportIssuesPage");

            }
            return View();
        }
       
        private string ProcessUploadedFile(ReportIssuesCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        //Add Report Issues 
        [HttpPost]
        public IActionResult AddReportIssues(ReportIssuesCreateViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                string uniqueFileName = null;
                if (model.Photo != null) 
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder,uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                ReportIssues newReportIssues = new ReportIssues
                {
                    ProjectName = model.ProjectName,
                    Catagory = model.Catagory,
                    Severity = model.Severity,
                    Reproducibility = model.Reproducibility,
                    Summary = model.Summary,
                    Description = model.Description,
                    PhotoPath = uniqueFileName
                };
                _reportIssuesRepository.Add(newReportIssues);
                return RedirectToAction("ReportIssuesDetails", new { id = newReportIssues.Id });
            }
            return View();
        }
        

      
    }
}
