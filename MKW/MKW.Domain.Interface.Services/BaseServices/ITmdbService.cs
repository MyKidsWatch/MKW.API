namespace MKW.Domain.Interface.Services.BaseServices
{
    public interface ITmdbService
    {
        Task<object> GetMovie(int movieId);
    }
}