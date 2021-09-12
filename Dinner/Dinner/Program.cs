using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NumberOfPhilosophers = 4;

            StartDinnerAsync(NumberOfPhilosophers);

            Console.ReadLine();
        }

        private static async void StartDinnerAsync(int NumberOfPhilosophers)
        {
            Table table = new Table(NumberOfPhilosophers);

            List<Task> tasks = table.StartDinner();

            await Task.WhenAll(tasks);
        }
    }
}
