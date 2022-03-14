using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.Model
{
    public class BlogPosts
    {
        public int BlogPostId { get; set; }
        public string BlogPostCode { get; set; }
        public string Title { get; set; }
        public string Slag { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Attachment { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int BlogPostCategoryId { get; set; }
    }
}