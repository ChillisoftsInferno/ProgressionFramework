namespace ProgressionFramework_Dante_Level0.HelperClasses.Node;

public static class NodeUtilities
{
    public static void AddItemToList<T>(List<T> list, T item)
    {
        list.Add(item);
    }

    public static T GetDefaultValue<T>(T input)
    {
        return input;
    }
}
