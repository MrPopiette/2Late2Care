using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToLateToCare_5.Models;

namespace ToLateToCare_5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Authentification(string pseudo, string password)
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    UtilisateurModel user = methods.Connecter(pseudo, password);
                    using (var context = new ContexteBdd())
                    {
                        user = context.Utilisateurs.First(utilisateur => utilisateur.pseudo == pseudo && utilisateur.password == password);
                        ViewBag.user = user;
                        int temp = (int)user.Id;
                        Session["user"] = temp;
                    }
                    return View("~/Views/Home/Index.cshtml");
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                }
                return View("~/Views/Home/Connexion.cshtml");
            }
        }

        public ActionResult ListTickets()
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    List<TicketModel> tickets = methods.GetAllTickets();
                    ViewBag.tickets = tickets;
                    UtilisateurModel utilisateur = methods.GetUtilisateur((int)Session["user"]);
                    ViewBag.Utilisateur = utilisateur;
                    ClasseModel classe = utilisateur.classe;
                    ViewBag.Classe = classe;
                    return View("~/Views/Home/ListerPost.cshtml", tickets);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                    return View("~/Views/Home/ListerPost.cshtml");
                }
            }
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AjoutUtilisateur(string nom, string prenom, string email, string mdp, int INTpromo_id)
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    using (var context = new ContexteBDD())
                    {
                        Promo promo_id = context.Promos.First(p => p.ID == INTpromo_id);
                        dal.AjouterUtilisateur(nom, prenom, email, mdp, promo_id);
                        return View("~/Views/Home/Login.cshtml");
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                }
                return View("~/Views/Home/Inscription.cshtml");
            }
        }


        
        [HttpPost, ValidateInput(false)]
        public ActionResult AddTicket(string texte)
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    using (var context = new ContexteBdd())
                    {
                        UtilisateurModel utilisateur_id = methods.GetUtilisateur((int)Session["user"]);
                        DateTime dateNow = DateTime.Now;
                        int likes = 0;
                        int dislikes = 0;
                        methods.CreerTicket(texte, utilisateur_id, dateNow, likes, dislikes);
                        ViewBag.texte = texte;
                        ViewBag.utilisateur_id = utilisateur_id;
                        ViewBag.dateNow = dateNow;
                        ViewBag.likes = likes;
                        ViewBag.dislikes = dislikes;
                    }
                    return View("~/Views/Home/ListerPost.cshtml");

                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                }
                return View("~/Views/Home/CreerPost.cshtml");
            }
        }
    }
}