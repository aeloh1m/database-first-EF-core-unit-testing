// See https://aka.ms/new-console-template for more information
using System;
using Microsoft.EntityFrameworkCore;
using EFCoreProject.Models;

public class Program
{
    private static HollywoodContext _context;

    static void Main(string[] args)
    {
        // Initialize the DbContext

        // Call the method to add a movie from input
        AddMovieFromInput();

        // Other application logic...
    }

    static void AddMovieFromInput()
    {
        // Get user input for movie details
        Console.WriteLine("Enter the movie name:");
        string data1 = Console.ReadLine();
        string movieName = data1;

        Console.WriteLine("Enter the movie genre:");
        string data2 = Console.ReadLine();
        string movieGenre = data2;

        Console.WriteLine("Enter the movie duration (in minutes):");
        int data3 = int.Parse(Console.ReadLine());
        int movieDuration = data3;

        Console.WriteLine("Enter the movie budget:");
        float data4 = float.Parse(Console.ReadLine());
        float movieBudget = data4;

        // Create a new movie object
        var movie = new Movie
        {
            MovieName = movieName,
            MovieGenre = movieGenre,
            MovieDuration = movieDuration,
            MovieBudget = movieBudget
        };

        // Add the movie to the database
        _context.Movies.Add(movie);
        _context.SaveChanges();

        Console.WriteLine("Movie added successfully!");
        
    }
}
