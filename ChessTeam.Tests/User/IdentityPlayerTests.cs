using System;
using ChessTeam.User;
using Xunit;

namespace ChessTeam.User.Tests;

public class IdentityPlayerTests
{
    private IEnumerable<string> _players;  
    [Fact]
    public void IdentityPlayer_IsUnique_()
    {
        _players = [];
        // Arrange
        var sut = new IdentityPlayer();
        Add(sut.Name);
        // Act
        for(int i = 0; i < 22952; i++)
        {
            var r = new IdentityPlayer();
            try
            {
                Assert.True(sut.Name != r.Name);
                Assert.True(sut.Id != r.Id);
                Add(r.Name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    private void Add(string name)
    {
        var re = _players.Contains(name);
        if (re)
            throw new Exception("variable trouver");
        var d = _players.ToList();
        d.Add(name);
        _players = d;
    }
}