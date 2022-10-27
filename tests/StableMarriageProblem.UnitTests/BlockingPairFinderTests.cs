namespace StableMarriageProblem.UnitTests;

public class BlockingPairFinderTests
{
    [Fact]
    public void Should_return_false_when_there_is_no_blocking_pair()
    {
        var male1 = new Entity();
        var male2 = new Entity();
        var female1 = new Entity();
        var female2 = new Entity();

        male1.SetPreferenceList(new Entity[] { female1, female2 });
        female1.SetPreferenceList(new Entity[] { male1, male2 });

        male2.SetPreferenceList(new Entity[] { female1, female2 });
        female2.SetPreferenceList(new Entity[] { male2, male1 });

        var couples = new Couples();
        couples.Engage(male1, female1);
        couples.Engage(male2, female2);

        var sut = new BlockingPairFinder();

        Assert.False(sut.Exists(couples, new Entity[] { male1, male2 }));
    }

    [Fact]
    public void Should_return_true_when_there_is_an_unstable_marriage()
    {
        var male1 = new Entity();
        var male2 = new Entity();
        var female1 = new Entity();
        var female2 = new Entity();

        male1.SetPreferenceList(new Entity[] { female1, female2 });
        female1.SetPreferenceList(new Entity[] { male1, male2 });

        male2.SetPreferenceList(new Entity[] { female1, female2 });
        female2.SetPreferenceList(new Entity[] { male2, male1 });

        var couples = new Couples();
        couples.Engage(male1, female2);
        couples.Engage(male2, female1);

        var sut = new BlockingPairFinder();

        Assert.True(sut.Exists(couples, new Entity[] { male1, male2 }));
    }
}