using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using d02_ex00.Model;

Console.WriteLine("Input search text:");
string toFind = Console.ReadLine();

string fileNameBook = "ex00 example files/book_reviews.json";
string jsonStringBook = File.ReadAllText(fileNameBook);
string fileNameMovie = "ex00 example files/movie_reviews.json";
string jsonStringMovie = File.ReadAllText(fileNameMovie);

BookReviews listBooks = JsonSerializer.Deserialize<BookReviews>(jsonStringBook);
MovieReviews listMovies = JsonSerializer.Deserialize<MovieReviews>(jsonStringMovie);
List<ISearchable> listISearchable = new();
if (listBooks != null) listISearchable.AddRange(listBooks.Results);
if (listMovies != null) listISearchable.AddRange(listMovies.Results);

var media = from mediaToFind in listISearchable
    where mediaToFind.Title.ToLower().Contains(toFind.ToLower())
    group mediaToFind by mediaToFind.MediaType;

var books = (from booksInMedia in media
    where booksInMedia.Key == "book"
    select booksInMedia).SelectMany(group => group).ToList(); 


var movies = (from moviesInMedia in media
    where moviesInMedia.Key == "movie"
    select moviesInMedia).SelectMany(group => group).ToList();

if (books.Count == 0 && movies.Count == 0)
{
    Console.WriteLine($"There are no “{toFind}” in media today.", toFind);
    return ;
}
Console.WriteLine($"\nItems found: {books.Count + movies.Count}", books.Count + movies.Count);

if (books.Count > 0)
    Console.WriteLine($"\nBook search result [{books.Count}]: ", books.Count);
foreach (var booksItem in books)
{
    Console.WriteLine(booksItem);
}

if (movies.Count > 0)
    Console.WriteLine($"\nMovie search result [{movies.Count}]: ", movies.Count);

foreach (var moviesItem in movies)
{
    Console.WriteLine(moviesItem);
}

public class BookReviews
{
    [JsonPropertyName("results")]
    public List<Book> Results { get; set; } = new List<Book>();
}

public class MovieReviews
{
    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; } = new List<Movie>();
}
