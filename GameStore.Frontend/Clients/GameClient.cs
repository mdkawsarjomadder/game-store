using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients
{
    public class GameClient(HttpClient httpClient)
    {

 /*        private readonly List<GameSummary> games =
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
*/
        // public GameSummary[] GatGames() =>[.. games];
          public async Task<GameSummary[]> GetGamesAsync()
          => await httpClient.GetFromJsonAsync<GameSummary[]>("projects") ?? [];

        public async Task AddGameAsync(GameDetails game)
        => await httpClient.PostAsJsonAsync("projects", game);


        /*            ArgumentNullException.ThrowIfNull(game);
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
        */


        public async Task<GameDetails> GatGameAsync(int id)
         => await httpClient.GetFromJsonAsync<GameDetails>($"projects/{id}") ??
          throw new Exception("Could Not Find Game.!");
          
        /*       {
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
       */
        //Update code.!
        public async Task UpdategameAsync(GameDetails updateGame)
        => await httpClient.PutAsJsonAsync($"projects/{updateGame.Id}", updateGame);
        /*       {
                    var genre = GetGenreById(updateGame.GenreId);
                    GameSummary existingGame = GetGameSummaryById(updateGame.Id);
                    existingGame.Name = updateGame.Name;
                    existingGame.Genre = genre.Name;
                    existingGame.Price = updateGame.Price;
                    existingGame.ReleaseDate = updateGame.ReleaseDate;
                }
        */
        public async Task DateleGameAsync(int id)
        => await httpClient.DeleteAsync($"projects/{id}");
        /*        {
                    var game = GetGameSummaryById(id);
                    games.Remove(game);
                }
        */
/*
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
 */  
    }
}
