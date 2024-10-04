using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace PrimeNumbersAgain
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, prime;
            var timer = new Stopwatch();

            PrintBanner();
            n = GetNumber();

            timer.Start();
            prime = FindNthPrime(n);
            timer.Stop();
            
            
            Console.WriteLine($"\nToo easy.. {prime} is the nth prime when n is {n}. I found that answer in {timer.Elapsed.Seconds} seconds.");

            EvaluatePassingTime(timer.Elapsed.Seconds);
        }

        static int FindNthPrime(int n)
        {
            n -= 1;
            int MAX_SIZE = 100000000;
            List<int> primes = new();

            //static bool IsPrime(int n) => Enumerable.Range(2, (int)Math.Sqrt(n) - 1).All(i => n % i != 0);
            //return 0;

            bool[] isPrime = new bool[MAX_SIZE];

        for (var i = 0; i < MAX_SIZE; i++)
                isPrime[i] = true;

            for (var p = 2; p * p < MAX_SIZE; p++)
            {
                // If IsPrime[p] is not changed,
                // then it is a prime 
                if (isPrime[p] == true)
                {
                    // Update all multiples of p greater than or 
                    // equal to the square of it 
                    // numbers which are multiple of p and are 
                    // less than p^2 are already been marked. 
                    for (int i = p * p; i < MAX_SIZE; i += p)
                        isPrime[i] = false;
                }
            }

            // Store all prime numbers 
            for (var p = 2; p < MAX_SIZE; p++)
            {
                if (isPrime[p] == true)
                    primes.Add(p);
            }


            return primes[n];
        }
    


        static int GetNumber()
        {
            int n = 0;
            while (true)
            {
                Console.Write("Which nth prime should I find?: ");
                
                string num = Console.ReadLine();
                if (Int32.TryParse(num, out n))
                {
                    return n;
                }

                Console.WriteLine($"{num} is not a valid number.  Please try again.\n");
            }
        }

        static void PrintBanner()
        {
            Console.WriteLine(".................................................");
            Console.WriteLine(".#####...#####...######..##...##..######...####..");
            Console.WriteLine(".##..##..##..##....##....###.###..##......##.....");
            Console.WriteLine(".#####...#####.....##....##.#.##..####.....####..");
            Console.WriteLine(".##......##..##....##....##...##..##..........##.");
            Console.WriteLine(".##......##..##..######..##...##..######...####..");
            Console.WriteLine(".................................................\n\n");
            Console.WriteLine("Nth Prime Solver O-Matic Online..\nGuaranteed to find primes up to 2 million in under 3 seconds!\n\n");
            
        }

        static void EvaluatePassingTime(int time)
        {
            Console.WriteLine("\n");
            Console.Write("Time Check: ");

            if (time <= 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pass");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fail");
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            
        }
    }
}
