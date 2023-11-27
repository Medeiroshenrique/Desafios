namespace FibonacciAlgorithm
{
    public class Program
    {
        public static int[] GenerateFifteenFibonacciNumbers()
        {
            int firstNumber = 0, secondNum = 1;
            int[] Fibonacci = new int[15];

            Fibonacci[0] = firstNumber;
            Fibonacci[1] = secondNum;

            for (int counter = 2; counter < 15; counter++)
            {
                Fibonacci[counter] = Fibonacci[counter - 1] + Fibonacci[counter - 2];
            }


            foreach (int number in Fibonacci)
            {
                Console.WriteLine(number);
            }
            return Fibonacci;
        }

        static void Main(string[] args) {
            GenerateFifteenFibonacciNumbers();
        }

    }

}



