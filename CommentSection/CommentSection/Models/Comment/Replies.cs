using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSection.Models.Comment
{
    public class Replies
    {
        public string repAuthor { get; set; }
        public string repComment { get; set; }

        public DateTime repTime { get; set; } = DateTime.Now;
        public int repCount { get; set; }

    }
}