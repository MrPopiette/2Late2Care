using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ToLateToCare_5.Models
{
    public class MethodFromContext : IMethods
    {
        private ContexteBdd db;

        public MethodFromContext()
        {
            db = new ContexteBdd();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public UtilisateurModel Connecter(string pseudo, string password)
        {
            return db.Utilisateurs.FirstOrDefault(user => user.pseudo == pseudo && user.password == password);
        }

        public int CreerUtilisateur(string pseudo, string mail, string password, ClasseModel classe)
        {
            UtilisateurModel utilisateur = new UtilisateurModel { pseudo = pseudo, mail = mail, password = password, classe = classe };
            db.Utilisateurs.Add(utilisateur);
            db.SaveChanges();
            return utilisateur.Id;
        }

        public int GetUtilisateurIDForSession(string pseudo, string password)
        {
            UtilisateurModel utilisateur = db.Utilisateurs.FirstOrDefault(user => user.pseudo == pseudo && user.password == password);
            return utilisateur.Id;
        }

        public UtilisateurModel GetUtilisateur(int id)
        {
            return db.Utilisateurs.FirstOrDefault(user => user.Id == id);
        }

        public List<UtilisateurModel> GetAllUtilisateurs()
        {
            return db.Utilisateurs.ToList();
        }

        public void CreerTicket(string titre, string texte, UtilisateurModel utilisateur, DateTime date, string urlPhoto, Collection<TagModel> tags)
        {
            TicketModel ticket = new TicketModel { titre = titre, description = texte , auteur = utilisateur, date = date, urlPhoto = urlPhoto, tags = tags };
            db.Tickets.Add(ticket);
            db.SaveChanges();
        }
        public List<TicketModel> GetAllTickets()
        {
            return db.Tickets.ToList();
        }

        public bool CheckTicketExiste(string titre)
        {
            return db.Tickets.Any(ticket => string.Compare(ticket.titre, titre, StringComparison.CurrentCultureIgnoreCase) == 0);
        }
    }
}