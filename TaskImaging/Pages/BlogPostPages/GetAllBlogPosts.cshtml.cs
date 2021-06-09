using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TaskImaging.Models;

namespace TaskImaging.Pages.BlogPostPages
{
    public class GetAllBlogPostsModel : PageModel
    {
        BlogContext BlogContext;
        public List<BlogPost> BlogPosts { get; set; }

        [BindProperty]
        public Comment NewComment{ get; set; }
        public GetAllBlogPostsModel(BlogContext _blogContext)
        {
            this.BlogContext = _blogContext;
        }

        public IActionResult OnGet()
        {
            BlogPosts = BlogContext.BlogPosts.Include(b => b.Comments).ToList();
            return Page();
        }

        public IActionResult OnGetDelete(int id)
        {
            var post = BlogContext.BlogPosts.Find(id);
            BlogContext.BlogPosts.Remove(post);
            BlogContext.SaveChanges();
            return RedirectToPage("GetAllBlogPosts");
        }

        //DeleteComment
        public IActionResult OnGetDeleteComment(int id)
        {
            var comment = BlogContext.Comments.Find(id);
            BlogContext.Comments.Remove(comment);
            BlogContext.SaveChanges();
            return RedirectToPage("GetAllBlogPosts");
        }
        public IActionResult OnPost(Comment comment)
        {
            
            BlogContext.Comments.Add(comment);
            BlogContext.SaveChanges();
            return RedirectToPage("GetAllBlogPosts");
        }
    }
}
