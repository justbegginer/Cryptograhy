using System;
using static Cryptograhy.BinaryOperation;
namespace Cryptograhy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Convert.ToInt32('1'));
            Console.WriteLine(ToBinary("1234"));
            Console.WriteLine(FromBinary("0000000000110100000000000011001100000000001100100000000000110001"));
            Console.ReadLine();
        }
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
            //string binary = Convert.ToString(Convert.ToInt32(ToBinary(textToConvert))^Convert.ToInt32(PSG));
            return "";
        }
    }

}
