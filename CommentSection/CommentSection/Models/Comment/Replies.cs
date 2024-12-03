using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSection.Models.Comment
{
    public class Replies
    {
        public string Author { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}