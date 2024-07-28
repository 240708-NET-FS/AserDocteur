using System.Reflection.Metadata;
using VotingApp.DAO;
using VotingApp.Entities;
using VotingApp.Constants;

namespace VotingApp.DAO;

public class PresidentDAO : IDAO<President>
{
    private DbContextEF _context;

    public PresidentDAO(DbContextEF context)
    {
        _context = context;
    }

    public void Create(President president)
    {
        _context.President.Add(president);
        _context.SaveChanges();
    }

    public void Delete(President president)
    {
        _context.President.Remove(president);
        _context.SaveChanges();
    }

    public ICollection<President> GetAll()
    {
        List<President> presidents = _context.President.ToList();

        return presidents;
    }

    public President GetById(int ID)
    {
        President president = _context.President.FirstOrDefault(u => u.PresidentId == ID);

        return president;
    }

    public void Update(President newPresident)
    {
        President originalPresident = _context.President.FirstOrDefault(u => u.PresidentId == newPresident.PresidentId);

        if (originalPresident != null)
        {
            originalPresident.Name = newPresident.Name;
            originalPresident.Party = newPresident.Party;

            _context.President.Update(originalPresident);
            _context.SaveChanges();
        }

    }
}