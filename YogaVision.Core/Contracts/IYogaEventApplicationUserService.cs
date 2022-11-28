
namespace YogaVision.Core.Contracts
{
    public interface IYogaEventApplicationUserService
    {
        Task AddAsync(string yogaEventId, string ApplicationUserId);
        bool CheckUserInEvent(string yogaEventId, string ApplicationUserId);

        Task DeleteAsync(string yogaEventId, string ApplicationUserId);
    }
}
