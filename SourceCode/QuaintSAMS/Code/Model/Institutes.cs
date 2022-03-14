using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.Model
{
    public class Institutes
    {
        public int InstituteId { get; set; }
        public string InstituteCode { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int SerialNumber { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int CourseId { get; set; }
    }
}