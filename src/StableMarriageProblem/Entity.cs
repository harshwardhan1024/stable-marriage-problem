namespace StableMarriageProblem;

public class Entity
{
	private int currentPreferredIndex = 0;

	public Entity() : this(Guid.NewGuid())
	{
	}

	public Entity(Guid id)
	{
		Id = id;
		PreferenceList = new List<Entity>();
	}

    public Guid Id { get; init; }

    public IReadOnlyList<Entity> PreferenceList { get; private set; }

	public void SetPreferenceList(IEnumerable<Entity> entities)
	{
		foreach (var entity in entities)
		{
			if (entity == this)
			{
				throw new ArgumentException("Entity cannot add itself to its preference list.");
			}
		}

		this.PreferenceList = entities.ToList();
	}

	public Entity? NextPreferred()
	{
		if (PreferenceList.Count == 0 || currentPreferredIndex >= PreferenceList.Count)
		{
			return null;
		}

		return PreferenceList[currentPreferredIndex++];
	}

	public IReadOnlyList<Entity> MorePreferredList(Entity entity)
	{
		var morePreferred = new List<Entity>();
		foreach (var e in PreferenceList)
		{
			if (e == entity)
			{
				break;
			}

			morePreferred.Add(e);
		}

		if (morePreferred.Count == PreferenceList.Count)
		{
			throw new ArgumentException("Given entity is not present in the preference list.");
		}

		return morePreferred;
	}

	public Entity MorePreferred(Entity a, Entity b)
	{
		foreach (var entity in PreferenceList)
		{
			if (entity == a)
			{
				return a;
			}
			else if (entity == b)
			{
				return b;
			}
		}

		throw new ArgumentException("Neither Entity a nor b exists in the PreferenceList.");
	}

	public override bool Equals(object? obj) => obj is Entity entity && entity.Id == this.Id;

	public static bool operator ==(Entity e1, Entity e2)
	{
		return e1.Equals(e2);
	}

	public static bool operator !=(Entity e1, Entity e2)
	{
		return !(e1 == e2);
	}

	public override int GetHashCode()
	{
		return Id.GetHashCode();
	}
}
