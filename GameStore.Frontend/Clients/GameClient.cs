using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GameClient
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            Id = 1,
            Name = "Street Fighter II",
            Genre = "Fighting",
            Price = 59.00M,
            ReleaseDate = new DateOnly(1999, 10, 05)
        },
        new()
        {
            Id = 2,
            Name = "Final Fantasy XIV",
            Genre = "Roleplaying",
            Price = 69.00M,
            ReleaseDate = new DateOnly(2010, 11, 10)
        },
        new()
        {
            Id = 3,
            Name = "FIFA 2023",
            Genre = "Sports",
            Price = 99.00M,
            ReleaseDate = new DateOnly(2022, 09, 15)
        }
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GatGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);

        // GenreId ধরছি string (যেমন "1")
        var genre = genres.SingleOrDefault(g => g.Id.ToString() == game.GenreId)
            ?? throw new InvalidOperationException($"Genre with ID '{game.GenreId}' not found.");

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name, // ✅ Genre নাম সেট হচ্ছে
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    public GameDetails GatGame(int id)
    {
        var game = games.Find(g => g.Id == id);
        ArgumentNullException.ThrowIfNull(game);

        var genre = genres.SingleOrDefault(g =>
            string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase))
            ?? throw new InvalidOperationException($"Genre '{game.Genre}' not found.");

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreId = genre.Id.ToString(), // ✅ এখন genre Id ঠিকভাবে সেট হচ্ছে
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }
    
}
