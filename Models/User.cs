using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CoderBlog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string  Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime RegisteredDate { get; set; } = DateTime.Now;


        // A user may have more than one article (Relationship)
        public ICollection<BlogPost>? BlogPosts { get; set; }
        /*Note: Although the section above is marked as “Required”, it was causing issues during database registration due to a definition elsewhere.
         We have therefore added the phrase “Not required” here by including a question mark ‘?’.
        */

    }
}
