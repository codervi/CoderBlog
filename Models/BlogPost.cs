using System.ComponentModel.DataAnnotations;

namespace CoderBlog.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedBlog { get; set; } = DateTime.Now;


        // Which user does this article belong to? (Foreign Key)
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
