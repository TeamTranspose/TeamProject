using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels.Article
{
    public class ArticleListViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerable<ArticleImages> Base64Images { get; set; }

        public string AuthorId { get; set; }

        public ApplicationUser Author { get; set; }
    }
}