using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GameClient(HttpClient httpClient)
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

        private readonly Genre[] genres = new GenresClient(httpClient).GetGenres();

        public GameSummary[] GatGames() => [.. games];

        public void AddGame(GameDetails game)
        {
            ArgumentNullException.ThrowIfNull(game);
            ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);

            var genre = GetGenreById(game.GenreId);

            var gameSummary = new GameSummary
            {
                Id = games.Count + 1,
                Name = game.Name,
                Genre = genre.Name,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };

            games.Add(gameSummary);
        }

        public GameDetails GatGame(int id)
        {
            GameSummary game = GetGameSummaryById(id);

            var genre = genres.SingleOrDefault(g =>
                string.Equals(g.Name, game.Genre, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidOperationException($"Genre '{game.Genre}' not found.");

            return new GameDetails
            {
                Id = game.Id,
                Name = game.Name,
                GenreId = genre.Id.ToString(),
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }
        //Update code.!
        public void Updategame(GameDetails updateGame)
        {
            var genre = GetGenreById(updateGame.GenreId);
            GameSummary existingGame = GetGameSummaryById(updateGame.Id);
            existingGame.Name = updateGame.Name;
            existingGame.Genre = genre.Name;
            existingGame.Price = updateGame.Price;
            existingGame.ReleaseDate = updateGame.ReleaseDate;
        }
        public void DateleGame(int id)
        {
            var game = GetGameSummaryById(id);
            games.Remove(game);
        }

        private GameSummary GetGameSummaryById(int id)
        {
            GameSummary? game = games.Find(g => g.Id == id);
            ArgumentNullException.ThrowIfNull(game);
            return game;
        }

        
        private Genre GetGenreById(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Genre ID cannot be null or empty", nameof(id));

            return genres.Single(genre => genre.Id == int.Parse(id));
        }
    }
}
