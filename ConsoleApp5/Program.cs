using System;
using System.Collections.Generic;

namespace ConsoleApp5
{ 
    public class Program
    {
        static int id = 0;
        static List<Movie> movies = new List<Movie>();

        static void Main(string[] args)
        {


            var movie1 = new Movie
            {
                Id = ++id,
                title = "Shark night",
                auther = "John John",
                genre = "Horror",
                length = "1.5 Hours"
            };
            movies.Add(movie1);

            movies.Add(new Movie()
            {
                Id = ++id,
                title = "A World Outside",
                auther = "Frank Darabont",
                genre = "Drama",
                length = "142 Min"
            });

        
        string[] menuItems =
            {
                "List All Movies",
                "Add Movie",
                "Delete Movie",
                "Edit Movie",
                "Exit"
            };

            var selection = showMenu(menuItems);

            while(selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        listMovies();
                        break;

                    case 2:
                        AddMovies();
                        break;

                    case 3:
                        DeleteMovie();
                        break;

                    case 4:
                        EditMovie();
                        break;

                    default:
                        
                        break;
                }
                selection = showMenu(menuItems);
            }
            Console.WriteLine("Bye Bye");
            
            Console.ReadLine();
        }

        private static Movie FindingMovieById()
        {
            Console.WriteLine("Insert The Id Of The Movie You Want To Delete: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please Insert A Number");
            }
            
            foreach (var movie in movies)
            {
                if (movie.Id == id)
                {
                    return movie;
                }
            }
            return null;
        }

        private static void EditMovie()
        {
            listMovies();
            var movie = FindingMovieById();
            
            Console.WriteLine();
            Console.WriteLine("Title: ");
            movie.title = Console.ReadLine();

            Console.WriteLine("Author: ");
            movie.auther = Console.ReadLine();

            Console.WriteLine("Genre: ");
            movie.genre = Console.ReadLine();

            Console.WriteLine("Length: ");
            movie.length = Console.ReadLine();
        }

        private static void DeleteMovie()
        {
            var movieFound = FindingMovieById();

            if(movieFound != null)
            {
                movies.Remove(movieFound);
            }
        }

        private static void AddMovies()
        {
            Console.WriteLine("Title: ");
            var Title = Console.ReadLine();

            Console.WriteLine("Auther: ");
            var Auther = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var Genre = Console.ReadLine();

            Console.WriteLine("Length: ");
            var Length = Console.ReadLine();

            movies.Add(new Movie()
            {
                Id = ++id,
                title = Title,
                auther = Auther,
                genre = Genre,
                length = Length
            });
        }

        private static void listMovies()
        {
            Console.WriteLine("\nList Of Movies");
            foreach (var Movie in movies)
            {
                Console.WriteLine($"Id: {Movie.Id} Name: {Movie.title} Auther: {Movie.auther} Genre: {Movie.genre} Length: {Movie.length}");
            }
            Console.WriteLine("\n");
        }

        private static int showMenu(string[] menuItems)
        {
            Console.WriteLine("Select what you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while(!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("You need to choose a number between 1-5");
            }

            
            return selection;
        }
        //private static void makeListMovies()
        //{
        //    Console.WriteLine("\nList Of Movies");
        //    foreach (var Movie in movies)
        //    {
        //        Console.WriteLine($"Id: {Movie.Id} Name: {Movie.title} Auther: {Movie.auther} Genre: {Movie.genre} Length: {Movie.length}");
        //    }
        //    Console.WriteLine("\n");
        //}

    }
}
