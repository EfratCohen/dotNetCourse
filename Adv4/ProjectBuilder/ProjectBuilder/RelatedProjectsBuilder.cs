using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
     public class RelatedProjectsBuilder
    {
        //3.	Write code that “builds” these projects(sleep for one second for each build step) sequentially.

        public void RelatedProjectsBuildSync(List<RelatedProject> projectsForBuild)
        {
            foreach (var project in projectsForBuild)
            {
                RecursiveProjectBuildSync(project);
            }
        }

        private void RecursiveProjectBuildSync(RelatedProject projectForBuild)
        {
            if (!projectForBuild.IsBuilt)
            {
                Console.WriteLine($"project {projectForBuild.Id} start");

                foreach (var dependedProjectForBuild in projectForBuild.DependedProject.Where(project=>!project.IsBuilt))
                {
                    RecursiveProjectBuildSync(dependedProjectForBuild);
                }
                Thread.Sleep(1000);

                projectForBuild.IsBuilt = true;
                Console.WriteLine($"project {projectForBuild.Id} finished");

            }
        }

        //4.	Write code that builds concurrently using tasks, Task.ContinueWith and Task.Factory.ContinueWhenAll.
        public async void RelatedProjectsBuildAsync(List<RelatedProject> projectsForBuild)
        {
            var relatedProjectsBuilding = new List<Task>();

            foreach (var projectForBuild in projectsForBuild)
            {
                relatedProjectsBuilding.Add(Task.Run(() => RecursiveProjectBuildAsync(projectForBuild)));
            }

            await Task.Factory.ContinueWhenAll(relatedProjectsBuilding.ToArray(), (tasks) => 
            {
                if (tasks.Any(t => t.IsFaulted))
                {
                    Console.WriteLine("Async building colapesed");
                }
    
            });
            Console.WriteLine("finish Async Building");

        }

        private async void RecursiveProjectBuildAsync(RelatedProject projectForBuild)
        {
            if (!projectForBuild.IsBuilt)
            {
                projectForBuild.BuildingProcLock.WaitOne();

                Console.WriteLine($"project {projectForBuild.Id} start");

                var relatedForBuild= projectForBuild.DependedProject.Where(project => !project.IsBuilt).ToList();
               
                if (relatedForBuild.Count() > 0) 
                {
                    var buildingTasks = new List<Task>(relatedForBuild.Count());
                    foreach (var project in relatedForBuild)
                    {
                        buildingTasks.Add(Task.Run(() =>
                        {
                            RecursiveProjectBuildAsync(project);
                        }));
                    }
                    await Task.Factory.ContinueWhenAll(buildingTasks.ToArray(), (tasks) =>
                    {
                        if (!tasks.Any(t => t.IsFaulted))
                        {
                            Thread.Sleep(1000);

                            projectForBuild.IsBuilt = true;

                            Console.WriteLine($"project {projectForBuild.Id} finished");
                        }
                        projectForBuild.BuildingProcLock.ReleaseMutex();
                    }
                    );
                }
                else
	            {
                Thread.Sleep(1000);

                projectForBuild.IsBuilt = true;

                Console.WriteLine($"project {projectForBuild.Id} finished");

                }
            }     
        }
    }
}


