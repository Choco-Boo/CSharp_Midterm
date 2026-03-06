using System;

namespace AnimeApp
{
    // -------------------------------------------------------
    // AnimeCharacter class definition
    // Represents an anime character with key attributes
    // -------------------------------------------------------
    class AnimeCharacter
    {
        // ---- Properties ----
        public string Name        { get; set; }  // Character's name or nickname
        public string AnimeSeries { get; set; }  // The anime series they belong to
        public int    PowerLevel  { get; set; }  // Numeric power level

        // ---- Constructor 1: Default constructor ----
        // Initializes properties to default placeholder values
        public AnimeCharacter()
        {
            Name        = "Unknown";
            AnimeSeries = "Unknown Series";
            PowerLevel  = 0;
        }

        // ---- Constructor 2: Full-parameter constructor ----
        // Initializes all properties with provided values
        public AnimeCharacter(string name, string animeSeries, int powerLevel)
        {
            Name        = name;
            AnimeSeries = animeSeries;
            PowerLevel  = powerLevel;
        }

        // ---- Constructor 3: Partial/copy constructor ----
        // Copies name and series from another character, lets caller set power level
        public AnimeCharacter(AnimeCharacter other, int newPowerLevel)
        {
            Name        = other.Name + " (Clone)";
            AnimeSeries = other.AnimeSeries;
            PowerLevel  = newPowerLevel;
        }

        // ---- Destructor ----
        // Called by garbage collector before object is reclaimed
        ~AnimeCharacter()
        {
            Console.WriteLine($"[Destructor] {Name} from {AnimeSeries} is being removed from memory.");
        }

        // ---- Static + operator overload ----
        // Creates a "fusion" character by combining two AnimeCharacters:
        //   - Fuses names together
        //   - Combines the series names
        //   - Averages the power levels
        public static AnimeCharacter operator +(AnimeCharacter a, AnimeCharacter b)
        {
            string fusedName   = a.Name + "-" + b.Name + " Fusion";
            string fusedSeries = a.AnimeSeries + " x " + b.AnimeSeries;
            int    fusedPower  = (a.PowerLevel + b.PowerLevel) / 2;

            return new AnimeCharacter(fusedName, fusedSeries, fusedPower);
        }

        // ---- ToString override ----
        // Provides a clean string representation of the character
        public override string ToString()
        {
            return $"Name: {Name} | Series: {AnimeSeries} | Power Level: {PowerLevel}";
        }
    }

    // -------------------------------------------------------
    // Main Program entry point
    // -------------------------------------------------------
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======= Anime Character App =======\n");

            // --- Object 1: Using default constructor ---
            AnimeCharacter char1 = new AnimeCharacter();
            Console.WriteLine("Character 1 (Default Constructor):");
            Console.WriteLine(char1);

            // --- Object 2: Using full-parameter constructor ---
            AnimeCharacter char2 = new AnimeCharacter("Goku", "Dragon Ball Z", 9001);
            Console.WriteLine("\nCharacter 2 (Full-Parameter Constructor):");
            Console.WriteLine(char2);

            // --- Object 3: Using partial/copy constructor ---
            // Copies char2's name and series, assigns new power level
            AnimeCharacter char3 = new AnimeCharacter(char2, 5000);
            Console.WriteLine("\nCharacter 3 (Copy/Partial Constructor from char2):");
            Console.WriteLine(char3);

            // --- Object 4: Using object initializer syntax ---
            AnimeCharacter char4 = new AnimeCharacter
            {
                Name        = "Naruto Uzumaki",
                AnimeSeries = "Naruto Shippuden",
                PowerLevel  = 8500
            };
            Console.WriteLine("\nCharacter 4 (Object Initializer):");
            Console.WriteLine(char4);

            // --- Operator + overload: Fuse char2 and char4 ---
            Console.WriteLine("\n=== Fusion Test: char2 + char4 ===");
            AnimeCharacter fusion = char2 + char4;
            Console.WriteLine("Fusion Result:");
            Console.WriteLine(fusion);

            Console.WriteLine("\n======= End of Program =======");

            // --- Force garbage collector to run destructors ---
            // Null out all references first so GC can collect them
            char1 = null!;
            char2 = null!;
            char3 = null!;
            char4 = null!;
            fusion = null!;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}