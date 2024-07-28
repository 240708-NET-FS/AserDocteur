using VotingApp.DAO;
using VotingApp.Entities;

namespace VotingApp.Service;

public class UserService : IService<User>
{
    private readonly UserDAO _userDao;

    public UserService(UserDAO userDao)
    {
        _userDao = userDao;
    }

    public void Create(User item)
    {
        throw new NotImplementedException();
    }

    public void Delete(User item)
    {
        throw new NotImplementedException();
    }

    public ICollection<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public User GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(User item)
    {
        throw new NotImplementedException();
    }
}