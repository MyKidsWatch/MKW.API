using System.Text.Json.Serialization;

namespace MKW.Domain.Dto.DTO.TmdbDTO
{
    public class MovieDTO
    {
        [JsonPropertyName("adult")]
        public bool? Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("belongs_to_collection")]
        public object BelongsToCollection { get; set; }

        [JsonPropertyName("budget")]
        public long? Budget { get; set; }

        [JsonPropertyName("genres")]
        public List<GenreDTO> Genres { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("imdb_id")]
        public string ImdbId { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double? Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompanyDTO> ProductionCompanies { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountryDTO> ProductionCountries { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("revenue")]
        public long? Revenue { get; set; }

        [JsonPropertyName("runtime")]
        public int? Runtime { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<SpokenLanguageDTO> SpokenLanguages { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool? Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int? VoteCount { get; set; }
    }
}
