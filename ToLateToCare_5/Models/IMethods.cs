using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLateToCare_5.Models
{
    interface IMethods : IDisposable
    {
        UtilisateurModel Connecter(string nom, string mdp);
        void CreerTicket(string titre, string texte, UtilisateurModel utilisateur, DateTime date, string urlPhoto, Collection<TagModel> tags);

        List<TicketModel> GetAllTickets();
        bool CheckTicketExiste(string titre);
        int CreerUtilisateur(string pseudo, string mail, string password, ClasseModel classe);

        int GetUtilisateurIDForSession(string pseudo, string password);

        UtilisateurModel GetUtilisateur(int id);

        List<UtilisateurModel> GetAllUtilisateurs();

    }
}
