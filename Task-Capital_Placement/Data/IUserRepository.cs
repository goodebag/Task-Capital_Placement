using Task_Capital_Placement.Core.Entities;
using Task_Capital_Placement.Core.Models;

namespace Task_Capital_Placement.Data
{
    public interface IUserRepository
    {
        Task<User> CreateUser(UserCreationDTO data);
    }
}
