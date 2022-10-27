namespace StableMarriageProblem.UnitTests
{
    public class Entity_Initialization
    {
        [Fact]
        public void Is_initialized_with_unique_identifier()
        {
            var entity = new Entity();
            Assert.NotEqual(default(Guid), entity.Id);
        }
    }

    public class Entity_Equality
    {
        [Fact]
        public void Entities_with_same_Id_should_be_equal()
        {
            var e1 = new Entity();
            var e2 = new Entity(e1.Id);
            Assert.True(e1 == e2);
        }

        [Fact]
        public void Entities_with_different_Id_should_not_be_equal()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            Assert.True(e1 != e2);
        }
    }

    public class Entity_HashCode
    {
        [Fact]
        public void Entities_should_have_different_HashCode()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            Assert.True(e1.GetHashCode() != e2.GetHashCode());
        }
    }

    public class Entity_PreferenceList
    {
        [Fact]
        public void Can_set_preference_list()
        {
            var e1 = new Entity();
            var e2 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2 });

            Assert.Equal(1, e1.PreferenceList.Count);
        }

        [Fact]
        public void Setting_preference_list_should_replace_the_existing_list_if_any()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2 });
            e1.SetPreferenceList(new Entity[] { e3 });

            Assert.Contains(e3, e1.PreferenceList);
        }

        [Fact]
        public void Cannot_add_itself_in_the_preference_list()
        {
            var e1 = new Entity();

            Assert.Throws<ArgumentException>(() => e1.SetPreferenceList(new Entity[] { e1 }));
        }
    }

    public class Entity_NextPreferred
    {
        [Fact]
        public void Returns_the_next_element_from_the_preference_list_at_each_call()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2, e3 });

            Assert.Equal(e2, e1.NextPreferred());
            Assert.Equal(e3, e1.NextPreferred());
        }

        [Fact]
        public void Returns_null_when_preference_list_empty()
        {
            var e1 = new Entity();
            Assert.Null(e1.NextPreferred());
        }

        [Fact]
        public void Returns_null_when_all_preferred_entities_are_seen()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2, e3 });
            e1.NextPreferred();
            e1.NextPreferred();

            Assert.Null(e1.NextPreferred());
        }
    }

    public class Entity_MorePreferredList
    {
        [Fact]
        public void Returns_list_of_more_preferred_entities_than_the_given_one()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2, e3 });

            var morePreferredList = e1.MorePreferredList(e3);

            Assert.Single(morePreferredList);
            Assert.Equal(e2, morePreferredList.First());
        }

        [Fact]
        public void Throws_exception_when_provided_entry_is_not_in_the_list()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();
            var e4 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2, e3 });

            Assert.Throws<ArgumentException>(() => e1.MorePreferredList(e4));
        }
    }

    public class Entity_MorePreferred
    {
        [Fact]
        public void Return_entity_which_is_more_preferred_among_both()
        {
            var e1 = new Entity();
            var e2 = new Entity();
            var e3 = new Entity();

            e1.SetPreferenceList(new Entity[] { e2, e3 });

            Assert.Equal(e2, e1.MorePreferred(e2, e3));
        }
    }
}