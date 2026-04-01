using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CoderBlog.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string  Email { get; set; } = string.Empty;
        public string Password { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        // Bir kullanıcının birden fazla makalesi olabilir (İlişki)
        public ICollection<BlogPost> BlogPosts { get; set; }

    }
}
