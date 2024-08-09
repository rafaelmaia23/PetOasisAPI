namespace PetOasisAPI.Attributes;
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class ModelTypeAttribute : Attribute
{
    public Type ModelType { get; }

    public ModelTypeAttribute(Type modelType)
    {
        ModelType = modelType;
    }
}