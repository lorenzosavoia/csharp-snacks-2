using System;

namespace csharp_snacks_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Scrivere un codice csharp che crea un accumulatore e poi lo utilizza
            //Esempio: var accumulatore1 = CreaAccumulatore();
            //accumulatore1(10) => 10
            //accumulatore1(40) => 50
            //accumulatore1(90) => 140
            /*
             * In javascript  (closure)
              Maker() {
                let tot = 0;
                return (n) => {
                    tot += n;
                    return tot;
                }
              }
             * */
            //1: per evitare di dichiarare un tipo cosa uso? var!!!
            var Maker = () =>
            {
                long totale = 0;
                return (int n) =>
                {
                    totale += n;
                    return totale;
                };
            };
            var acc1 = Maker();
            var acc2 = Maker();
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc1(10));
            Console.WriteLine(acc2(10));
            Console.WriteLine(acc2(10));
            Console.WriteLine(acc2(10));

            //creo due liste una per i numeri normali
            List<int> list = new List<int>();
            //una per i numeri alla potenza
            List<int> list2 = new List<int>();
            // dichiaro l'operatore random
            Random rnd = new Random();

            //popolo la lista con un for
            for(int i = 0; i < 40; i++)
            {
                list.Add(rnd.Next(0,10));
            }
            //faccio un foreach sulla lista per fare l'operazione
            //e pusho tutto nella seconda lista
            foreach (int i in list)
            {
                int iSomma = i * i;
                list2.Add(iSomma);
                Console.WriteLine("il quadrato di {0} é {1}", i, iSomma);
            }

            //stesso esercizio ma creando un metodo riutilizzabile
            List<int> listnormal = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }; // lista di partenza
            List<int> lsquare = ElevaAlQuadrato(listnormal); //lista nuova che saraà = a result dopo il foreach
            List<int> lsCubo = ElevaAlCubo(listnormal); // lista nuova sará tutta al cubo

            // uso questo foreach per controllare il contenuto
            foreach (int n in lsCubo)
            {
                Console.WriteLine(n);
            }

            //funzione per cui data una lista eleva i valore contenuti in essa al quadrato
            List<int> ElevaAlQuadrato(List<int> list)
            {
                List<int> result = new List<int>();
                foreach (int i in list)
                {
                    int ialqudrato = i * i;
                    result.Add(ialqudrato);
                }
                return result;
            }
            //funzione per cui data una lista eleva i valore contenuti in essa al cubo
            List<int> ElevaAlCubo(List<int> list)
            {
                List<int> result = new List<int>();
                foreach (int i in list)
                {
                    int ialqudrato = i * i * i;
                    result.Add(ialqudrato);
                }
                return result;
            }

            List<int> EseguiIlCalcolo(List<int> li, Func<int, int> fun)// Func e due parametri in cui il primo é quello su cui devo lavorare il secondo é quello che mi restituisce
            {
                List<int> lout = new List<int>();
                foreach (int n in li)
                    lout.Add(fun(n));
                return lout;
            }

            List<int> lcalcolo = EseguiIlCalcolo(listnormal, (n) => n * (n + 1) / 2);
            foreach (int n in lcalcolo)
                Console.WriteLine(n);
            //Abbiamo in questo modo costruito una funzione "generale" per trasformare
            //tutti gli elementi di una stringa da numero intero a numero intero => nuovo = f(vecchio);
            //Purtroppo per come è stata costruita, questa funzione si applica esclusivamente alle lista di numeri interi 
            //e torna una lista di numeri interi
        }
    }
}