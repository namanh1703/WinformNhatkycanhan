using System;
using System.Collections.Generic;

namespace NhatKyCaNhan.Models
{
    public partial class Account
    {
        public Account()
        {
            DiaryDetails = new HashSet<DiaryDetail>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Sex { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Email { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<DiaryDetail> DiaryDetails { get; set; }
    }
}
