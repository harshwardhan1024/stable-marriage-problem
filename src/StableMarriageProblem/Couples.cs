namespace StableMarriageProblem;

public class Couples
{
    private readonly Dictionary<Guid, Entity> couples;

    public Couples()
    {
        couples = new Dictionary<Guid, Entity>();
    }

    public void Engage(Entity entity1, Entity entity2)
    {
        couples.Add(entity1.Id, entity2);
        couples.Add(entity2.Id, entity1);
    }

    public Entity GetPartner(Entity entity)
    {
        return couples[entity.Id];
    }

    public bool IsEngaged(Entity entity)
    {
        return couples.ContainsKey(entity.Id);
    }

    public void BreakEngagement(Entity entity)
    {
        var partner = GetPartner(entity);

        couples.Remove(entity.Id);
        couples.Remove(partner.Id);
    }
}

