using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ViewModels.Article
{
    public class ArticleCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }

        public HttpPostedFileBase[] ArticleImages { get; set; }

        public string AuthorId { get; set; }
    }
}