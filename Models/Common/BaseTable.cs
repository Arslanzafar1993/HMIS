using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Common
{
    public class BaseTable
    {
        public long Id { get; set; }
        public bool Status { get; set; }
        public bool? IsDeleted { get; set; }
        [MaxLength(500)]
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
