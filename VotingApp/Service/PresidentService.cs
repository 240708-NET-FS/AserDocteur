using VotingApp.DAO;
using VotingApp.Entities;

namespace VotingApp.Service;

public class PresidentService : IService<President>
{
    private readonly PresidentDAO _presidentDao;

    public PresidentService(PresidentDAO presidentDao)
    {
        _presidentDao = presidentDao;
    }

    public void Create(President item)
    {
        throw new NotImplementedException();
    }

    public void Delete(President item)
    {
        throw new NotImplementedException();
    }

    public ICollection<President> GetAll()
    {
        throw new NotImplementedException();
    }

    public President GetById(int Id)
    {
        throw new NotImplementedException();
    }

    public void Update(President item)
    {
        throw new NotImplementedException();
    }
}