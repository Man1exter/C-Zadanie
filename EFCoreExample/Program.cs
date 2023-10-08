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
                // Create - Dodawanie nowego bloga
                var newBlog = new Blog { Name = "Moje blogowanie" };
                context.Blogs.Add(newBlog);
                context.SaveChanges();

                // Read - Wyświetlanie wszystkich blogów
                var blogs = context.Blogs.ToList();
                foreach (var blog in blogs)
                {
                    Console.WriteLine($"BlogId: {blog.BlogId}, Name: {blog.Name}");
                }

                // Update - Aktualizacja nazwy bloga
                var blogToUpdate = context.Blogs.First();
                blogToUpdate.Name = "Nowa nazwa bloga";
                context.SaveChanges();

                // Delete - Usunięcie bloga
                var blogToDelete = context.Blogs.First(b => b.Name == "Nowa nazwa bloga");
                context.Blogs.Remove(blogToDelete);
                context.SaveChanges();
            }
        }
    }
}
