using System.Text.RegularExpressions;

namespace ProgressionFramework_Dante_Level0.Katas;

public class BinaryMultipleOf3Kata
{
    public static Regex MultipleOf3()
    {
        var regex = "";
        // Regular expression that matches binary inputs that are multiple of 3
        if(!IsValidBinary(regex)) return new Regex("");
        return new Regex(regex);
    }

    public static bool IsValidBinary(string binaryString)
    {
        if(binaryString.Length < 4) return false;
        if(binaryString.Any(x => x != '0' && x != '1')) return false;
        return true;
    }

    public static int GetValueFromBinary(string binaryValue)
    {
        return 0;
    }
}
