using System.Text;

namespace ProgressionFramework_Dante_Level0.FunSideActivities.Hashing;

public class Hasher
{
    private const int StandardCodeLength = 4;
    private const int LowestNumberAsciiCode = 48;
    private const int HighestNumberAsciiCode = 57;
    private const int LowestLetterAsciiCode = 65;
    private const int HighestLetterAsciiCode = 90;
    private const int NumberProbability = 59;
    
    private readonly HashSet<string> _hashes = [];
    private readonly Random _randomizer = new();
    private readonly Encoding _ascii;
    private readonly bool _hasFinishedSetup;
    private readonly bool _isStandardized; //Will remove characters that aren't letters and numbers from an entry
    private readonly int _codeLength;
    private readonly int _maxHashes;
    
    private bool _isGenerating;
    private int _currentHashes;

    public Hasher(int maxHashes, bool isStandardized = false, int randomHashes = 0, int randomHashLength = StandardCodeLength)
    {
        _ascii = new UTF8Encoding();
        _currentHashes = 0;

        _maxHashes = maxHashes;
        _isStandardized = isStandardized;
        _codeLength = randomHashLength;
        
        CreateRandomHashedEntries(randomHashes);

        _hasFinishedSetup = true;
    }

    private string CodeRandomizer(int codeLength)
    {
        string code = "";
        int count = 0;
        while (count < codeLength)
        {
            if(ShouldDivide(count))
            {
                if (count == _codeLength)
                {
                    break;
                }
                code += "-";
            }

            code += _randomizer.Next(0, 101) <= NumberProbability ? GetRandomNumber() : GetRandomLetter();
            count++;
        }
        return code;
    }

    private bool ShouldDivide(int currentPos)
    {
        if (currentPos != 0 && currentPos % 4 == 0)
        {
            return true;
        }
        return false;
    }

    public string GetCodeByHash(string code)
    {
        string value = code.Replace('.', ' ');
        string decoded = _ascii.GetString(_ascii.GetBytes(value));
        
        foreach (string entry in _hashes)
        {
            string entryDecoded = _ascii.GetString(_ascii.GetBytes(entry)).Replace('.', ' ');
            if(decoded != entryDecoded) continue;
            byte[] decodedArr = decoded.ConvertToByteArray();
            
            if (decodedArr.ExistsInHashSet(_hashes, _ascii))
            {
                return _ascii.GetString(decodedArr);
            }
        }

        return $"This entry [{code}] does not exist with the HashSet.";
    }

    private string GetRandomNumber()
    {
        char number = (char)_randomizer.Next(LowestNumberAsciiCode, HighestNumberAsciiCode + 1);
        return number.ToString();
    }

    private string GetRandomLetter()
    {
        char letter = (char)_randomizer.Next(LowestLetterAsciiCode, HighestLetterAsciiCode + 1);
        return letter.ToString();
    }

    public bool GetIsGenerating() => _isGenerating;

    public void SetIsGenerating(bool value) => _isGenerating = value;
    
    public void ConvertToHashCode(string data)
    {
        byte[] tmpSource = _ascii.GetBytes(data);
        
        if (tmpSource.ExistsInHashSet(_hashes, _ascii))
        {
            Console.WriteLine("Hash Operation Failure: Already exists within the current HashSet, please retry...");
            return;
        }
        
        string entry = tmpSource.CreateNewEntry();
        if (_hasFinishedSetup)
        {
            _currentHashes++;
            entry = RemoveUnauthorizedCharacters(entry);
        }
        
        Console.WriteLine($"HashCode: [{entry}] - Data: [{data}]");
        _hashes.Add(entry);
        if(_currentHashes >= _maxHashes) SetIsGenerating(false);
    }

    private void CreateRandomHashedEntries(int randomHashes)
    {
        if(randomHashes == 0) return;

        int count = 0;
        while (count < randomHashes)
        {
            ConvertToHashCode(CodeRandomizer(_codeLength));
            count++;
        }
    }

    private string RemoveUnauthorizedCharacters(string data)
    {
        if (!_isStandardized) return data;
        
        List<byte> value = data.ConvertToByteArray().ToList();
        for (int i = 0; i < value.Count; i++)
        {
            if(IsNumber(value[i]) || IsLetter(value[i])) continue;
            value.Remove(value[i]);
        }
        return value.ToArray().CreateNewEntry();
    }

    private bool IsNumber(int value)
    {
        if(value is >= LowestNumberAsciiCode and <= HighestNumberAsciiCode) return true;
        return false;
    }
    
    private bool IsLetter(int value)
    {
        if(value is >= LowestLetterAsciiCode and <= HighestLetterAsciiCode) return true;
        return false;
    }
}
