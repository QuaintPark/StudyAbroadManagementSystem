using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.Model
{
    public class Tutorials
    {
        public int TutorialId { get; set; }
        public string TutorialCode { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string ExternalUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int PlayListId { get; set; }
    }
}