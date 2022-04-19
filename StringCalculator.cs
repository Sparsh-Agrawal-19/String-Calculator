namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numberString)
        {
            if (string.IsNullOrEmpty(numberString))
            {
                return 0;
            }

            char[] seperator;
            if (numberString.StartsWith("//"))
            {
                seperator = new[] { numberString[2] };
                numberString = numberString.Substring(4);
            }
            else
            {
                seperator = new[] { ',', '\n' };

            }

            var numbers = numberString.Split(seperator).Select(int.Parse);
            var negativeNumbers = numbers.Where(n => n < 0);
            if (negativeNumbers.Any())
            {
                throw new Exception("Negative not allowed"
                    + (negativeNumbers.Count() == 1 ? string.Empty : ": " + String.Join(",", negativeNumbers)));
            }
            return numbers.Sum();
        }
        public event AddOccuredDelegate AddOccured;
        public delegate void AddOccuredDelegate(string input, int result);
    }
}