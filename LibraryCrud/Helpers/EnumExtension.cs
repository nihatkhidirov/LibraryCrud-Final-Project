using LibraryCrud.StableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCrud.Helpers
{
    public partial class Extension
    {
        public static Menu PrintMenu()
        {
            ConsoleColor tempColor = Console.ForegroundColor;

            Type type = typeof(Menu);
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"==================MENU================");
            foreach (var item in Enum.GetValues(typeof(Menu)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            Console.WriteLine($"======================================");
            Console.ForegroundColor = tempColor;
        l1: Console.WriteLine("Etmek Istediyiniz Emeliyyati Secin:");
            if (!Enum.TryParse<Menu>(Console.ReadLine(), out Menu selectedMenu)
                || !Enum.IsDefined(type, selectedMenu))
            {
                goto l1;
            }
            {

            }
            return selectedMenu;
        }
        public static T ReadEnum<T>(string caption)
            where T : Enum
        {
            ConsoleColor tempColor = Console.ForegroundColor;


            Type type = typeof(T);
            //Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"=================={type.Name}================");
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            Console.WriteLine($"======================================");
            Console.ForegroundColor = tempColor;
        l1: Console.WriteLine(caption);
            string enumStr = Console.ReadLine();
            if (!Enum.IsDefined(type, enumStr))
            {
                goto l1;

            }
            return (T)Convert.ChangeType(enumStr, type);

        }
    }
}
