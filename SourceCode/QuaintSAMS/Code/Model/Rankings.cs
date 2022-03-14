using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuaintSAMS.Code.Model
{
    public class Rankings
    {
        public int RankingId { get; set; }
        public string RankingCode { get; set; }
        public string UniversityName { get; set; }
        public int Rank { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedFrom { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedFrom { get; set; }
        public int CountryId { get; set; }
    }
}