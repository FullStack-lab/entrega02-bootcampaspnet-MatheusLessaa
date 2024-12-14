using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSection.Models.Comment
{
    public class Commentary //Modelo das respostas aos comentários
    {
        public string repAuthor { get; set; }
        public string repComment { get; set; }
        public int repId { get; set; }
        public DateTime repTime { get; set; } = DateTime.Now;
    }
}