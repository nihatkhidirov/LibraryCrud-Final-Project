using LibraryCrud.DataModels;
using LibraryCrud.Helpers;
using LibraryCrud.StableModels;
using LibraryCrud.Storage;
using System.Runtime.CompilerServices;

namespace LibraryCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Stores

            var authorstore = new GenericStore<Author>();
            var bookStore = new GenericStore<Book>();
            #endregion
            int id;
            Menu menu;
            Author author;
            Book book;
            bool allowforclear;


        l1:
            menu = Extension.PrintMenu();
            switch (menu)
            {
                case Menu.AuthorGetAll:
                    #region AuthorGetAll
                    Console.Clear();

                    if (authorstore.Length == 0)
                    {
                        Console.WriteLine("Muellif Adi Bosdur, Yeni Muellif Elave Edin...");
                        goto case Menu.AuthorAdd;
                    }
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    goto l1;
                    break;
                #endregion
                case Menu.AuthorAdd:
                    #region AuthorAdd
                    Console.Clear();
                    Console.Write("Muellif Adini Daxil Edin:");
                    string name = Console.ReadLine();
                    Author a = new Author();
                    a.Name = name;
                    authorstore.Add(a);
                    Console.WriteLine("Elave Olundu....");
                    goto l1;
                #endregion
                case Menu.AuthorFindByName:
                    break;
                case Menu.AuthorGetById:
                    #region AuthorGetById
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }

                    Console.WriteLine($"================= ========== ============");
                l2:
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        Console.WriteLine($"Bu Author Movcud Deyildir!");
                        goto l1;

                    }
                    Console.WriteLine(author);
                    goto l1;
                #endregion

                case Menu.AuthorEdit:
                    #region AuthotEdit
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        goto case Menu.AuthorEdit;
                    }
                    author.Name = Extension.ReadString("Deyistireceyiniz Author Adini Daxil Edin:");

                    goto case Menu.AuthorGetAll;
                #endregion
                case Menu.AuthorRemove:
                    #region AuthorRemove
                    Console.Clear();
                    Console.WriteLine($"==================Author=================");

                    foreach (var item in authorstore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                    id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    author = authorstore.Find(id);
                    if (author == null)
                    {
                        goto case Menu.AuthorRemove;
                    }
                    authorstore.Remove(author);
                    #endregion
                    goto case Menu.AuthorGetAll;
                    break;

                case Menu.BookAdd:
                    Console.Clear();
                    //if (bookStore.Length == 0)
                    //{
                    //    allowforclear = false;
                    //    Console.WriteLine("Muellif Yoxdur, Ilk Once Muellif Qeyd Olunmalidir!");
                    //    goto case Menu.AuthorAdd;
                    //}
                    book = new Book();
                    ShowAllAuthors(false);
                l5: id = Extension.ReadInteger("Author id: ", true, authorstore.Min(x => x.id), authorstore.Max(x => x.id));
                    if (book == null)
                    {
                        goto l5;
                    }
                    book = bookStore.Find(id);
                    if (book == null)
                    {
                        goto l5;
                    }
                    book.AuthorId = book.id;
                    book.Genre = Extension.ReadEnum<Genre>("Janri:");
                    book.PageNumber = Extension.ReadInteger("Sehife Sayi:", true, 20);
                    book.Price = Extension.ReadDecimal("Qiymet:", true, 3);
                    bookStore.Add(book);


                    break;

                case Menu.BookGetAll:
                    ShowAllBook(true);
                    goto l1;
                    Console.Clear();

                    if (authorstore.Length == 0)
                    {
                        Console.WriteLine("Kitab Bosdur, Yeni Kitab Elave Edin...");
                        goto case Menu.BookAdd;
                    }
                    Console.WriteLine($"==================Book=================");

                    foreach (var item in bookStore)
                    {
                        Console.WriteLine($"{item.id} {item.Name}");
                    }
                    Console.WriteLine($"================= ========== ============");
                case Menu.BookFindByName:
                    break;
                case Menu.BookGetById:
                    break;
                case Menu.BookEdit:
                    break;
                case Menu.BookRemove:
                    break;
                case Menu.ExitFromApp:
                    Console.WriteLine("Cixis Etmek Ucun Her Hansi Duymeni Sixin!");
                    Console.ReadKey();

                    break;
                default:
                    break;
            }


        }

        private static void ShowAllBook(bool clearbefore)
        {
            if(clearbefore)
            {
                Console.Clear();
            }
            Console.WriteLine($"==================Kitablar=================");

            foreach (var item in )
            {
                Console.WriteLine($"{item.id} {item.Name}");
            }
            Console.WriteLine($"================= ========== ============");
        }

        private static void ShowAllAuthors(bool v)
        {
            throw new NotImplementedException();
        }
    }

    }
