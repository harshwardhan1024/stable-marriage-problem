namespace StableMarriageProblem;

public class GaleShapleyAlgorithm
{
    public Couples Match(IEnumerable<Entity> males)
    {
        var couples = new Couples();
        while (true)
        {
            foreach (var male in males)
            {
                if (couples.IsEngaged(male))
                {
                    continue;
                }

                var preferredFemale = male.NextPreferred();

                if (couples.IsEngaged(preferredFemale))
                {
                    if (preferredFemale.MorePreferred(male, couples.GetPartner(preferredFemale)) == male)
                    {
                        couples.BreakEngagement(preferredFemale);
                        couples.Engage(male, preferredFemale);
                    }
                }
                else
                {
                    couples.Engage(male, preferredFemale);
                }
            }

            if (males.All(m => couples.IsEngaged(m)))
            {
                break;
            }
        }

        return couples;
    }
}
