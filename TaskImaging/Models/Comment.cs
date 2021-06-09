using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskImaging.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Name { get; set; }
        public string CommentBody { get; set; }
        [ForeignKey("BlogPost")]
        public int BlogPostId { get; set; }
        [JsonIgnore]
        public virtual BlogPost BlogPost { get; set; }

    }
}
