namespace MVCBlogTracker.Models
{
    public class Emp
    {
        public Emp()
        {
            BlogInfos = new HashSet<Blog>();
        }

        public string EmailId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public DateTime? DateOfJoining { get; set; }
        public string PassCode { get; set; } = null!;

        public virtual ICollection<Blog> BlogInfos { get; set; }
    }
}
