
namespace OrganizedList
{
    public class Program {
        public static int? SearchNumberInList(List<int> numList, int number)
        {
            for (int i=0; i<numList.Count; i++) {
                if (number == numList[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"The number is in position {i}");
                    Console.ResetColor();
                    return i;
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Not found!");
            Console.ResetColor();
            return 0;
        }            
        
        static void Main(string[] args) {
            List<int> list = new List<int>();
            Random randomNumbers = new Random();

            for (int i = 0; i < 15; i++) {
                list.Add(randomNumbers.Next(0, 100));
            }

            SearchNumberInList(list, 5);           
        }
    }
}