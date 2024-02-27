namespace EmployeeMVC.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string? Content { get; set; }
        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        //This is used to determine the many to many relation between Tag and BlogPost
        //One BlogPost can have many tags and one tag can have many BlogPost.
        public ICollection<Tag> Tags { get; set; }
        public ICollection<BlogPostLike> Likes { get; set; }
    }
}
