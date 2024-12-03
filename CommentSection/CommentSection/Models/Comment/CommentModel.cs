using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommentSection.Models;

namespace CommentSection.Models.Comment
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Comment {  get; set; }
        public DateTime Date { get; set; }
        public List <Replies> Reply { get; set; }
    }
}