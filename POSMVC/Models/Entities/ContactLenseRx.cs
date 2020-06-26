using System;
using System.Collections.Generic;

namespace POSMVC.Models.Entities
{
    public partial class ContactLenseRx
    {
        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public string Rsph { get; set; }
        public string Rcyl { get; set; }
        public string Raxis { get; set; }
        public string Rva { get; set; }
        public string Rbc { get; set; }
        public string Rdia { get; set; }
        public string Radd { get; set; }
        public string Riop { get; set; }
        public string Rkeratometry { get; set; }
        public string Lsph { get; set; }
        public string Lcyl { get; set; }
        public string Laxis { get; set; }
        public string Lva { get; set; }
        public string Lbc { get; set; }
        public string Ldia { get; set; }
        public string Ladd { get; set; }
        public string Liop { get; set; }
        public string Lkeratometry { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? CheckedDate { get; set; }
        public long? CheckedBy { get; set; }
        public string Note { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
