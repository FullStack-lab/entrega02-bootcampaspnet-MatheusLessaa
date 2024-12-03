using System;
using System.Collections.Generic;


namespace CommentSection.Models.Comment
{
    public class CommentData
    {
        public static List<CommentModel> Post = new List<CommentModel>()
        {
            new CommentModel
            {
                Id = 1,
                Author = "Matheus Lessa",
                Title = "Olha como eu amo minha namorada",
                Comment = "Ela é perfeita incrivel nada como uma sereia eu amo ela rs te amo bb",
                Date = DateTime.Now,
                Reply = new List<Replies>
                {
                    new Replies
                    {
                        Author = "Sogrinha",
                        Comment = "Eu concordo a juju é maravilhosa",
                        Date= DateTime.Now
                    },

                    new Replies
                    {
                        Author = "Memel",
                        Comment = "Minha tia é absurda sério",
                        Date= DateTime.Now
                    }

                }
            },

            new CommentModel
            {
                Id = 2, 
                Author = "Olha pro comentário",
                Title = "Olha o autor",
                Comment = "Eu te amo rs",
                Date = DateTime.Now
            }
        };
    }
}