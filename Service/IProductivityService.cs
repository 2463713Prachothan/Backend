using TimeTrack.API.DTOs.Productivity;

namespace TimeTrack.API.Service
{
    public interface IProductivityService
    {
        Task<ProductivityResponseDto> GetProductivityAsync(Guid userId);
    }
}