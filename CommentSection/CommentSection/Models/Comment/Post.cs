using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommentSection.Models.Comment
{
    public class Posted //Modelo de comentários, contendo em sí a lista (commentary) referente às respostas
    {
        public int Id { get; set; }
        public string Title { get; set; }
       
        [MaxLength(20, ErrorMessage = "O texto não pode ter mais que 20 caracteres.")]
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public List<Commentary> ReplyList = new List<Commentary>();
    }
}