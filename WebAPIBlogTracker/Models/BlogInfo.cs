using System;
using System.Collections.Generic;

namespace WebAPIBlogTracker.Models
{
    public partial class BlogInfo
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string? Subject { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public string BlogUrl { get; set; } = null!;
        public string? EmailId { get; set; }

        public virtual EmpInfo? Email { get; set; }
    }
}
