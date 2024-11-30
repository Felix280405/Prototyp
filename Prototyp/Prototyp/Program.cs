using System;
using System.Collections.Generic;

namespace Prototyp
{
    public class Wartungsarbeit
    {
        public string Anlage { get; set; }
        public DateTime Datum { get; set; }
        public string Beschreibung { get; set; }
        public bool Abgeschlossen { get; set; }

        public Wartungsarbeit(string anlage, DateTime datum, string beschreibung)
        {
            Anlage = anlage;
            Datum = datum;
            Beschreibung = beschreibung;
            Abgeschlossen = false;
        }

        public void MarkiereAlsAbgeschlossen()
        {
            Abgeschlossen = true;
        }

        public override string ToString()
        {
            return $"Anlage: {Anlage}, Datum: {Datum.ToShortDateString()}, Beschreibung: {Beschreibung}, Abgeschlossen: {Abgeschlossen}";
        }
    }

    public class WartungsPlaner
    {
        private List<Wartungsarbeit> wartungsarbeiten;

        public WartungsPlaner()
        {
            wartungsarbeiten = new List<Wartungsarbeit>();
        }

        public void PlaneWartungsarbeit(string anlage, DateTime datum, string beschreibung)
        {
            Wartungsarbeit neueArbeit = new Wartungsarbeit(anlage, datum, beschreibung);
            wartungsarbeiten.Add(neueArbeit);
        }

        public void DokumentiereWartungsarbeiten()
        {
            foreach (var arbeit in wartungsarbeiten)
            {
                Console.WriteLine(arbeit);
            }
        }

        public void MarkiereArbeitAlsAbgeschlossen(string anlage, DateTime datum)
        {
            foreach (var arbeit in wartungsarbeiten)
            {
                if (arbeit.Anlage == anlage && arbeit.Datum == datum)
                {
                    arbeit.MarkiereAlsAbgeschlossen();
                    break;
                }
            }
        }

        public void BenutzerEingabe()
        {
            Console.WriteLine("Geben Sie die Anlage ein:");
            string anlage = Console.ReadLine();

            Console.WriteLine("Geben Sie das Datum ein (yyyy-mm-dd):");
            DateTime datum = DateTime.Parse(Console.ReadLine());
            

            Console.WriteLine("Geben Sie die Beschreibung ein:");
            string beschreibung = Console.ReadLine();

            PlaneWartungsarbeit(anlage, datum, beschreibung);
        }

        public void ZeigeMenü()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Menü:");
                Console.WriteLine("1. Wartungsarbeit planen");
                Console.WriteLine("2. Wartungsarbeiten ansehen");
                Console.WriteLine("3. Wartungsarbeit als abgeschlossen markieren");
                Console.WriteLine("4. Beenden");
                Console.Write("Wählen Sie eine Option: ");
                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        BenutzerEingabe();
                        break;
                    case "2":
                        DokumentiereWartungsarbeiten();
                        break;
                    case "3":
                        Console.WriteLine("Geben Sie die Anlage ein, die als abgeschlossen markiert werden soll:");
                        string anlage = Console.ReadLine();
                        Console.WriteLine("Geben Sie das Datum ein (yyyy-mm-dd):");
                        DateTime datum = DateTime.Parse(Console.ReadLine());
                        MarkiereArbeitAlsAbgeschlossen(anlage, datum);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                        break;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            WartungsPlaner planer = new WartungsPlaner();
            planer.ZeigeMenü();
        }
    }
}
