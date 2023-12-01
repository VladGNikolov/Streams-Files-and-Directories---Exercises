namespace EvenLines
{
    using System;
    using System.Reflection.Metadata.Ecma335;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            StreamWriter writer = new StreamWriter(@"..\..\..\output");

            using (streamReader)
            {
                using (writer)
                {
                    string line = streamReader.ReadLine();
                    string currentText = string.Empty;
                    int count = 0;
                    while (line != null)
                    {
                        if (count % 2 == 0)
                        {

                            string[] stringArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                            Array.Reverse(stringArray);
                            string currentString = string.Empty;
                            foreach (var item in stringArray)
                            {
                                currentString += item;
                                currentString += " ";
                            }
                            foreach (var item in currentString)
                            {
                                if (item==' ')
                                {
                                    continue;
                                }
                                if (item == '-' || item == ',' || item == '.' || item == '?' || item == '!')
                                {
                                    currentString=currentString.Replace(item.ToString(), "@");
                                }
                            }
                            

                            writer.WriteLine(currentString);
                        }
                        count++;
                        line = streamReader.ReadLine();
                    }

                }
            }
            StreamReader current = new StreamReader(@"..\..\..\output");
            using (current)
            {
                string cur = current.ReadToEnd();
                return cur;
            }
        }
    }
}
