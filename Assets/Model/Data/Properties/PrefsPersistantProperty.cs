namespace Assets.Model.Data.Properties
{
    public abstract class PrefsPersistantProperty<TPropertyType> : PersistantProperty<TPropertyType>
    {
        protected string _key;
        protected PrefsPersistantProperty(TPropertyType defaultValue, string key)
            : base(defaultValue)
        {
            _key = key;
        }
    }
}
