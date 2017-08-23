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
                "Search",
                "Exit"
            };

            var selection = showMenu(menuItems);

            while(selection != 6)
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

                    case 5:
                        SearchMovie();
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

            listMovies();
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
            Console.WriteLine("Please Select The Id Of The Movie You Want To Edit: \n");
            var movie = FindingMovieById();
            Console.ReadLine();

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
            Console.WriteLine("Insert The Id Of The Movie You Want To Delete: ");
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
            Console.WriteLine("\nList Of Movies \n");
            foreach (var Movie in movies)
            {
                Console.WriteLine($"Id: {Movie.Id} Name: {Movie.title} Auther: {Movie.auther} Genre: {Movie.genre} Length: {Movie.length}");
                Console.WriteLine("");
            }
            Console.WriteLine("");
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
                || selection > 6)
            {
                Console.WriteLine("You need to choose a number between 1-6");
            }

            
            return selection;
        }
        private static void SearchMovie()
        {
            Console.WriteLine("Enter video name: \n");
            var searchQuery = Console.ReadLine();
            Console.WriteLine("");

            foreach (Movie Movie in movies)
            {
                if (Movie.title.ToLower().Contains(searchQuery.ToLower()))
                {
                    Console.WriteLine(($"Id: {Movie.Id} Name: {Movie.title} Auther: {Movie.auther} Genre: {Movie.genre} Length: {Movie.length}\n"));
                }
            }
        }

    }
}
