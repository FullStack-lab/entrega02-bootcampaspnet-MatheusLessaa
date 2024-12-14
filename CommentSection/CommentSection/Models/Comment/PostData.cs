using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*Pelo fato do trabalho ainda não englobar os módulos de banco de dados, os dados do post são armazenados em código */
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
                Description= "Esse é o campo onde fica o corpo do comentário",
                Created = DateTime.Now       
            },
        };
    }
}