using System.Reflection.Metadata;
using VotingApp.DAO;
using VotingApp.Entities;

namespace VotingApp.DAO;

public class UserDAO : IDAO<User>
{
    private DbContextEF _context;

    public UserDAO(DbContextEF context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.User.Remove(user);
        _context.SaveChanges();
    }

    public ICollection<User> GetAll()
    {
        List<User> users = _context.User.ToList();

        return users;
    }

    public User GetById(int ID)
    {
        User user = _context.User.FirstOrDefault(u => u.UserId == ID);

        return user;
    }

    public void Update(User newUser)
    {
        User originalUser = _context.User.FirstOrDefault(u => u.UserId == newUser.UserId);

        if (originalUser != null)
        {
            originalUser.Name = newUser.Name;
            originalUser.PresidentId = newUser.PresidentId;
            originalUser.President = newUser.President;

            _context.User.Update(originalUser);
            _context.SaveChanges();
        }

    }
}