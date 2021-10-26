using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_Exercise_19_1
{
    class Program_1
    {
        static void Main(string[] args)
        {
            List<Computer> myList = new List<Computer>()
            {
                new Computer(){ Сode = 000, MarkName = "Samsung", ProcessorType = "X-series", ProcessorFrequency = 3, RamSize = 4096, HdSize = 2, VideoCardMemory = 2, CostOfComputer = 70000, NumberOfCopiesAvailable = 5},
                new Computer(){ Сode = 111, MarkName = "Lenovo", ProcessorType = "Core", ProcessorFrequency = 1, RamSize = 2048, HdSize = 1, VideoCardMemory = 1, CostOfComputer = 40000, NumberOfCopiesAvailable = 9},
                new Computer(){ Сode = 222, MarkName = "Asus", ProcessorType = "Xeon", ProcessorFrequency = 3, RamSize = 4096, HdSize = 1, VideoCardMemory = 1, CostOfComputer = 50000, NumberOfCopiesAvailable = 3},
                new Computer(){ Сode = 333, MarkName = "Packard Bell", ProcessorType = "Atom", ProcessorFrequency = 1, RamSize = 1024 , HdSize = 1, VideoCardMemory = 1, CostOfComputer = 30000, NumberOfCopiesAvailable = 4},
                new Computer(){ Сode = 444, MarkName = "Toshiba", ProcessorType = "Core", ProcessorFrequency = 2, RamSize = 2048 , HdSize = 2, VideoCardMemory = 1, CostOfComputer = 45000, NumberOfCopiesAvailable = 30},
                new Computer(){ Сode = 555, MarkName = "Olidata", ProcessorType = "Pentium", ProcessorFrequency = 1, RamSize = 1024 , HdSize = 1, VideoCardMemory = 2, CostOfComputer = 35000, NumberOfCopiesAvailable = 4},
            };


            Console.WriteLine("Введите название необходимого процессора.");
            string correctProcessorType = Console.ReadLine();

            List<Computer> withCorrectProcessorType = myList
                .Where(c => c.ProcessorType == correctProcessorType)
                .Distinct()
                .ToList();

            Console.WriteLine($"В нашем магазине присутствуют {withCorrectProcessorType.Count} компьютеров с таким процессором:");
            
            foreach (Computer pc in withCorrectProcessorType)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();



            Console.WriteLine("Введите требуемый объем ОЗУ.");
            int requiredAmountRAM = Convert.ToInt32(Console.ReadLine());

            List<Computer> withCorrectRAM = myList
                .Where(c => c.RamSize >= requiredAmountRAM)
                .Distinct()
                .ToList();

            Console.WriteLine($"В нашем магазине присутствуют {withCorrectRAM.Count} компьютеров с таким количеством ОЗУ:");

            foreach (Computer pc in withCorrectRAM)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();

            Console.WriteLine("Выведем весь список компьютеров в наличии по возрастанию цены.");
            List<Computer> sortByCost = myList
                .OrderBy(s => s.CostOfComputer)
                .Distinct()
                .ToList();

            foreach (Computer pc in sortByCost)
            {
                Console.WriteLine($"Компьютер {pc.MarkName} за {pc.CostOfComputer}");
            }
            Console.WriteLine();


            Console.WriteLine("Выведем весь список компьютеров Сгруппированный по типу процессора.");
            var groupByProcessorType = myList
                .GroupBy(s => s.ProcessorType)
                .ToList();

            foreach (IGrouping<string, Computer> gr in groupByProcessorType)
            {
                Console.WriteLine($"С процессором {gr.Key}");
                foreach (var pc in gr)
                    Console.WriteLine($"    присутствует компьютер {pc.MarkName} за {pc.CostOfComputer}");
                
            }
            Console.WriteLine();


            Console.WriteLine($"Самым бюджетным компьютером является: {sortByCost.First().MarkName} за {sortByCost.First().CostOfComputer}");
            Console.WriteLine($"Самым дорогим компьютером является: {sortByCost.Last().MarkName} за {sortByCost.Last().CostOfComputer}");
            Console.WriteLine();

            Console.WriteLine("Выясним, есть ли хоть один компьютер в количестве не менее 30 штук");
            

            if (myList.Any(c => c.NumberOfCopiesAvailable >= 30))
            {
                Console.WriteLine("     - Да, есть модель в количестве не менее 30 штук!");
            }
            else
            {
                Console.WriteLine("     - Нет, к сожалению, нет ни одной модели в количестве не менее 30 штук.");
            }

            Console.ReadKey();
        }
    }


    class Computer
    {
        public int Сode { get; set; }
        public string MarkName { get; set; }
        public string ProcessorType { get; set; }
        public int ProcessorFrequency { get; set; }
        public int RamSize { get; set; }
        public int HdSize { get; set; }
        public int VideoCardMemory { get; set; }
        public int CostOfComputer { get; set; }
        public int NumberOfCopiesAvailable { get; set; }
    }
}
