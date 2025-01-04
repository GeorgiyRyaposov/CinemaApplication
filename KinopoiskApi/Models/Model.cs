using Newtonsoft.Json;

namespace KinopoiskApi.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Backdrop
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("previewUrl")]
        public string PreviewUrl { get; set; }
    }

    public class Country
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Doc
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("alternativeName")]
        public string AlternativeName { get; set; }

        [JsonProperty("enName")]
        public string EnName { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("movieLength")]
        public int? MovieLength { get; set; }

        [JsonProperty("isSeries")]
        public bool IsSeries { get; set; }

        [JsonProperty("ticketsOnSale")]
        public bool TicketsOnSale { get; set; }

        [JsonProperty("totalSeriesLength")]
        public object TotalSeriesLength { get; set; }

        [JsonProperty("seriesLength")]
        public int? SeriesLength { get; set; }

        [JsonProperty("ratingMpaa")]
        public string RatingMpaa { get; set; }

        [JsonProperty("ageRating")]
        public int? AgeRating { get; set; }

        [JsonProperty("top10")]
        public object Top10 { get; set; }

        [JsonProperty("top250")]
        public object Top250 { get; set; }

        [JsonProperty("typeNumber")]
        public int TypeNumber { get; set; }

        [JsonProperty("status")]
        public object Status { get; set; }

        [JsonProperty("names")]
        public List<Name> Names { get; set; }

        [JsonProperty("externalId")]
        public ExternalId ExternalId { get; set; }

        [JsonProperty("logo")]
        public Logo Logo { get; set; }

        [JsonProperty("poster")]
        public Poster Poster { get; set; }

        [JsonProperty("backdrop")]
        public Backdrop Backdrop { get; set; }

        [JsonProperty("rating")]
        public Rating Rating { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("countries")]
        public List<Country> Countries { get; set; }

        [JsonProperty("releaseYears")]
        public List<object> ReleaseYears { get; set; }
    }

    public class ExternalId
    {
        [JsonProperty("imdb")]
        public string Imdb { get; set; }

        [JsonProperty("tmdb")]
        public int Tmdb { get; set; }

        [JsonProperty("kpHD")]
        public string KpHD { get; set; }
    }

    public class Genre
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Logo
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("previewUrl")]
        public object PreviewUrl { get; set; }
    }

    public class Name
    {
        [JsonProperty("name")]
        public string Title { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Poster
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("previewUrl")]
        public string PreviewUrl { get; set; }
    }

    public class Rating
    {
        [JsonProperty("kp")]
        public double Kp { get; set; }

        [JsonProperty("imdb")]
        public double Imdb { get; set; }

        [JsonProperty("filmCritics")]
        public double FilmCritics { get; set; }

        [JsonProperty("russianFilmCritics")]
        public double RussianFilmCritics { get; set; }

        [JsonProperty("await")]
        public int? Await { get; set; }
    }

    public class Root
    {
        [JsonProperty("docs")]
        public List<Doc> Docs { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("pages")]
        public int Pages { get; set; }
    }

    public class Votes
    {
        [JsonProperty("kp")]
        public int Kp { get; set; }

        [JsonProperty("imdb")]
        public int Imdb { get; set; }

        [JsonProperty("filmCritics")]
        public int FilmCritics { get; set; }

        [JsonProperty("russianFilmCritics")]
        public int RussianFilmCritics { get; set; }

        [JsonProperty("await")]
        public int Await { get; set; }
    }

