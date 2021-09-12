using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner
{
    public class Table
    {
        List<Philosopher> philosophersList;

        public Table(int NumberOfPhilosophers)
        {
            philosophersList = new List<Philosopher>();

            for(int i = 0; i < NumberOfPhilosophers; i++)
            {
                Philosopher philosopher = new Philosopher(i);
                philosophersList.Add(philosopher);

                Fork fork = new Fork(i);
                philosopher.AddLeftFork(fork);

                if (i > 0)
                {
                    philosophersList[i - 1].AddRightFork(fork);
                }

                if (i == NumberOfPhilosophers - 1)
                {
                    philosophersList[i].AddRightFork(philosophersList[0].leftFork);
                }
            }
        }

        public List<Task> StartDinner()
        {
            List<Task> tasks = new List<Task>();

            foreach (Philosopher philosopher in philosophersList)
            {
                tasks.Add(philosopher.StartDinnerAsync());
            }

            return tasks;
        }

        public void Debug()
        {
            foreach(Philosopher philosopher in philosophersList)
            {
                philosopher.Debug();
            }
        }
    }
}
