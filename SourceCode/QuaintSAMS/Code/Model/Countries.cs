using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.Model
{
    public class Countries
    {
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryCodeAlpha2 { get; set; }
        public string CountryCodeAlpha3 { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
    }
}