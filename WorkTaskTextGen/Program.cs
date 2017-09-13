using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Test
{
    public static void Main()
    {
        // путь к файлу
        string path = "C:\\Новая папка\\1c_to_klold.txt";
        {
            // Генерация номера из названия компа и даты 
            DateTime now = DateTime.Now;
            now.ToString("MMddHHssfff");
            String CN = Environment.GetEnvironmentVariable("computername");
            string substr = CN.Substring(CN.Length - 3);
            string createText = File.ReadAllText(path);
            int n = new Regex("КонецДокумента").Matches(createText).Count; //если документ пустой возвращает шляпу
            String Vanya = null; //
            if (n <= 0)
            {
                Console.WriteLine("n <= 0");
                Console.ReadKey();
            }
            else
            {
                string[] separators = { "КонецДокумента" };
                string[] texti = File.ReadAllText(path).Split(separators, StringSplitOptions.None);
                File.WriteAllText(path, "");
                for (int i = 0; i < n; i++)
                {
                    Vanya = Vanya + (Regex.Replace(texti[i], "Номер=[0-9]*", "Номер=" + (now.ToString("MMddHHssfff")) + (substr) + i)) + "КонецДокумента";
                }
                File.WriteAllText(path, Vanya);
            }
        }
    }
}