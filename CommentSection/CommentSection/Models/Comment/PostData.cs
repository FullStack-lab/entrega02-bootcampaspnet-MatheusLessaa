using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommentSection.Models.Comment
{
    public class PostData
    {
        public static List<Posted> posts = new List<Posted>()
        {
            new Posted
            {
                Id = 1,
                Author = "Matheus Lessa",
                Title = "Teste",
                Description= "Esse é o campo onde fica o corpo do comentário",
                Created = DateTime.Now       
            },
        };
    }
}