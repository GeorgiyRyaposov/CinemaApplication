namespace Common.Models;

public class Details
{
    public int Id { get; set; }
    
    public int CinemaId { get; set; }
    public Cinema? Cinema { get; set; }
    
    public string Name { get; set; }
    public string AlternativeName { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public int Length { get; set; }
    public bool IsSeries { get; set; }
    
    public string[] Genres { get; set; }
    public string[] Countries { get; set; }
    
    public string LogoUrl { get; set; }
    public string PreviewUrl { get; set; }
    
    public double RatingImdb { get; set; }
    public double RatingKP { get; set; }
}