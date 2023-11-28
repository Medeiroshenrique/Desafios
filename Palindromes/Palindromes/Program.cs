namespace Palindromes{
    public class Program {
        public static bool IsPalindromeOrNot(string word) {
            string reverseWord ="";
            char[] wordChars = word.ToCharArray();
            for (int i = wordChars.Length -1; i >= 0; i--) {
                reverseWord += wordChars[i].ToString();
            }

            if (word == reverseWord)
            {
                Console.WriteLine("Palindrome!");
                return true;
            }
            else
            {
                Console.WriteLine("Not palindrome!");
                return false;
            }
        }
        public static void Main() {
            string RandomWord = "arara";
            IsPalindromeOrNot(RandomWord);
        }
    }
}