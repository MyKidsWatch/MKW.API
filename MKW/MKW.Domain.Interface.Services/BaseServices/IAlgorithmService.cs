﻿using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface IAlgorithmService
    {
        Task<BaseResponseDTO<IEnumerable<ReviewDto>>> GetReviewsByUserId(int page, int count);
        Task<List<Review>> GetRelevantReviews(int id, int page, int count);
        Task<List<Content>?> GetRecomendations(List<Review> reviews);
    }
}