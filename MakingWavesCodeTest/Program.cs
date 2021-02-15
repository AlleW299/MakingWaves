using MakingWavesCodeTest.Controller;
using MakingWavesCodeTest.Entitiy;
using MakingWavesCodeTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MakingWavesCodeTest
{
    class Program
    {
        /// <summary>
        /// Code optimized for berevity not readablity
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Making Waves Code test");
            Console.WriteLine("-------------------------------");

            // Get data
            var colorGroups = new List<IEnumerable<Data>>();
            var task = Task.Run(async () => await new DataPageService().GetAllDataPages());
            var results = task.GetAwaiter().GetResult();
            var allColors = results.SelectMany(o => o.Data);

            // Group 1: Based on the first part of the “pantone_value” field. If this value is divisible by 3 (with no remainders) then the item should be included in this group.
            colorGroups.Add(allColors.Where(d =>  Convert.ToInt32(d.Pantone_Value.Split('-')[0]) % 3 == 0).OrderByDescending(o => o.Year));
            // Group 2: Based on the first part of the “pantone_value” field. If this value is divisible by 2 (with no remainders) AND it is not included in group 1 then the item should be included in this group.
            colorGroups.Add(allColors.Where(d => Convert.ToInt32(d.Pantone_Value.Split('-')[0]) % 2 == 0).Where(p => colorGroups[0].All(p2 => p2.ID != p.ID)).OrderByDescending(o => o.Year));
            // Group 3: Include any items that does not fit the criteria of group 1 or 2.
            colorGroups.Add(allColors.Where(p => colorGroups[0].All(p2 => p2.ID != p.ID)).Where(p => colorGroups[1].All(p2 => p2.ID != p.ID)).OrderByDescending(o => o.Year));
           
            var groupNr = 0;
            foreach (var colorGroup in colorGroups)
            {
                groupNr++;
                Console.WriteLine("");
                Console.WriteLine(string.Format("-- Group {0} --------------------", groupNr));
                foreach (var color in colorGroup)
                {
                    Console.WriteLine(string.Format("{0} : {1}   {2}", color.Pantone_Value, color.Year, color.Name));
                }
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------"); 
            Console.WriteLine("Press any key to exit.");
            var Alle = Console.ReadKey();
        }



    }
}
