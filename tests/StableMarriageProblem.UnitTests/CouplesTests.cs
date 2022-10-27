namespace StableMarriageProblem.UnitTests;

public class CouplesTests
{
    private readonly Couples sut;

    public CouplesTests()
    {
        sut = new Couples();
    }

    [Fact]
    public void Set_entities_as_engaged()
    {
        var e1 = new Entity();
        var e2 = new Entity();

        sut.Engage(e1, e2);

        Assert.Equal(e2, sut.GetPartner(e1));
    }

    [Fact]
    public void IsEngaged_should_return_true_when_the_given_entity_is_engaged()
    {
        var e1 = new Entity();
        var e2 = new Entity();

        sut.Engage(e1, e2);

        Assert.True(sut.IsEngaged(e1));
        Assert.True(sut.IsEngaged(e2));
    }

    [Fact]
    public void BreakEngagement_should_break_the_engagement()
    {
        var e1 = new Entity();
        var e2 = new Entity();

        sut.Engage(e1, e2);

        sut.BreakEngagement(e1);

        Assert.False(sut.IsEngaged(e1));
        Assert.False(sut.IsEngaged(e2));
    }
}