using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class ArticleImages
    {
        [Key]
        public int Id { get; set; }

        public string Base64Image { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}