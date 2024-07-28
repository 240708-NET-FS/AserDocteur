using VotingApp.DAO;
using VotingApp.Service;

namespace VotingApp.Controller;

public class UserController
{

    private UserService userService;

    public UserController(UserService service)
    {
        userService = service;
    }


}