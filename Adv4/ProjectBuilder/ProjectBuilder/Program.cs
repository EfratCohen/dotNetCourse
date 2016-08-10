using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
           #region Example projectsForBuild list
            var projectsForBuild = new List<RelatedProject>();

            projectsForBuild.Add(new RelatedProject(0));

            for (int i = 0; i < 7; i++)
            {

                    projectsForBuild.Add(new RelatedProject(i+1));

            }

            projectsForBuild[0].DependedProject.Add(projectsForBuild[6]);

            projectsForBuild[0].DependedProject.Add(projectsForBuild[5]);

            projectsForBuild[0].DependedProject.Add(projectsForBuild[2]);

            projectsForBuild[1].DependedProject.Add(projectsForBuild[3]);

            #endregion

           var builder =new RelatedProjectsBuilder();

         // builder.RelatedProjectsBuildSync(projectsForBuild);
          builder.RelatedProjectsBuildAsync(projectsForBuild);
            Console.Read();

        }
    }
}
