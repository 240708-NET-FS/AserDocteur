using VotingApp.DAO;
using VotingApp.Service;

namespace VotingApp.Controller;

public class PresidentController
{

    private PresidentService presidentService;

    public PresidentController(PresidentService service)
    {
        presidentService = service;
    }


}