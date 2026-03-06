using System;

namespace MovieRating
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter a movie rating
            Console.Write("Enter a movie rating (G, PG, PG-13, R): ");
            string? input = Console.ReadLine();

            // Normalize input: trim whitespace and convert to uppercase
            string rating = input?.Trim().ToUpper() ?? string.Empty;

            // Use a switch expression to return a suitability comment
            string comment = rating switch
            {
                "G"     => "Suitable for all ages. Great for the whole family!",
                "PG"    => "Parental guidance suggested. Fine for children with adult supervision.",
                "PG-13" => "Not recommended for children under 13. Parents strongly cautioned.",
                "R"     => "Restricted. Viewers under 17 require a parent or guardian.",
                _       => "Unknown rating. Please enter G, PG, PG-13, or R."
            };

            // Output the rating and comment
            Console.WriteLine($"\nRating  : {rating}");
            Console.WriteLine($"Comment : {comment}");
        }
    }
}
