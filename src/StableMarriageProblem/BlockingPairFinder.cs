namespace StableMarriageProblem
{
    public class BlockingPairFinder
    {
        public bool Exists(Couples couples, IEnumerable<Entity> males)
        {
            foreach (var male in males)
            {
                foreach (var morePreferredFemale in male.MorePreferredList(couples.GetPartner(male)))
                {
                    if (morePreferredFemale.MorePreferred(male, couples.GetPartner(morePreferredFemale)) == male)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}