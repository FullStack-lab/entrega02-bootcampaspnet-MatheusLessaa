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
                Author = "Juju",
                Title = "Meuamô",
                Description= "Ela está de switch novo oba",
                Created = DateTime.Now
            },

            new Posted
            {
                Id = 2,
                Author = "Tetheu",
                Title = "Amodela",
                Description= "Ganhou um switch de volta rs",
                Created = DateTime.Now
            }
        };
    }
}