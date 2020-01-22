using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class MockProjectRepository : IProjectRepository
    {
        private List<Project> _projectsList;

        public MockProjectRepository() 
        {
            _projectsList = new List<Project>() 
            {
                new Project() {Id = 1,ProjectName = "BugTracker",
                    Status = Stats.Development,Description = "This is my first Enterprise Project"
                }

            };
        }
        public Project Add(Project project)
        {
            project.Id = _projectsList.Max(p => p.Id) + 1;
            _projectsList.Add(project);
            return project;
        }


        public IEnumerable<Project> GetAllProjects()
        {
            return _projectsList;
        }
        public Project GetProject(int Id)
        {
            return _projectsList.FirstOrDefault(p => p.Id == Id);
        }
      

        public Project Update(Project ProjectChanges)
        {
            Project project = _projectsList.FirstOrDefault(e => e.Id == ProjectChanges.Id);
            if (project != null)
            {
                project.ProjectName = ProjectChanges.ProjectName;
                project.Status = ProjectChanges.Status;
                project.Description = ProjectChanges.Description;
            }
            return project;
        }
    }
}
