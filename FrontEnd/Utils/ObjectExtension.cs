public static class ObjectExtensions
{
    public static void CopyPropertiesTo<T, U>(this T source, U destination)
    {
        var sourceProperties = typeof(T).GetProperties();
        var destinationProperties = typeof(U).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name && p.PropertyType == sourceProperty.PropertyType);
            if (destinationProperty != null)
            {
                destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
            }
        }
    }
}
