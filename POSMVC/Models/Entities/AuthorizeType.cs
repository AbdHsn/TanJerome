using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class AuthorizeType
    {
        public AuthorizeType()
        {
            Authorizations = new HashSet<Authorizations>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Authorizations> Authorizations { get; set; }
    }
}
