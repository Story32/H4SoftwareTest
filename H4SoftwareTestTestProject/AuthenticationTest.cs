using Bunit;
using Bunit.TestDoubles;
using H4SoftwareTest.Components.Pages;

namespace H4SoftwareTestTestProject;

public class AuthenticationTest
{
    [Fact]
    public void AuthenticationView()
    {
        // Arrange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        // Act
        var cut = ctx.RenderComponent<Home>();

        // Assert
        cut.MarkupMatches(@"<h1>Hello, world!</h1>
                        <br />
                        <h2>You are NOT admin</h2>
                        <br />
                        <div>
                            <h1>You must log in to see the content.</h1>
                        </div>");
    }


    [Fact]
    public void AuthenticationCode()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.False(homeObj._isAdmin);
    }

    [Fact]
    public void NotAuthenticationCode()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        //authContext.SetAuthorized("");

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.False(homeObj._isAdmin);
    }

    [Fact]
    public void AuthenticationCodeForUser()
    {
        //Arange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");
        authContext.SetRoles("Admin");

        //Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        //Assert
        Assert.True(homeObj._isAdmin);
    }
    [Fact]
    public void AuthenticationCodeLoggedInIsTrue()
    {
        // Arrange
        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        // Act
        var cut = ctx.RenderComponent<Home>();
        var homeObj = cut.Instance;

        // Assert
        Assert.False(homeObj._isAdmin);
    }

}