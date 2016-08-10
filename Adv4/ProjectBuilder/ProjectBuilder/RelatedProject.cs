using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectBuilder
{
    public class RelatedProject
    {

        #region properties

        public int Id { get; }

        public List<RelatedProject> DependedProject { get; set; }

        public bool IsBuilt { get; set; }

        public Mutex BuildingProcLock { get; set; }

        #endregion
        #region ct'ors

        public RelatedProject(int id)
        {
            Id = id;
            DependedProject = new List<RelatedProject>();
            BuildingProcLock = new Mutex();
        }

        public RelatedProject(int id, List<RelatedProject> depended) : this(id)
        {
            DependedProject = depended;
        }

        #endregion

    }
}
