namespace StableMarriageProblem
{
    public class BlockingPairFinder
    {
        public bool Exists(Dictionary<Guid, Entity> couples, IEnumerable<Entity> males)
        {
            foreach (var male in males)
            {
                foreach (var morePreferredFemale in male.MorePreferredList(couples[male.Id]))
                {
                    if (morePreferredFemale.MorePreferredList(couples[morePreferredFemale.Id]).Contains(male))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}