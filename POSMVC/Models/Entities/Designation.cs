using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class Designation
    {
        public int Id { get; set; }
        public long? UserId { get; set; }
        public int? DesignationTypeId { get; set; }

        public virtual DesignationTypes DesignationType { get; set; }
    }
}
