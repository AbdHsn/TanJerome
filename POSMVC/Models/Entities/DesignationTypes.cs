using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class DesignationTypes
    {
        public DesignationTypes()
        {
            Designation = new HashSet<Designation>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Designation> Designation { get; set; }
    }
}
