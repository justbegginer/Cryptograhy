using System;
using static Cryptograhy.BinaryOperation;
using System.IO;
namespace Cryptograhy
{ 
    class Program
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Выберите метод шифрования \n 1-С помощью регистра регистра сдвига с линейной обратной связью \n 2-Сеть Фейстеля \n 3-SP-сеть ");
            int number = Convert.ToInt32(Console.ReadLine());
            EncryptionMethods test = new EncryptionMethods(number);
            //Console.WriteLine(EncryptionMethods.ShiftRegister("1010"));
            //Console.WriteLine(ToBinary("1234"));
            //Console.WriteLine(FromBinary("0000000000110100000000000011001100000000001100100000000000110001"));
            //Console.WriteLine(XOR("1010","1011"));
            Console.ReadLine();
            using (StreamWriter output = new StreamWriter("OUTPUT.txt"))
            {

                output.WriteLine();

            }
        }
        StreamWriter output = new StreamWriter("Output"); 
    }
    class BinaryOperation
    {
        public static string ToBinary( string input )
        {
            int number = 0;
            string oneByte = "";
            string output = "";
            for (int counter = 0 ; counter<input.Length ; counter++)
            {
                number = Convert.ToInt32(input[counter]);              
                while (number>0)
                {               
                    oneByte = number % 2 +oneByte;
                    number /= 2;
                }
                for(int count = 16 ; count > oneByte.Length ; )
                {
                    oneByte = "0" + oneByte;
                }
                output = oneByte + output;
                oneByte = "";
            }
            return output;
        }
        public static string FromBinary( string input )
        {
            string output="";
            string twoBytes = "";
            int sum = 0;
            for (int counter = 0, extraCounter=0 ; counter <= input.Length; counter++,extraCounter++)
            {
                if (((counter ) % 16 == 0 & counter != 0) | counter==input.Length)
                {
                    Console.WriteLine("counter " + counter);
                    Console.WriteLine("two bytes " + twoBytes);
                    sum = 0;
                    for (int finiteCounter = 0; finiteCounter < twoBytes.Length; finiteCounter++)
                    {
                        if (twoBytes[finiteCounter] == '1')
                        {
                            sum += Convert.ToInt32(Math.Pow(2, 16 - finiteCounter - 1));
                        }
                    }
                    twoBytes = "";
                    Console.WriteLine(sum);
                    output = Convert.ToChar(sum) + output;                 
                }
                if (counter!=input.Length)
                {
                    twoBytes += input[extraCounter];
                }
            }
            return output;
            
        }
        public static string XOR ( string textToConvert , string PSG )
        {
            string binary="";
            for (int counter = 0 ; counter<textToConvert.Length ; counter++)
            {
                binary+=Convert.ToInt32(Convert.ToString(PSG[counter]))^Convert.ToInt32(Convert.ToString(textToConvert[counter]));
            }
            return binary;
        }
    }
    class EncryptionMethods
    {
        public static int EncryptionMethodsChoice;
        private static int Key;
        public EncryptionMethods(int number=0)
        {
            EncryptionMethodsChoice  = number;
            switch(EncryptionMethodsChoice)
            {
                case 1:
                    //ShiftRegister();
                    break;
                case 2:
                    Networks newCryptoSystem = new Networks(1);

                    break;
                case 3:
                    Networks newCryptoSystem0 = new Networks(2);
                    break;
            }
        }
        //private
        private string GeneratePSG(int Length)
        {
            string output = "";
            Random random = new Random();
            for (int counter = 0 ; counter<Length ; counter++)
            {
                output += Convert.ToString(random.Next(0,1));
            }
            return output;
        }
        private string ShiftRegister (string inputString)
        {
            string output = XOR(Convert.ToString(inputString[inputString.Length-1]),Convert.ToString(inputString[inputString.Length-2]));
            //Console.WriteLine(output);        
            //Console.WriteLine(inputString[counter]);
            inputString = inputString.Substring(1,inputString.Length-1) + output;
            return inputString;
        }
        class Networks
        {
            static int countOfRounds = 0;
            public Networks (int choice)
            {
                switch(choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                }
            }
            class SP_network
            {
                
                private int[] RoundKey;
                private string[][] S_table;
                private int[][] P_table;
                public SP_network(int rounds)
                {
                    
                    countOfRounds = rounds;
                    GenerateRoundKey();
                    Console.WriteLine("in system");
                    RoundKey = new int[countOfRounds];
                    S_table = new string[countOfRounds][];
                    P_table = new int[countOfRounds][];
                    //SP_networkGenerate();
                }

                private void SP_networkGenerate(string input, out string output)
                {
                    Console.WriteLine(S_table.Length + "     " + P_table.Length + "     " + RoundKey.Length);
                    Console.ReadLine();
                    output = input;
                    for (int counter = 0; counter < countOfRounds; counter++)
                    {
                        output = S_stage(output);
                        output = P_stage(output);
                        //XOR();
                    }

                }
                private static string S_stage(string inputString)
                {
                    return "";
                }
                private static string P_stage(string inputString)
                {
                    return "";
                }
               
            }
            class Feistel_network
            {

            }
            private static  void GenerateRoundKey()
            {
                for (int counter = 0; counter < countOfRounds; counter++)
                {

                }

            }
        }
    }
    class Process
    {
        public Process()
        {
            switch (EncryptionMethods.EncryptionMethodsChoice)
            {
                case 1:
                    break;
                case 2:
                    break;
            }

        }
    }
    class Writer
    {
        public Writer()
        {

        }
    }

}
