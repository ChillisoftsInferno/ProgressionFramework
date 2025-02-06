namespace ProgressionFramework_Dante_Level0.Katas;
using System.Collections.Generic;

public class DidYouMeanKata
{
    private IEnumerable<string> words;

    private Dictionary<string, int> valuesBasedOnSimilarity;

    public DidYouMeanKata(IEnumerable<string> words)
    {
        this.words = words;
        valuesBasedOnSimilarity = this.words.ToDictionary(w => w, w => 0);
    }

    public string FindMostSimilar(string term)
    {
        GetSimilarityBasedOnTermLength(term);
        GetSimilarityBasedOnCharacterPositioning(term);
        GetSimilarityBasedOnCharacterAccuracy(term);
        GetSimilarityBasedOnIntersectionCount(term);
        
        return GetHighestValueFromSimilarities();
    }

    private void GetSimilarityBasedOnTermLength(string term)
    {
        IEnumerable<string> sameLengthWords = words.Where(w => w.Length == term.Length);

        foreach (string word in sameLengthWords)
        {
            valuesBasedOnSimilarity[word] = 3;
        }
        
        IEnumerable<string> differentLengthWords = words.Where(w => w.Length != term.Length);
        
        var edgeLengthWords = FindTwoLargestDifferentiatingLengthWords(differentLengthWords, term);
        
        IEnumerable<string> highestDifferenceInLengthValueWords = new []{ edgeLengthWords.word1, edgeLengthWords.word2 };
        
        foreach (string word in highestDifferenceInLengthValueWords)
        {
            valuesBasedOnSimilarity[word] = 1;
        }
        
        differentLengthWords = differentLengthWords.Where(w => w != edgeLengthWords.word1 && w != edgeLengthWords.word2);
        
        foreach (string word in differentLengthWords)
        {
            valuesBasedOnSimilarity[word] = 2;
        }
    }
    
    private (string word1, string word2) FindTwoLargestDifferentiatingLengthWords(IEnumerable<string> words, string referenceWord)
    {
        if (words == null || !words.Any())
            throw new ArgumentException("The collection of words must not be empty.");

        if (referenceWord == null)
            throw new ArgumentNullException(nameof(referenceWord));

        var differences = words
            .Select(word => new { Word = word, Difference = Math.Abs(word.Length - referenceWord.Length) })
            .OrderByDescending(x => x.Difference)
            .ToList();

        if (differences.Count < 2)
            throw new InvalidOperationException("The collection must contain at least two words.");

        return (differences[0].Word, differences[1].Word);
    }

    private void GetSimilarityBasedOnCharacterAccuracy(string term)
    {
        var copyOfDictionary = valuesBasedOnSimilarity;
        foreach (var word in copyOfDictionary.Keys)
        {
            var wordToCompare = word;
            for (int i = 0; i < term.Length; i++)
            {
                var target = term[i];

                if(i >= word.Length) break;
                if (!wordToCompare.Contains(term[i])) continue;

                wordToCompare = RemoveFirstCharacterIfMatch(wordToCompare, target);
                copyOfDictionary[word]++;
            }
            valuesBasedOnSimilarity[word] += copyOfDictionary[word];
        }
    }
    
    private string RemoveFirstCharacterIfMatch(string input, char target)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == target)
            {
                input = input.Remove(i, 1);
            }
        }

        return input;
    }

    private void GetSimilarityBasedOnCharacterPositioning(string term)
    {
        var copyOfDictionary = valuesBasedOnSimilarity;
        foreach (var word in copyOfDictionary.Keys)
        {
            for (int i = 0; i < term.Length; i++)
            {
                if(i >= word.Length) break;
                if (term[i] == word[i]) copyOfDictionary[word]++;
            }
            valuesBasedOnSimilarity[word] += copyOfDictionary[word];
        }
    }

    private void GetSimilarityBasedOnIntersectionCount(string term)
    {
        var copyOfDictionary = valuesBasedOnSimilarity;
        foreach (var word in copyOfDictionary.Keys)
        {
            var intersections = word.Intersect(term);
            var intersectionString = string.Concat(intersections);
            var intersectionCount = word.Intersect(term).Count();
            
            //Doubles the value if the intersection exists exactly as is within the string
            if (!string.IsNullOrEmpty(intersectionString) 
                && intersectionString.Length >= 2
                && word.Contains(intersectionString)) valuesBasedOnSimilarity[word] += 9;
            
            valuesBasedOnSimilarity[word] += intersectionCount;
        }
    }

    private string GetHighestValueFromSimilarities()
    {
        IEnumerable<KeyValuePair<string, int>> keyValuePairs = 
            valuesBasedOnSimilarity
            .ToList()
            .OrderByDescending(x => x.Value);
        
        return keyValuePairs
            .First()
            .Key;
    }
}
