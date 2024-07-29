using VotingApp.Utility;

namespace test_voting_app;

public class TestIntInputMethod
{
    [Fact]
    public void TestCorrectValidateIntMethod() {
        var Validator = new Validator();
        bool result = Validator.isInt("10");

        Assert.True(result, "Should be true");
    }

    [Fact]
    public void TestIncorrectValidateIntMethod() {
        var Validator = new Validator();
        bool result = Validator.isInt("Tacos");

        Assert.False(result, "Should be false");
    }
}