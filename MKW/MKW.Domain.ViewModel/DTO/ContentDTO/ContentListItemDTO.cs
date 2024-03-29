﻿using MKW.Domain.Dto.DTO.PlatformDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Dto.DTO.YoutubeDTO;
using MKW.Domain.Entities.ContentAggregate;

namespace MKW.Domain.Dto.DTO.ContentDTO
{
    public class ContentListItemDTO
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PlatformCategoryDTO Category { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double? AverageRating { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? Tags { get; set; }
        public int PlatformId { get; set; }

        public ContentListItemDTO()
        {

        }

        public ContentListItemDTO(Content? content) : this()
        {
            if (content is not null) AddContent(content);
        }

        public ContentListItemDTO(MovieDTO movie, Content? content = null) : this(content)
        {
            ExternalId = $"{movie.Id}";
            Name = movie.Title;
            Description = movie.Overview;
            ReleaseDate = DateTime.TryParse(movie.ReleaseDate, out var dataLancamento) ? dataLancamento : null;
            AverageRating = movie.VoteAverage;
            ImageUrl = movie.PosterPath;
            Tags = movie.Genres?.Select(x => x.Name).ToList();
        }

        public ContentListItemDTO(SearchResultDTO movie, Content? content = null) : this(content)
        {
            ExternalId = $"{movie.Id}";
            Name = movie.Title;
            Description = movie.Overview;
            ReleaseDate = DateTime.TryParse(movie.ReleaseDate, out var dataLancamento) ? dataLancamento : null;
            AverageRating = movie.VoteAverage;
            ImageUrl = movie.PosterPath;
        }

        public ContentListItemDTO(YoutubeItemDto channel, Content? content = null) : this(content)
        {
            ExternalId = channel.Id.ChannelId;
            Name = channel.Snippet.Title;
            Description = channel.Snippet.Description;
            ImageUrl = channel.Snippet?.Thumbnails?["high"].Url ?? channel.Snippet?.Thumbnails?["default"].Url;
            ReleaseDate = channel.Snippet?.PublishTime;
            AverageRating = 0;
        }

        public void AddContent(Content content)
        {
            Id = content.Id;
            PlatformId = content.PlatformCategory.PlatformId;
            AverageRating = Content.GetAverageRating(AverageRating, content);
        }
    }
}
