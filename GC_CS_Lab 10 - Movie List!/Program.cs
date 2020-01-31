using System;
using System.Collections.Generic;
using static GC_CS_Lab_10___Movie_List_.MyMethods;

namespace GC_CS_Lab_10___Movie_List_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>
            {
                new Movie("Terminator","scifi"),
                new Movie("The Hunger Games","scifi"),
                new Movie("Batman vs Teenage Mutant Ninja Turtles","animated"),
                new Movie("The Little Mermaid", "animated"),
                new Movie("Conspiracy Theory","drama"),
                new Movie("Caddyshack","comedy"),
                new Movie("A Nightmare on Elm Street 4: The Dream Master","horror"),
                new Movie("Godzilla vs Mothra","scifi"),
                new Movie("Blade Runner","scifi"),
                new Movie("Fatal Attraction","drama"),
                new Movie("Jay and Silent Bob Strike Back","comedy"),
                new Movie("Little Women","drama"),
                new Movie("The Godfather","drama"),
                new Movie("Scary Movie","comedy"),
                new Movie("Incredibles 2","animated"),
                new Movie("The Peanuts Movie","animated"),
                new Movie("Mrs. Doubtfire","comedy"),
                new Movie("Us","horror"),
                new Movie("The Texas Chainsaw Massacre","horror"),
                new Movie("It","horror")
            };

            List<string> genreList = new List<string>
            {
                "Scifi","Animated","Drama","Horror","Comedy"
            };

            int userGenreChoice;

            // Display title
            SetOutputColor();
            ShowTitle("Welcome to the Movie List Application!");
            
            string progOption = "y";

            // Specifies number of movies on the list.
            SetOutputColor();
            Console.WriteLine($"There are {movieList.Count} movies in this list.\n");
            
            // Operate program until user decides to terminate
            do
            {
                PrintGenreList(genreList);
                
                // Receive and validate user's input
                userGenreChoice = UserChoice("What category are you interested in? ", genreList);

                // Print list based on user's criteria
                PrintMovieOfGenre(userGenreChoice, genreList, movieList);

                // Prompt to repeat program
                progOption = TryAgain("Would you like to make another selection? [y/n]");
            }
            while (progOption == "y");

            ShowTitle("Thank you for running the Movie List program!");
            Console.ResetColor();
        }

        public static void PrintGenreList(List<string> genres)
        {
            SetOutputColor();
            Console.WriteLine("__________________________________________________");
            for (int i = 0; i < genres.Count; i++)
            {
                Console.WriteLine($"{i + 1})\t{genres[i]}");
            }
            Console.WriteLine("__________________________________________________\n");
        }
        
        public static int UserChoice(string msg, List<string> genres)
        {
            string userInput = GetUserInput(msg);
            int userOption;
            
            // check if input is an integer
            bool isInt = int.TryParse(userInput, out userOption);
            if (isInt)
            {
                // check if integer input is valid
                if ((userOption <= 0) || (userOption > genres.Count))
                {
                    SetOutputColor();
                    Console.WriteLine("This is not a valid choice. Either type a number or the actual genre of movie.\n");
                    return UserChoice(msg, genres);
                }
                else
                {
                    // valid integer value
                    return userOption;
                }
            }
            else
            {
                // check if input is valid string choice
                int textComp;

                // compare input against list of genres
                for (int i = 0; i < genres.Count; i++)
                {
                    if (userInput.ToLower() == genres[i].ToLower())
                    {
                        textComp = i + 1;
                        return textComp;
                    }
                }
                // Error message and remprompt
                SetOutputColor();
                Console.WriteLine("This is not a valid choice. Either type a number or the actual genre of movie.\n");
                return UserChoice(msg, genres);
            }
        }
        public static void PrintMovieOfGenre(int userGenreOption, List<string> genres, List<Movie> movies)
        {
            SetOutputColor();
            Console.WriteLine($"Here are the movies that are of the {genres[userGenreOption - 1]} genre:");
            foreach (Movie film in movies)
            {
                if (film.Category.ToLower().Contains(genres[userGenreOption - 1].ToLower()))
                {
                    Console.WriteLine(film.Title);
                }
            }
            Console.WriteLine();
        }

    }
}
