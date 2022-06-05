using ShitjaProdukteve.Llogaria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitjaProdukteve.MenaxhimiLlogarive
{
    interface ILlogaria
    {
        /// <summary>
        /// Fshin userin ne baze te id-se
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Kthen true nese eshte fshire me sukses</returns>
        Validimi Fshij(int id);
        /// <summary>
        /// Regjistron user te ri
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns>Kthen te dhenat e tipit Validimi i cili permban listen e errorave, po ashtu kthen 
        /// Sukses = true nese eshte kryer regjistrimi me sukses</returns>
        Validimi Regjistro(User newUser);
        /// <summary>
        /// Metoda per login te userit ekzistues
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Kthen true nese eshte kyqur me sukses</returns>
        bool Login(string userName,string password);
        /// <summary>
        /// Editon rolin per userin e caktuar
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roli"></param>
        /// <returns>Kthen true nese eshte edituar roli me sukses</returns>
        Validimi EditoRolin(string userName, Rolet roli);

        Validimi NdryshoPasswordin(string passwordiVjeter, string passwordiRi);
        Validimi Ndrysho(User user);
    }

}
