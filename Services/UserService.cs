
using Tresele.crmbe.Models;
using Tresele.crmbe.Services.Interfaces;
namespace Tresele.crmbe.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new()
    {
        new User(1,"Leonardo","llanesleonardo@gmail.com"),
    };

    public IEnumerable<User> GetAll() => _users;

    public User? GetById(int id) => _users.FirstOrDefault(u => u.Id == id);

    public void Add(User user) => _users.Add(user);

    public bool Update(int id, User updatedUser)
    {
        var existingUser = GetById(id);
        if (existingUser == null) return false;

        _users.Remove(existingUser);
        _users.Add(updatedUser);
        return true;
    }

    public bool Delete(int id)
    {
        var user = GetById(id);
        if (user == null) return false;

        _users.Remove(user);
        return true;
    }
}