using System.Threading.Tasks;

namespace Semkovo.Services
{
    public interface IUserService
    {
        Task<bool> JoinAsync(string userName, int eventId);

        Task<bool> SignOutAsync(string userName, int eventId);
    }
}
