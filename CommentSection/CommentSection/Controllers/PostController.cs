using CommentSection.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommentSection.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index() //Home, onde você seleciona a opção e entra na lista de Posts
        {
            return View();
        }

        public ActionResult PostList() //Lista de posts
        {
            var post = PostData.posts;
            return View(post);
        }

        public ActionResult Details(int id)//Abre informações detalhadas do post
        {
            //buscar o post correspondente a ID
            var post = PostData.posts.FirstOrDefault(t=>t.Id == id);

            if (post == null)
            {
                return HttpNotFound(); //Caso o post cuja ID foi passada não exista, retorna 404
            }

            return View(post);//else, retorna a view com os dados do post selecionado
        }


        //Função de criação de um novo post
        [HttpGet]
        public ActionResult Create()//Ação GET responsável por trazer a view de criação de um novo post
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Posted posted)
        {
            if (ModelState.IsValid)
            {
                if (PostData.posts.Any()) //se existir algum post, ID do novo igual ID do maior +1
                {
                    posted.Id= PostData.posts.Max(t=>t.Id)+1;
                }

                else //se não existir
                {
                    posted.Id = 1;
                }

                posted.Created = DateTime.Now; //data de agora
                PostData.posts.Add(posted); //Postdata.post adiciona a variável criada aqui post como uma nova variável
                return RedirectToAction("PostList", "Post"); //puxa de volta para a lista de posts
            }

            return null;
        }

        //Função de exclusão de um post existente

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var post = PostData.posts.FirstOrDefault(t=> t.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var post = PostData.posts.Find(t=>t.Id==id);


            if (post != null)
            {
                PostData.posts.Remove(post);

            }
            return RedirectToAction("PostList");
        }
    }
}