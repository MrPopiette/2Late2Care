using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            if (Session["user"] == null)
            {
                return View("~/Views/Home/Connexion.cshtml");
            }
            else
            {
                return View();
            }
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
        public ActionResult Connexion(string pseudo, string password)
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
        public ActionResult AjoutUtilisateur(string pseudo, string mail, string password, ClasseModel classe)
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    using (var context = new ContexteBdd())
                    {
                        methods.CreerUtilisateur(pseudo, mail, password, classe);
                        return View("~/Views/Home/Connexion.cshtml");
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
        public ActionResult AddTicket(string titre, string description, string urlPhoto, IEnumerable<TagModel> tags)
        {
            using (IMethods methods = new MethodFromContext())
            {
                try
                {
                    using (var context = new ContexteBdd())
                    {
                        UtilisateurModel utilisateur = methods.GetUtilisateur((int)Session["user"]);
                        DateTime dateNow = DateTime.Now;                       
                        methods.CreerTicket(titre, description, utilisateur, dateNow, urlPhoto, tags);
                        ViewBag.titre = titre;
                        ViewBag.description = description;
                        ViewBag.utilisateur = utilisateur;
                        ViewBag.date = dateNow;
                    }
                    return View("~/Views/Home/GetAllTickets.cshtml");

                }
                catch (IOException e)
                {
                    Console.WriteLine($"Error : '{e}'");
                }
                return View("~/Views/Home/AddTicket.cshtml");
            }
        }
    }
}