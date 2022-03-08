using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Entities.Models
{
    public class BaseEntities
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
