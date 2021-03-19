using EroiVsMostri.ADORepository;
using EroiVsMostri.Core.Entità;
using EroiVsMostri.Core.Interfacce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EroiVsMostri.Services
{
    public class MostriServices
    {
        private IMostroRepository _repo;
        public MostriServices(IMostroRepository repo)
        {
            _repo = repo;
        }

        //GET ALL mostri
        public IEnumerable<Mostro> GetAllMostri()
        {
            IEnumerable<Mostro> tuttiMostri = _repo.GetAll();

            foreach (var mostro in tuttiMostri)
            {
                Console.WriteLine(mostro);
            }
            return tuttiMostri;
        }

        //GET BY ID
        //id random tra i mostro con livello <= eroe filtrati da GetAllMostri()
        public Mostro GetMostroByID(Eroe eroe)
        {
            //uso _repo.GetAll e non GetAllMostri() perchè così non me li stampa a schemro
            IEnumerable<Mostro> tuttiMostri = _repo.GetAll();
            List<Mostro> mostriFiltroLivelloEroe = new List<Mostro>();

            foreach (var m in tuttiMostri)
            {
                if (m.Livello <= eroe.Livello)
                {
                    mostriFiltroLivelloEroe.Add(m);
                }
            }
            int indiceMax = mostriFiltroLivelloEroe.Count();

            Random random = new Random();
            int rando = random.Next(0, indiceMax);

            Mostro mostro = mostriFiltroLivelloEroe[rando];
            Mostro mostroScelto = _repo.GetByID(mostro.ID);
            //Console.WriteLine(mostroScelto.ToString());
            return mostro;
        }

        //DELETE
        //controllo se l'id esiste e se è un numero
        public void DeleteMostro()
        {
            Mostro mostro = new Mostro();
            int id = 0;

            while (mostro.ID == 0)
            {
                try
                {
                    Console.WriteLine("Inserisci l'id del mostro che vuoi eleminare:");
                    id = Convert.ToInt32(Console.ReadLine());
                    mostro = _repo.GetByID(id);
                }
                catch (Exception)
                {

                    Console.WriteLine("Inserisci un numero valido!");
                }
            }
            bool elimina = _repo.Delete(mostro);

            if (elimina == false)
                Console.WriteLine("Errore, mostro non presente.");
        }

        //UPDATE
        //solo i punti vita, nel caso in cui si interroma uno scontro a metà quando torno posso riprenderlo
        //non sono sicura
        public void UpdateEroe(Mostro mostro)
        {
            _repo.Update(mostro);
        }

        //INSERT
        //DA MODOFICARE
        public Mostro CreateMostro()
        {
            Console.WriteLine("Crea un nuovo Mostro:");
            //chiedo i paramentri

            //nome
            Console.WriteLine("Nome del Mostro: ");
            string nome = Console.ReadLine();
            //classe, stampo la lista di tutte le classi dei i mostri presenti con GetAllClassi 
            //e gli faccio scegliere la classe con GetClasseByID
            var classi = new ClassiServices(new ADOClasseRepository());
            Console.WriteLine("Scegli una classe tra quelle disponibili:");
            bool mostro = false;
            classi.GetAllClassi(mostro);
            Classe classeScelta = classi.GetClassByID();
            //arma, stessa cosa della classe
            var armi = new ArmiServices(new ADOArmaRepository());
            Console.WriteLine("Armi disponibili per " + classeScelta.Nome + ":");
            armi.GetAllArmi(classeScelta.ID);
            Arma armaScelta = armi.GetArmaByID(0);
            //li gestisco nel costruttore
            //IsEroe, è sempre false
            //Punti vita all'inizio sono sempre 20
            //posso scegliere anche il livello
            var livelli = new LivelliServices(new ADOLivelloRepository());
            Console.WriteLine("Scegli un livello tra quelli disponibili:");
            List<Livelli>Liv = (List<Livelli>)livelli.GetAllLivelli(1);
            bool ok = false;
            int id =0;
            while (ok == false)
            {
                try
                {
                    Console.WriteLine("Scegli in livello");
                    id = Convert.ToInt32(Console.ReadLine());
                    if (id > 0 && id <= Liv.Count)
                    {
                        ok = true;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Scegli un livello valido!");
                }
            }
            Livelli livelloScelto = livelli.GetLivelloByID(id);

            Mostro nuovoMostro = new Mostro()
            {
                Nome = nome,
                ClasseDiAppartenenza = classeScelta.ID,
                ArmaScelta = armaScelta.ID,
                IsEroe = false,
                PuntiVita = livelloScelto.PuntiVita,
                Livello = livelloScelto.Livello,
            };

           Mostro nuovo = _repo.Create(nuovoMostro);
           return nuovo;
        }






    }

}
