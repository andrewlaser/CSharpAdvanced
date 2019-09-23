using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    internal class Shooter
    {
        private Random rng = new Random();
        public delegate void KillingHandler(object sender, EventArgs e);

        public event KillingHandler KillingCompleted;

        public void OnShoot()
        {
            while (true)
            {
                if ((rng.Next(0, 100) % 2) == 0)
                {
                    if (KillingCompleted != null)
                    {
                        KillingCompleted.Invoke(this, EventArgs.Empty);
                    }
                }
                else
                {
                    Console.WriteLine("missed");
                }
                Thread.Sleep(500);
            }
        }
        
    }


    class Program
    {
        private static int score = 0;

        public static void KilledEnemy(object sender, EventArgs e)
        {
            Console.WriteLine("Killed enemy");
            Console.WriteLine($"Score: {score}");
        }

        public static void AddScore(object sender, EventArgs e)
        {
            score++;
        }

        static void Main(string[] args)
        {
            Shooter shooter = new Shooter();
            shooter.KillingCompleted += KilledEnemy;
            shooter.KillingCompleted += AddScore;
            shooter.OnShoot();

            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
