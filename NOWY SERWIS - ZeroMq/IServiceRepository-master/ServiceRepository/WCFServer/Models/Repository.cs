using NServiceRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer.Models
{
    /**
    * Klasa umozliwiajaca polaczenie sie z baza danych
    * */
    class Repository
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private EFDbContext context;
        private IEnumerable<Service> Services{
            get { return context.Servs; }
        }
        public Repository() {
            context = new EFDbContext();
            //usuniecie nieaktywnych serwisow
            KillZombieServices();
        }
        /**
        * Dodanie serwisu do bazy
        **/
        public void AddService(Service serv){
            context.Servs.Add(serv);
            context.SaveChanges();
        }
        /**
        * Usuniecie serwisu z bazy
        **/
        public void RemoveService(Service serv)
        {
            context.Servs.Remove(serv);
            context.SaveChanges();
        }
        /**
        * Zaktualizowanie czasu ostatniej komunikacji z serwisem
        **/
        public void UpdateService(Service serv)
        {
            using (var dbCtx = new EFDbContext())
            {
                dbCtx.Entry(serv).State = EntityState.Modified;    
                dbCtx.SaveChanges();
            }
        }
        /**
        * Wyszukwanie serwisu w bazie
        **/
        public Service FindService(String Name)
        {
            return context.Servs.SingleOrDefault(serv => serv.Name == Name);
        }
        /**
        * Usuniecie nieaktywnych serwisow
        **/
        public void KillZombieServices()
        {
            TimeSpan duration;
            foreach (var serv in context.Servs)
            {
                duration = DateTime.Now - serv.LastSeen;
                if (duration.Seconds > 20)
                {
                    context.Servs.Remove(serv);
                    Console.WriteLine("Serwis {0} wygasł", serv.Name);
                    log.Info("Serwis "+ serv.Name+" wygasł.");
                }     
            }
            context.SaveChanges();
        }
    }
}
