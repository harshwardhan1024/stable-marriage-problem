namespace StableMarriageProblem.UnitTests;

public class GaleShapleyAlgorithmTests
{
    private readonly GaleShapleyAlgorithm sut;

    public GaleShapleyAlgorithmTests()
    {
        sut = new GaleShapleyAlgorithm();
    }

    [Fact]
    public void Produces_a_stable_marriage()
    {
        var man1 = new Entity();
        var man2 = new Entity();
        var man3 = new Entity();
        var woman1 = new Entity();
        var woman2 = new Entity();
        var woman3 = new Entity();

        man1.SetPreferenceList(new Entity[] { woman1, woman2, woman3 });
        man2.SetPreferenceList(new Entity[] { woman1, woman2, woman3 });
        man3.SetPreferenceList(new Entity[] { woman1, woman2, woman3 });
        woman1.SetPreferenceList(new Entity[] { man1, man2, man3 });
        woman2.SetPreferenceList(new Entity[] { man1, man2, man3 });
        woman3.SetPreferenceList(new Entity[] { man1, man2, man3 });

        var couples = sut.Match(new Entity[] { man1, man2, man3 });

        Assert.Equal(man1, couples.GetPartner(woman1));
        Assert.Equal(man2, couples.GetPartner(woman2));
        Assert.Equal(man3, couples.GetPartner(woman3));
    }
}
