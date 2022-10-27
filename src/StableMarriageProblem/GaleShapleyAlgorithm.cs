namespace StableMarriageProblem;

public class GaleShapleyAlgorithm
{
    public Dictionary<Guid, Entity> Match(IEnumerable<Entity> males, IEnumerable<Entity> females)
    {
        var couples = new Dictionary<Guid, Entity>(males.Count() * 2);
        while (true)
        {
            foreach (var male in males)
            {
                if (couples.ContainsKey(male.Id))
                {
                    continue;
                }

                var preferredFemale = male.NextPreferred();

                if (couples.ContainsKey(preferredFemale.Id))
                {
                    var femaleEngagedTo = couples[preferredFemale.Id];
                    if (preferredFemale.MorePreferred(male, femaleEngagedTo) == male)
                    {
                        couples.Remove(preferredFemale.Id);
                        couples.Remove(femaleEngagedTo.Id);

                        couples.Add(preferredFemale.Id, male);
                        couples.Add(male.Id, preferredFemale);
                    }
                }
                else
                {
                    couples.Add(male.Id, preferredFemale);
                    couples.Add(preferredFemale.Id, male);
                }
            }

            if (males.All(m => couples.ContainsKey(m.Id)))
            {
                break;
            }
        }

        return couples;
    }
}
