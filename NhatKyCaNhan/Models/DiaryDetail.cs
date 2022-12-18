using System;
using System.Collections.Generic;

namespace NhatKyCaNhan.Models
{
    public partial class DiaryDetail
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreate { get; set; }
        public int? CreateBy { get; set; }
        public bool? Favourite { get; set; }

        public virtual Account? CreateByNavigation { get; set; }
    }
}
