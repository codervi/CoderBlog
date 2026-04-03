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


        // Bir kullanıcının birden fazla makalesi olabilir (İlişki)
        public ICollection<BlogPost>? BlogPosts { get; set; }
        //Not : Yukarıda ki bölüm Required olammasına rağmen başka yerde ki tanımından dolayı DB de kayıt sırasında sorun
        // yaratıyordu. Bizlerde Soru işareti "?" atarak " Zorunlu değildir " ibaresini burada eklemiş oluyoruz

    }
}
