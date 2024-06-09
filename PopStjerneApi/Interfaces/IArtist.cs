using System.ComponentModel.DataAnnotations;

namespace PopStjerneApi.Interfaces;
public interface IArtist
{
    [Key]
    public int Id {get; set;}
    public string ArtistName {get; set;}
    public string Genre {get; set;}
    public string Image {get; set;}
}