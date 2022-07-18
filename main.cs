using System;
using System.Collections;
using System.Linq;

namespace MoviePlex
{
    internal class Main
    {
        //Globally Declare
        const int MaxMovie = 10;
        String option;
        Movie[] Movies = new Movie[MaxMovie];
        int count = 0;
        int num_of_movies = 0;

        //Welcome Function
        public void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************************************************");
            Console.WriteLine("*                                                                      *");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*                     Welcome to Movieplex Theatre                     *");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*                                                                      *");
            Console.WriteLine("************************************************************************");

            int counter = 0;
            //Loop to select option (Admin or Guest)
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nPlease select from the following option :");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n1. Administrator");
                Console.WriteLine("2. Guest");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nSelect the option : ");
                String userInput = Console.ReadLine();
                //To check value is correct or not and to catch error
                try
                {
                    int userEntry = 0;
                    if (int.TryParse(userInput, out userEntry))
                    {
                        if (userEntry == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Password password = new Password();
                            password.checkPassword();
                            admin();
                            break;
                        }
                        else if (userEntry == 2)
                        {
                            guest();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            throw new Exception("\nYou have selected a wrong option. Please select from 1 or 2.");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        UserException userException = new UserException("\nPlease enter numeric value. You have selected wrong option");
                        throw userException;
                    }
                }
                catch (UserException userException)
                {
                    Console.WriteLine(userException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (counter == 0);
        }

        //Admin Function
        public void admin()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n*************************************************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**                         Welcome MoviePlex Administrator                         **");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*************************************************************************************\n");
            int num = 0;
            //Loop to check to enter movies
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("How Many Movies are playing today? : ");
                String userInput = Console.ReadLine();
                // To Check the entered movies
                try
                {

                    if (int.TryParse(userInput, out num_of_movies))
                    {
                        if (num_of_movies > 10)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new Exception("\nMaximum 10 movies are allowed. Please Enter Again.");
                        }
                        else if (num_of_movies <= 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            throw new Exception("\nYou have to enter atleast 1 movie. Please Enter again.");
                        }
                        else
                        {
                            addMovies(num_of_movies);
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        UserException userException = new UserException("\nPlease enter numeric value. You have selected wrong option");
                        throw userException;
                    }
                }
                catch (UserException userException)
                {
                    Console.WriteLine(userException.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (num == 0);
        
        }
        //Guest Function
        public void guest()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************************************************");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("**                          Welcome to Guest                          **");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("************************************************************************\n");
            //If no movie in account. Display message
            if (num_of_movies == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("There is no Movie in Your Account.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nPress enter to get back to Main Session:");
                Console.ReadLine();
                Console.Clear();
                Welcome();
            }
            // otherwise start Working
            else 
            { 
                showMovies();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\nWhich Movie would you like to watch: ");
                Console.ForegroundColor = ConsoleColor.Green;
                chooseOptions();
            }
        }

        // Function To Add Entered Movies
        public void addMovies(int num_of_movies)
        {
            //Array for movies
            string[] array1 = { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eighth", "Ninth", "Tenth" };
            string[] array2 = array1.Take(num_of_movies).ToArray();
            // Array for Age
            ArrayList myAL = new ArrayList() { "G", "PG", "PG-13", "R", "NC-17", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" ,"14", "15", "16", "17"};
            string userKeyPress; 
            do
            {
                foreach (string s in array2)
                {
                    Movie movie = new Movie();
                    Console.WriteLine("");
                    Console.Write("Please Enter the " + s + " movie name : ");
                    string mvName = Console.ReadLine();

                    while (string.IsNullOrEmpty(mvName))
                    {
                        Console.Write("Movie Name can't be empty! Please Enter Movie Name: ");
                        mvName = Console.ReadLine();
                    }
                    movie.Name = mvName;
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write("Please Enter the Age Limit or Rating of the " + s + " Movie  : ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            userKeyPress = Console.ReadLine().ToUpper();
                        if (!myAL.Contains(userKeyPress))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please Enter Valid Age Limit or Rating (Range of Age Limit from 1 to 17)");
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                    }
                        while (!myAL.Contains(userKeyPress));
                        movie.Rating = userKeyPress;
                        Movies[count] = movie;
                        count++;

                }

            } while (count != num_of_movies);
            Console.WriteLine("");
            showMovies();
            confirmMovies();
        }
        
        //Fuction to choose an option by user/guest to watch a movie
        public void chooseOptions()
        {
            option = Console.ReadLine();
            int outOption;
            if (int.TryParse(option, out outOption))
            {
                if (((outOption) > (num_of_movies)) || ((outOption) <= 0))
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine("\nYou have choose the Wrong Option");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\nPress ENTER to reselect the movie choices.");
                    string hold = Console.ReadLine();
                    guest();
                }
                else
                {
                    Console.WriteLine("\nYou have selected the" + ' ' + Movies[outOption-1].Name + ' ' + "movie to watch");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("\nPlease enter your age for verification:\t");
                    string age = (Console.ReadLine());
                    int outAge;
                    if (int.TryParse(age, out outAge) && (outAge > 0 && outAge < 100))
                    {
                        if (isAllowedToWatch(outAge))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEnjoy the Movie.");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("\nPress M to go back to the Guest Main menu.");
                            Console.WriteLine("OR Press S to go back to the Start Page.");
                            String d = Console.ReadLine();

                            if (d == "M" || d == "m")
                            {
                                guest();
                            }
                            else if (d == "S" || d == "s")
                            {
                                Console.Clear();
                                Welcome();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nYou have selected a wrong Option. Press ENTER to go back to Guest Menu.");
                                Console.ReadLine();
                                guest();
                            }

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nSorry your not eligible to watch the movie, please select different movie");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("\nPress M to go back to the Guest Main menu.");
                            Console.WriteLine("OR Press S to go back to the Start Page.");
                            String d = Console.ReadLine();

                            if (d == "M" || d == "m")
                            {
                                guest();
                            }
                            else if (d == "S" || d == "s")
                            {
                                Console.Clear();
                                Welcome();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("\nYou have selected a wrong Option. Press ENTER to go back to Guest Menu.");
                                Console.ReadLine();
                                guest();
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou have not enter valid age (Hint: Age between [1-100])");
                        Console.Write("\nPress ENTER to Go back to Guest menu.");
                        string hold = Console.ReadLine();
                        guest();

                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\nYou have to Select the movie number Which you would like to watch.");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nPress ENTER to reselect the movie choice.");
                string hold = Console.ReadLine();
                guest();
            }

        }
      
        //To check Validation of Age
        public bool isAllowedToWatch(int n)
        {

            string rating = Movies[int.Parse(option) - 1].Rating;
            int inputAge;
            if (!int.TryParse(rating, out inputAge))
            {
                if (rating.Equals("G"))
                {
                    return true;
                }
                else if (rating.Equals("PG", StringComparison.OrdinalIgnoreCase) && n >= 10)
                {
                    return true;
                }
                else if (rating.Equals("PG-13", StringComparison.OrdinalIgnoreCase) && n >= 13)
                {
                    return true;
                }
                else if (rating.Equals("R", StringComparison.OrdinalIgnoreCase) && n >= 15)
                {
                    return true;
                }
                else if (rating.Equals("NC-17", StringComparison.OrdinalIgnoreCase) && n >= 17)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (n >= inputAge)
                {
                    return true;
                }
                else 
                {
                    return false;
                }
              
            }
        }

        //Function To show the entered movies
        public void showMovies()
        {
            for (int i = 0; i < num_of_movies; i++)
            {

                Console.WriteLine((i + 1) + ".  " + Movies[i].Name + " {" + Movies[i].Rating + "}");
            }

        }

        // Function to get confirmation regardin entered movies
        private void confirmMovies()
        {
            Console.WriteLine("");
            String ch;
            Console.Write("Your Movies playing today are Listed above. Are you Satisfied? (Y/N})? ");
            ch = Console.ReadLine();
            if (ch == "y")
            {
                Console.Clear();
                Welcome();
            }
            else if (ch == "n")
            {
                Console.Clear();
                Main main = new Main();
                main.admin();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Enter either Y or N");
                Console.ForegroundColor = ConsoleColor.Green;
                confirmMovies();
            }
        }

        class UserException : ApplicationException
        {
            private string msgDetails;
            public UserException() { }
            public UserException(string message)
            {
                msgDetails = message;
            }
            public override string Message => $"{msgDetails}";
        }
    }
}