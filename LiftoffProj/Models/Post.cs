using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProj.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<PaintPost> PaintPosts { get; set; }
        public IList<PostLink> ImageLinks { get; set; }
    }

    public class PostLink
    {
        public int ID { get; set; }
        public string StreamLink { get; set; }

    }

    public class PaintPost
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
        public int PaintID { get; set; }
        public Paint Paint { get; set; }

    }
}
