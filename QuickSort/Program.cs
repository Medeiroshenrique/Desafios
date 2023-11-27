using System;

namespace QuickSort
{
    public class Program
    {
        //Para ser sincero, tive que pesquisar como funciona o QuickSort(por ser interessante).
        //Após entender, pedi para o chatGPT criar um código em PORTUGOL 
        //para eu ter noção, então fiz o código parecido em C# e fui fazendo ajustes conforme
        //necessário. Mudei o nome das variáveis para o código ficar mais entendível inclusive.
   
        static void Main()
        {
            int[] array = new int[15];
            Random randomNumber = new Random();

            for (int i = 0; i < 15; i++)
            {
                array[i] = randomNumber.Next(100);
            }
            
            
            foreach (int i in array)
            {
                Console.Write(i  + " ");
            }
            Console.WriteLine("\n - - - - - - - - - - - - - - - - - - - - - -");

            QuickSort(array, 0, 14);

            foreach (int i in array)
            {
                Console.Write(i + " ");
            }
        }


        static void QuickSort(int[] values, int initialPosition, int end)
        {
            if (initialPosition < end)
            {
                int pivot = values[initialPosition];
                int FromLeftToRightRunner = initialPosition + 1;
                int FromRightToLeftRunner = end;


                while (FromLeftToRightRunner <= FromRightToLeftRunner)
                {
                    while (FromLeftToRightRunner <= FromRightToLeftRunner && values[FromLeftToRightRunner] <= pivot)
                    {
                        FromLeftToRightRunner++;
                    }

                    while (values[FromRightToLeftRunner] > pivot)
                    {
                        FromRightToLeftRunner--;
                    }

                    if (FromLeftToRightRunner <= FromRightToLeftRunner)
                    {
                        int temporaryToChangeValuesBetweenThem = values[FromLeftToRightRunner];
                        values[FromLeftToRightRunner] = values[FromRightToLeftRunner];
                        values[FromRightToLeftRunner] = temporaryToChangeValuesBetweenThem;

                        FromLeftToRightRunner++;
                        FromRightToLeftRunner--;
                    }
                }

                int temporaryToPutPivotAtCorrectPosition = values[initialPosition];
                values[initialPosition] = values[FromRightToLeftRunner];
                values[FromRightToLeftRunner] = temporaryToPutPivotAtCorrectPosition;

                QuickSort(values, initialPosition, FromRightToLeftRunner - 1);
                QuickSort(values, FromRightToLeftRunner + 1, end);
            }
        }
    }
}
  
