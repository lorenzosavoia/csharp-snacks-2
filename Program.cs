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

            List<string> numbersStrLst = new List<string>
            { "One", "Two", "Three","Four","Five"};
            // metodo join per stampare le liste o array
            Console.WriteLine(String.Join(", ", numbersStrLst));//Output:"One, Two, Three, Four, Five"
            // metodo join per stampare le liste o array
            int[] numbersIntAry = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(String.Join("; ", numbersIntAry));//Output:"1; 2; 3; 4; 5"

            Random random = new Random();
            List<int> lsInt = new List<int>();
            for(int i = 0; i < 1000; i++)
            {
                int iPush = random.Next(0, 999);
                lsInt.Add(iPush);
            }
            //sortedList quando pusho dentro un elemento me lo mette giá in ordine
            SortedSet<int> lsOrdinati = new SortedSet<int>();
            foreach(int n in lsInt)
            {
                lsOrdinati.Add(n);
            }

            Console.WriteLine("------------------------------------");
            Console.WriteLine(String.Join(", ", lsInt));
            Console.WriteLine("------------------------------------");
            Console.WriteLine(String.Join(", ", lsOrdinati));

            bool[] vBool = new bool[1000];
            foreach (var n in lsInt)
            {
                if ((n % 1) == 0)
                {
                    vBool[n] = true;
                    Console.WriteLine(n);
                    Console.WriteLine(vBool[n]);
                }
                else
                {
                    vBool[n] = false;
                    Console.WriteLine(n);
                    Console.WriteLine(vBool[n]);
                }
            }
            Console.WriteLine(String.Join("\n", vBool));

            var d = 3.4;
            Console.WriteLine((d % 1) == 0);
            var x = 0;
            Console.WriteLine((x % 1) == 0);




            /////////////////////////////////////////////////////////////////////////////////////////
            
            Random rng = new Random();

            List<int> li_base = new List<int>();

            var start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 1000; i++)
            {
                li_base.Add(rng.Next(0, 1000));
            }
            var end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            //Console.WriteLine(end - start);

            //Costruzione della lista
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            List<int> li = new List<int>();
            foreach (int n in li_base)
            {
                li.Add(n);
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di insert in una lista: {0}", end - start);

            //-calcolare quanto tempo impiegate per eseguire il seguente codice
            //     - per 10000 volte
            //        - prende in sequenza i numeri presenti in lista base
            //          - verifica se n è presente nella lista li (quindi li.find...). Non dovete stampare nulla


            int trovati = 0;
            int nontrovati = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in li_base)
                {
                    //n è presente nella lista li?
                    if (li.Contains(n))
                        trovati++;
                    else
                        nontrovati++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in una lista: {0}", end - start);
            Console.WriteLine("Trovati: {0}", trovati);


            //Ora voglio utilizzare un vettore
            //Costruzione del vettore
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            int[] vi = new int[1000];

            int posv = 0;
            foreach (int n in li_base)
            {
                vi[posv++] = n;
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di insert in un vettore: {0}", end - start);


            trovati = 0;
            nontrovati = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in li_base)
                {
                    //n è presente nel vettore vi?
                    //vi[3, 7, 1, 9, 8, 7, 6, 5, 4, 120, ....]
                    //for (int pos=0; pos < 1000; ++pos)
                    //    if (vi[pos] == n)
                    //    {
                    //        //l'ho trovato
                    //        trovati++;
                    //        break;
                    //    }
                    if (vi.Contains(n))
                        trovati++;
                    else
                        nontrovati++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un vettore: {0}", end - start);
            Console.WriteLine("Trovati: {0}", trovati);




            //Ora voglio utilizzare un vettore
            //Costruzione del vettore
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            bool[] vb = new bool[1000];  //sta tutto a false


            //li_base = new List<int> { 6, 12, 99, 101, 456 };
            foreach (int n in li_base)
            {
                vb[n] = true;
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di insert in un vettore: {0}", end - start);


            trovati = 0;
            nontrovati = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in li_base)
                {
                    if (vb[n])
                        trovati++;
                    else
                        nontrovati++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un vettore booleno: {0}", end - start);
            Console.WriteLine("Trovati: {0}", trovati);



            //Ora voglio utilizzare un sorted set
            //Costruzione del set
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            SortedSet<int> ssi = new SortedSet<int>();


            foreach (int n in li_base)
            {
                ssi.Add(n);
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di insert in un ss: {0}", end - start);


            trovati = 0;
            nontrovati = 0;
            start = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            for (int i = 0; i < 10000; ++i)
            {
                foreach (int n in li_base)
                {
                    if (ssi.Contains(n))
                        trovati++;
                    else
                        nontrovati++;
                }
            }
            end = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
            Console.WriteLine("Tempo di 10000 ricerche di 1000 elementi in un sorted set: {0}", end - start);
            Console.WriteLine("Trovati: {0}", trovati);

            //!!!LA ricerca in un insieme ordinato è logaritmica
            ///Se l'insieme contien N elementi, il tempo di ricerca oppure
            ///il numero di operazioni eseguite per la ricerca è pari a O(log(N));
            ///
            ///La ricerca in un insieme sequenziale (non ordinato) è lineare
            ///Se l'insieme contiene N elementi, il tempo di ricerca oppure
            ///il numero di operazioni eseguite per la ricerca è pari a O(N);

        }
    }
}