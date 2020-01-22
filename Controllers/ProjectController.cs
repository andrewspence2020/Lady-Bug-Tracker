using System;
using BugTracker.Models;
using BugTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProjectController(IProjectRepository projectRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _projectRepository = projectRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public ViewResult MainProjectsPage()
        {
            var model = _projectRepository.GetAllProjects();
            return View(model);
        }
        [AllowAnonymous]
        public ViewResult ProjectDetails(int? id)
        {
            Project project = _projectRepository.GetProject(id.Value);

            if (project == null) 
            {
                Response.StatusCode = 404;
                return View("ProjectNotFound", id.Value);
            }

            HomeProjectDetailsViewModel homeProjectDetailsViewModel = new HomeProjectDetailsViewModel()
            {
                Project = project,
                PageTitle = "Project Details"
            };
            return View(homeProjectDetailsViewModel);
        }

        [HttpGet]    
        public ViewResult AddProjects() 
        {
            return View();
        }
        [HttpGet]
        public ViewResult EditProject(int id)
        {
            Project project = _projectRepository.GetProject(id);
            ProjectEditViewModel projectEditViewModel = new ProjectEditViewModel
            {
                Id = project.Id,
                ProjectName = project.ProjectName,
                Status = project.Status,
                Description = project.Description,
                ExistingPhotoPath = project.PhotoPath
            };
            return View(projectEditViewModel);
        }

        [HttpPost]
        public IActionResult EditProject(ProjectEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Project project = _projectRepository.GetProject(model.Id);
                project.ProjectName = model.ProjectName;
                project.Status = model.Status;
                project.Description= model.Description;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath,
                            "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);

                    }

                   project.PhotoPath = ProcessUploadedFile(model);
                }

                _projectRepository.Update(project);
                return RedirectToAction("MainProjectsPage");

            }
            return View();
        }

        private string ProcessUploadedFile(ProjectCreateViewModel model)
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

        [HttpPost]
        public IActionResult AddProjects(ProjectCreateViewModel model) 
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Project newProject = new Project
                {
                    ProjectName = model.ProjectName,
                    Status = model.Status,
                    Description = model.Description,
                    PhotoPath = uniqueFileName

                };
                _projectRepository.Add(newProject);
                return RedirectToAction("projectdetails", new { id = newProject.Id });
            }
            return View();
        }


    }
}