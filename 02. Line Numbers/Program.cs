namespace LineNumbers
{
    using System;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            
            string [] input = File.ReadAllLines(inputFilePath);

            
            string output=String.Empty;
            
            
            
      
            Console.WriteLine(string.Join(" ",input));
            string outP=string.Empty;
            int countForSymbol = 0;
            int count = 0;
            int allCount = 0;
            for (int i = 0; i < input.Length; i++)
            {
                allCount++;
                for (int j = 0; j < input[i].Length; j++)
                {
                    
                    int askiNum = input[i][j];

                    if (askiNum > 47 && askiNum < 57)
                    {
                        count++;
                    }
                    else if (askiNum > 64 && askiNum < 91)
                    {
                        count++;
                    }
                    else if (askiNum > 96 && askiNum < 123)
                    {
                        count++;
                    }
                    else if (askiNum == 32)
                    {
                        continue;
                    }
                    else
                    {
                        countForSymbol++;
                    }
                }
                //Console.WriteLine(string.Join(" ", input[i]));
                //Console.WriteLine($"{count} {countForSymbol}");
                //File.WriteAllText(input[i], outputFilePath);
                //File.WriteAllText($"{count} {countForSymbol}", outputFilePath);

                input[i] = $"Line {allCount}: {input[i]}" +
                    $"({count}) ({countForSymbol})";
                File.WriteAllLines(outputFilePath, input);
                count = 0;
                countForSymbol = 0;
            }
        }
    }
}
