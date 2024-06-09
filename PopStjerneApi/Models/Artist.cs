using System.ComponentModel.DataAnnotations;
using PopStjerneApi.Interfaces;

namespace PopStjerneApi.Models;

public class Artist : IArtist
{
    [Key]
    public int Id {get; set;}
    public string ArtistName {get; set;} = "";
    public string Genre {get; set;} = "";
    public string Image {get; set;} = "";
}