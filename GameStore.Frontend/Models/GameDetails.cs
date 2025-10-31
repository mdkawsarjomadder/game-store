using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Components;
using GameStore.Frontend.Converters;
using StringConverter = GameStore.Frontend.Converters.StringConverter;


namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "The Genre Field Is Required.!")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }

    [Range(1,200)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
