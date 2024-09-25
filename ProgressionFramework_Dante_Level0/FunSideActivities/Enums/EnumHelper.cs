namespace ProgressionFramework_Dante_Level0.FunSideActivities.Enums;

public enum Status
{
    None,
    Archived,
    Open,
    Closed,
    Deleted,
}

public static class EnumHelper
{
    public static string Value(this Status value)
    {
        return $"Status: {value}";
    }

    public static Status RandomizeStatus()
    {
        var random = new Random();
        switch (random.Next(0, 5))
        {
            case 1: return Status.Archived;
            case 2: return Status.Open;
            case 3: return Status.Closed;
            case 4: return Status.Deleted;
            default: return Status.None;
        }
    }
}
