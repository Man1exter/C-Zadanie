using System;
using System.Linq;
using EFCoreExample.Models;

namespace EFCoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogContext())
            {
                while (true)
                {
                    Console.WriteLine("Wybierz opcję:");
                    Console.WriteLine("1. Wyświetl wszystkie blogi");
                    Console.WriteLine("2. Dodaj nowy blog");
                    Console.WriteLine("3. Edytuj blog");
                    Console.WriteLine("4. Wyjdź z programu");

                    var choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            // Read - Wyświetlanie wszystkich blogów
                            var blogs = context.Blogs.ToList();
                            Console.WriteLine("Lista blogów:");
                            foreach (var blog in blogs)
                            {
                                Console.WriteLine($"BlogId: {blog.BlogId}, Name: {blog.Name}");
                            }
                            break;

                        case "2":
                            // Create - Dodawanie nowego bloga
                            Console.WriteLine("Podaj nazwę nowego bloga:");
                            var newBlogName = Console.ReadLine();
                            var newBlog = new Blog { Name = newBlogName };
                            context.Blogs.Add(newBlog);
                            context.SaveChanges();
                            Console.WriteLine("Nowy blog został dodany.");
                            break;

                        case "3":
                            // Update - Edytowanie bloga
                            Console.WriteLine("Podaj BlogId bloga do edycji:");
                            if (int.TryParse(Console.ReadLine(), out var blogIdToUpdate))
                            {
                                var blogToUpdate = context.Blogs.FirstOrDefault(b => b.BlogId == blogIdToUpdate);
                                if (blogToUpdate != null)
                                {
                                    Console.WriteLine("Podaj nową nazwę bloga:");
                                    var newBlogNameToUpdate = Console.ReadLine();
                                    blogToUpdate.Name = newBlogNameToUpdate;
                                    context.SaveChanges();
                                    Console.WriteLine("Nazwa bloga została zaktualizowana.");
                                }
                                else
                                {
                                    Console.WriteLine("Blog o podanym BlogId nie istnieje.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Podano nieprawidłowy numer BlogId.");
                            }
                            break;

                        case "4":
                            // Wyjście z programu
                            return;

                        default:
                            Console.WriteLine("Nieprawidłowy wybór. Wybierz opcję od 1 do 4.");
                            break;
                    }
                }
            }
        }
    }
}

