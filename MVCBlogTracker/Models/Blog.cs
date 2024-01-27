namespace MVCBlogTracker.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; } = null!;
        public string? Subject { get; set; }
        public DateTime? DateOfCreation { get; set; }
        public string BlogUrl { get; set; } = null!;
        public string? EmailId { get; set; }

        public virtual Emp? Email { get; set; }
    }
}
