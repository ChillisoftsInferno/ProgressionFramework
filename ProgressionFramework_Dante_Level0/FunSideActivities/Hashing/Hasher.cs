using System;
using System.Text;
using System.Security.Cryptography;

namespace ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

public class Hasher
{
    private string sSourceData;
    private byte[] tmpSource;
    private byte[] tmpHash;
    private bool isGenerating;
    private int _maxHashes;
    private int _currentHashes;
    private HashSet<string> hashes = new HashSet<string>();
    private Random randomizer = new Random();

    public Hasher(int maxHashes)
    {
        _maxHashes = maxHashes;
        _currentHashes = 0;
        int count = 0;
        while (count < 999)
        {
            ConvertToHashCode(CodeRandomizer(4));
            count++;
        }
    }

    public string CodeRandomizer(int codeLength)
    {
        string code = "";
        int count = 0;
        while (count < codeLength)
        {
            switch (randomizer.Next(0, 1))
            {
                case 0:
                    code += GetRandomNumber();
                    break;
                case 1:
                    code += GetRandomLetter();
                    break;
            }
            count++;
        }
        return code;
    }
    
    public string GetCodeByHash

    private string GetRandomNumber()
    {
        char number = (char)randomizer.Next(48, 57);
        return number.ToString();
    }

    private string GetRandomLetter()
    {
        char letter = (char)randomizer.Next(65, 90);
        return letter.ToString();
    }

    public string GetRandomCode()
    {
        string code = "AS87U-IL59P";
        return code;
    }

    public bool GetIsGenerating() => isGenerating;

    public void SetIsGenerate(bool value)
    {
        isGenerating = value;
    }
    
    public void ConvertToHashCode(string data)
    {
        tmpSource = Encoding.ASCII.GetBytes(data);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        string hashCode = ByteArrayToString(tmpHash);
        if (hashCode.ExistsInSet(hashes))
        {
            Console.WriteLine("Hash Operation Failure: Already exists within the current HashSet, please retry...");
            return;
        } 
        _currentHashes++;
        Console.WriteLine($"HashCode: [{hashCode}] - Data: [{data}]");
        hashes.Add(hashCode);
        if(_currentHashes >= _maxHashes) SetIsGenerate(false);
    }

    public string ByteArrayToString(byte[] arrInput)
    {
        int i;
        StringBuilder sOutput = new StringBuilder(arrInput.Length);
        for (i = 0; i < arrInput.Length; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }
    
    
}
