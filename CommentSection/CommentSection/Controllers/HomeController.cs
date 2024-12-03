using CommentSection.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentSection.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult CommentList()
        {

            var comment = CommentData.Post;
            return View(comment);

        }

        public ActionResult CommentDetailed(int id)
        {
            var comment = CommentData.Post.FirstOrDefault(t => t.Id == id);

            if (comment == null) 
            { 
                return HttpNotFound();
            }

            return View(comment);

        }
    }
}