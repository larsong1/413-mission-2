internal class Program
{
    class DiceSimulator
    {
        static void Main()
        {
            Console.Write("How many dice rolls would you like to simulate? ");
            int numberOfRolls = int.Parse(Console.ReadLine());

            DiceRoller diceRoller = new DiceRoller();
            int[] results = diceRoller.SimulateRolls(numberOfRolls);

            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");

            int totalRolls = results.Length;

            for (int i = 2; i <= 12; i++)
            {
                int percentage = results[i - 2] * 100 / numberOfRolls;
                string histogram = new string('*', percentage);
                Console.WriteLine($"{i}:\t{histogram}");
            }

            Console.WriteLine($"\nTotal number of rolls = {numberOfRolls}.");
        }
    }

    class DiceRoller
    {
        private Random random;

        public DiceRoller()
        {
            random = new Random();
        }

        public int[] SimulateRolls(int numberOfRolls)
        {
            int[] results = new int[11];

            for (int i = 0; i < numberOfRolls; i++)
            {
                int dice1 = random.Next(1, 7);
                int dice2 = random.Next(1, 7);

                int sum = dice1 + dice2;

                results[sum - 2]++;
            }

            return results;
        }
    }
}