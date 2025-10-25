using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GenresClient
{
    public readonly Genre[] genres =
    [
         new()
        {
            Id = 1,
            Name = "Fighting"
        },
  new()
        {
            Id = 2,
            Name = "Sports"
        },
  new()
        {
            Id = 3,
            Name = "Racing"
        },
  new()
        {
            Id = 4,
            Name = "Kids And Family"
        }
    ];

    public Genre[] GetGenres() => genres;
}
