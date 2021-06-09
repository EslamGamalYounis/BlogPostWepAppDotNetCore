using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskImaging.Models
{
    public class BlogContext:DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<BlogPost> BlogPosts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
