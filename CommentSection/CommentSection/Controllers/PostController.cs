using CommentSection.Models.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CommentSection.Controllers
{
    public class PostController : Controller
    {
        public ActionResult Index() //A view Index é a view que representa uma listagem de um posts de um fórum
        {
            return View();
        }

        public ActionResult PostList() //Lista de posts
        {
            var post = PostData.posts; //Cria uma variável post contendo os posts presentes em PostData e joga essa variável para a view
            return View(post);

            //Visando uma maior fluidez e funcionalidade da apliação, preferi por agrupar mais de uma funcionalidade à lista, como as funções de responder comentários e deletar comentários
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

        [HttpPost]
        public ActionResult AddReply (int id, string author, string text)
        {

            //Procurar o post pelo ID
            var post = PostData.posts.FirstOrDefault(t => t.Id == id);

            if (post == null)//Se o post não for encontrado, retorna 404
            {
                return HttpNotFound();
            }

            //Gera uma nova ID para o comentário
            int newRepId = post.ReplyList.Any()
                ? post.ReplyList.Max(rep =>rep.repId) +1 : 0;

            //Cria uma nova resposta em uma variável temporária
            var newReply = new Commentary
            {
                repId=newRepId,
                repAuthor = author,
                repComment = text,
                repTime = DateTime.Now,
            };

            post.ReplyList.Add(newReply); //adiciona a variável temporária criada dentro da lista replylist

            return RedirectToAction("PostList","Post");    
        }


        //Função de criação de um novo post
        [HttpGet]
        public ActionResult Create()//Ação GET responsável por trazer a view de criação de um novo Comentário
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

                else //se não existir, o ID = 1
                {
                    posted.Id = 1;
                }

                posted.Created = DateTime.Now; //data de agora
                PostData.posts.Add(posted); //PostData.post adiciona a variável criada aqui post como uma nova variável
                return RedirectToAction("PostList", "Post"); //Redireciona a aplicação para a lista de posts
            }

            return HttpNotFound(); //caso ModelState não seja válido, retorna erro404.
        }

        //Função de exclusão de um Comentário existente

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var post = PostData.posts.FirstOrDefault(t=> t.Id == id); //Procura o post na lista pelo id do comentário

            if (post == null) //caso não encontre, retorna erro 404
            {
                return HttpNotFound();
            }
            return View(post); //chama a view de confirmação de exclusão do post
        }

        [HttpPost] //Método post para a exclusão de um comentário
        public ActionResult DeleteConfirmed(int id)
        {
            var post = PostData.posts.FirstOrDefault(t=>t.Id==id); //procura o post pela ID, assim como no método anterior

            if (post != null) //Caso não seja null
            {
                PostData.posts.Remove(post); //Deleta o post
                return RedirectToAction("PostList"); //E retorna para a lista de posts
            }

            return HttpNotFound(); //Caso o post seja null, retorna erro404
        }

        [HttpPost] //Método Post para a exclusão de uma resposta 
        public ActionResult DeleteReply(int? postId, int? repId)
        {
            
            //Procurar o post pelo ID
            var post = PostData.posts.FirstOrDefault(t => t.Id == postId);

            if (post != null)//Se o post for encontrado, executa o código de exclusão
            {
                var replyToDelete = post.ReplyList.FirstOrDefault(r => r.repId == repId); //procura a resposta pelo ID dentro da lista de respostas


                post.ReplyList.Remove(replyToDelete); //remove a resposta dentro da variável replylist

                return RedirectToAction("PostList", "Post", new { id = postId });
            }

            return HttpNotFound(); //caso o post não seja encontrado, error 404
        }


        [HttpGet]//Metodo get de edição de comentário
        public ActionResult EditComment(int id)
        {
            var post = PostData.posts.FirstOrDefault(t => t.Id == id); //Procura o comentário de acordo com a ID
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post); //Chama a aba de edição do comentário
        }
        [HttpPost]//Metodo post de edição de comentário
        public ActionResult EditComment(int id, Posted post)
        {
            var existingComment = PostData.posts.FirstOrDefault(t => t.Id == id); //Procura o comentário a ser editado
            
            if (existingComment != null) //Se não for null
            {
                existingComment.Title = post.Title; //Altera as variáveis do comentário encontrado com as variáveis recebidas do formulário
                existingComment.Author = post.Author;
                existingComment.Description = post.Description;
                existingComment.Created = post.Created;
                return RedirectToAction("PostList", "Post");//Retorna para a lista de posts
            }
            return HttpNotFound(); //Caso o comentário não seja encontrado, erro404
        }

        [HttpGet]//método Get de edição de resposta
        public ActionResult EditReply(int id, int repId)
        {
            var post = PostData.posts.FirstOrDefault(t => t.Id == id); //Procura o post através da ID enviada

            if (post != null)//Se o post for encontrado, executa o código de edição
            {
                var replyToEdit = post.ReplyList.FirstOrDefault(r => r.repId == repId); //procura a resposta pelo ID dentro da lista de respostas
                
                if (replyToEdit == null) return HttpNotFound(); //Se a resposta não for encontrada, erro 404

                return View(replyToEdit);
            }

            return HttpNotFound(); //caso o post não seja encontrado, error 404
        }

        [HttpPost]//Método post de edição de resposta
        public ActionResult EditReply(int id, int repId, Commentary reply)
        {
            var post = PostData.posts.FirstOrDefault(t => t.Id == id); //Procura o post através da ID enviada
            
            if(post == null)return HttpNotFound(); //Caso não encontrado, retorna erro404

            var ExistingReply = post.ReplyList.FirstOrDefault(r=>r.repId == repId); //Procura dentro do post uma resposta através da ID (repId)

            if (ExistingReply == null) return HttpNotFound(); //Caso não encontrado, retorna erro404

            ExistingReply.repAuthor = reply.repAuthor; //Altera as variáveis presentes na resposta com as informações adquiridas no formulário
            ExistingReply.repComment = reply.repComment;
            ExistingReply.repTime = reply.repTime;
            ExistingReply.repId = reply.repId;

            return RedirectToAction("PostList", "Post");
        }
    }

}