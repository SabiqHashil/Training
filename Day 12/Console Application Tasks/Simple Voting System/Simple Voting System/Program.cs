using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Voting_System
{
    internal class Program
    {
        static void Main()
        {
            // To store candidates and their vote count
            Dictionary<string, int> candidates = new Dictionary<string, int>
        {
            { "Candidate1", 0 },
            { "Candidate2", 0 },
            { "Candidate3", 0 }
        };

            Console.WriteLine("Welcome to the Voting System!");
            Console.WriteLine("Here are the candidates:");
            int i = 1;
            foreach (var candidate in candidates.Keys)
            {
                Console.WriteLine($"{i}. {candidate}");
                i++;
            }

            Console.Write("Enter the number of the candidate you want to vote for: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= candidates.Count)
            {
                string selectedCandidate = GetCandidateByIndex(candidates, choice);
                candidates[selectedCandidate]++;
                Console.WriteLine($"You voted for {selectedCandidate}.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }

            Console.WriteLine("Thank you for participating in the voting!");
        }

        // Function to get candidate by index
        static string GetCandidateByIndex(Dictionary<string, int> candidates, int index)
        {
            int i = 1;
            foreach (var candidate in candidates.Keys)
            {
                if (i == index)
                    return candidate;
                i++;
            }
            return null;
        }
    }
}
