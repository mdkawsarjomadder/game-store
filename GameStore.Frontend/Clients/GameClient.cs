using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GameClient
{
    private readonly List<GameSummary> games =
[
     new(){
        Id =1,
        Name = "Street Fighter IT",
        Genre = "Fighting",
        Price = 59.00M,
        ReleaseDate = new DateOnly(1999,10,05)
       },
         new(){
        Id =2,
        Name = "Final Fantasy XIV ",
        Genre = "Roleplaying",
        Price = 69.00M,
        ReleaseDate = new DateOnly(2010,11,10)
       },
         new(){
        Id = 3,
        Name = "FIFA 2023",
        Genre = "Sports",
        Price = 99.00M,
        ReleaseDate = new DateOnly(2022,09,15)
       }
];

    public GameSummary[] GatGames() => [.. games];
}
