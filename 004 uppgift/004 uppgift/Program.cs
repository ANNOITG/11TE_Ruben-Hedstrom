using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            List<lärare> lärarlista = new List<lärare>();
            List<Elev> elevlista = new List<Elev>();
            
            while (true)
            {
                Console.WriteLine("A: Kolla lärare\nB: Kolla elever\nC: Lägg till lärare\nD: Lägg till elev");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.A)
                {
                    Console.Clear();
                    for (int i = 0; i < lärarlista.Count; i++)
                    {
                        Console.WriteLine(lärarlista[i].ToString());
                    }
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.B)
                {
                    Console.Clear();
                    for (int i = 0; i < elevlista.Count; i++)
                    {
                        Console.WriteLine(elevlista[i].ToString());
                    }
                    Console.ReadKey();
                }
                else if (key.Key == ConsoleKey.C)
                {
                    Console.Clear();
                    Console.Write("Namn: ");
                    string namn = Console.ReadLine();
                    Console.Write("Personnummer: ");
                    string Person = Console.ReadLine();
                    Console.Write("Adress: ");
                    string adress = Console.ReadLine();
                    Console.Write("Telefonnummer: ");
                    string telefon = Console.ReadLine();
                    Console.Write("Lön: ");
                    string cash = Console.ReadLine();
                    Console.Write("Kurser: (matte, svenska, osv) ");
                    string kursen = Console.ReadLine();

                    lärare lärare = new lärare(namn, Person, adress, telefon, cash, new lärarKurser(kursen));
                    lärarlista.Add(lärare);
                }

                else if (key.Key == ConsoleKey.D)
                {
                    Console.Clear();
                    Console.Write("Namn: ");
                    string namn = Console.ReadLine();
                    Console.Write("Personnummer: ");
                    string Person = Console.ReadLine();
                    Console.Write("Adress: ");
                    string adress = Console.ReadLine();
                    Console.Write("Telefonnummer: ");
                    string Telefon = Console.ReadLine();
                    Console.Write("Klass: ");
                    string Klassen = Console.ReadLine();

                    Console.WriteLine("Hur många klasser vill du lägga till?");
                    int antal = Convert.ToInt32(Console.ReadLine());

                    List<string> kurstuff = new List<string>();
                    List<string> betygstuff = new List<string>();

                    string kursen="";
                    string dabetyg="";
                    for (int i = 0; i < antal; i++)
                    {
                        Console.Write("Kurs: ");
                        kursen = Console.ReadLine();
                        Console.Write("Betyg: ");
                        dabetyg = Console.ReadLine();
                        kurstuff.Add(kursen);
                        betygstuff.Add(dabetyg);
                    }
                    Elev hurrdurr = new Elev(namn, Person, adress, Telefon, Klassen);
                    for (int i = 0; i < kurstuff.Count; i++)
                    {
                        hurrdurr.setKurs(new Kurs(kurstuff[i], betygstuff[i]));
                    }
                    elevlista.Add(hurrdurr);
                }


                Console.Clear();
            }
        }
            
        class Person
        {
            private string namn;
            private string pnr;
            private string telenr;
            private string adress;

            public string getNamn() { return namn; }
            public void setNamn(string namn) { this.namn = namn; }

            public string getPnr() { return pnr; }
            public void setPnr(string personnummer) { this.pnr = personnummer; }

            public string getTeleNr() { return telenr; }
            public void setTeleNr(string telenr) { this.telenr = telenr; }

            public string getAdress() { return adress; }
            public void setAdress(string adress) { this.adress = adress; }
        }

        class lärare : Person
        {
            private string Lön;
            private List<lärarKurser> Kurs = new List<lärarKurser>();

            public string getLön() { return Lön; }
            public void setLön(string Lön) { this.Lön = Lön; }

            public List<lärarKurser> getKurs() { return Kurs; }
            public void setKurs(lärarKurser Kurs) { this.Kurs.Add(Kurs); }

            public void höjLön(string ändringLön)
            {
                setLön(Convert.ToString(Convert.ToInt32(getLön()) + Convert.ToInt32(ändringLön)));
            }

            public override string ToString()
            {
                List<lärarKurser> Kurs = getKurs();
                string kursstring = "";
                string text = "Namn: " + getNamn() + "\nPersonnummer: " + getPnr() + "\nAdress: " + getAdress()
                    + "\nTelefonnummer: " + getTeleNr() + "\nLön(CASHMONEY): " + getLön() + "\n";

                for (int i = 0; i < Kurs.Count; i++)
                {
                    kursstring += "Kurs: " + Kurs[i].kurs + "\n";
                }
                text += kursstring;


                return text;
            }

            public lärare(string Namn, string pNr, string Adress, string teleNr, string Lön, lärarKurser Kurs)
            {
                setAdress(Adress);
                setNamn(Namn);
                setPnr(pNr);
                setTeleNr(teleNr);
                setLön(Lön);
                setKurs(Kurs);
            }

        }

        class Elev : Person
        {
            private List<Kurs> Kurs = new List<Kurs>();
            private string Klass;

            public List<Kurs> getKurs() { return Kurs; }
            public void setKurs(Kurs Kurs) { this.Kurs.Add(Kurs); }

            public string getKlass() { return Klass; }
            public void setKlass(string Klass) { this.Klass = Klass; }

            public void fåBetygAvLärare(Kurs Kurs)
            {
                setKurs(Kurs);
            }

            public override string ToString()
            {
                List<Kurs> Kurs = getKurs();
                string kursstring = "";
                string text = "Namn: " + getNamn() + "\nPersonnummer: " + getPnr() + "\nAdress: " + getAdress()
                    + "\nTelefonnummer: " + getTeleNr() + "\nKlass: " + getKlass() + "\n" + "Kurser:\n";

                for (int i = 0; i < Kurs.Count; i++)
                {
                    kursstring += "Kurs: " + Kurs[i].Kursen + ", Betyg: " + Kurs[i].Betyg + "\n";
                }
                text += kursstring;


                return text;
            }

            public Elev(string Namn, string pNr, string Adress, string teleNr, string Klass)
            {
                setAdress(Adress);
                setNamn(Namn);
                setPnr(pNr);
                setTeleNr(teleNr);
                setKlass(Klass);
            }
        }

        public class Kurs
        {
            public string Kursen { get; set; }
            public string Betyg { get; set; }

            public Kurs(string kurs, string betyg)
            {
                this.Betyg = betyg;
                this.Kursen = kurs;
            }
        }
        public class lärarKurser
        {
            public string kurs { get; set; }
            public lärarKurser(string kurs) { this.kurs = kurs; }                           
        }
    }
}