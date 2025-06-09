
using Tresele.crmbe.Models;
namespace Tresele.crmbe.Services.Interfaces;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    void Add(User user);
    bool Update(int id, User updatedUser);
    bool Delete(int id);
}