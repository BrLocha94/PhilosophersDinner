using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinner
{
    public class Philosopher
    {
        public int id { get; private set; }

        public Fork leftFork { get; private set; }
        public Fork rightFork { get; private set; }

        private bool eatDinner = false;
        private bool pickedLeftFork = false;
        private bool pickedRightFork = false;

        private int thinkingTime = 1;
        private int hungryTime = 1;
        private int eatingTime = 1;
        private bool isEating = false;

        public Philosopher(int id)
        {
            this.id = id;
            thinkingTime += id;
            hungryTime += id; 
            eatingTime += id;
        }

        public void AddLeftFork(Fork fork) => leftFork = fork;
        public void AddRightFork(Fork fork) => rightFork = fork;
        public void FinishedDinner() => eatDinner = false;

        public async Task StartDinnerAsync()
        {
            eatDinner = true;

            while (eatDinner)
            {
                // Think
                Console.WriteLine("Philosopher {0} is thinking", id);
                await Task.Delay(TimeSpan.FromSeconds(thinkingTime));

                while (!isEating)
                {
                    // Hungry
                    Console.WriteLine("Philosopher {0} is hungry", id);
                    await Task.Delay(TimeSpan.FromSeconds(hungryTime));

                    // Pick Left Fork
                    if (!pickedLeftFork)
                    {
                        if (leftFork.isFree)
                        {
                            leftFork.PickUp();
                            Console.WriteLine("Philosopher {0} picked fork {1}", id, leftFork.id);
                            pickedLeftFork = true;
                        }
                    }

                    // Pick Right Fork
                    if (!pickedRightFork)
                    {
                        if (rightFork.isFree)
                        {
                            rightFork.PickUp();
                            Console.WriteLine("Philosopher {0} picked fork {1}", id, rightFork.id);
                            pickedRightFork = true;
                        }
                    }

                    // Try to eat
                    if(pickedLeftFork && pickedRightFork)
                    {
                        // Eat
                        isEating = true;
                        Console.WriteLine("Philosopher {0} is eating", id);
                        await Task.Delay(TimeSpan.FromSeconds(eatingTime));
                    }
                }

                // Finished eating
                isEating = false;

                leftFork.PutDown();
                pickedLeftFork = false;

                rightFork.PutDown();
                pickedRightFork = false;
            }
        }

        public void Debug()
        {
            Console.WriteLine("Philosopher {0} has left {1} and right {2} forks.", id, leftFork.id, rightFork.id);
        }
    }
}
