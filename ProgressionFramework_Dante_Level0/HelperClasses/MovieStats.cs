// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ProgressionFramework_Dante_Level0.HelperClasses;

public class MovieStats
{
    private string _movieName = "";
    private string _phrase = "Sharkbait huhaha";
    private int _timesPhraseWasRepeated = 5;
    private double _tankChlorineLevels = 7.8;
    private bool _wasBoxOfficeFailure = false;

    public MovieStats(string movieName = "")
    {
        _movieName = movieName;
    }
        
    public override string ToString()
    {
        if (string.IsNullOrEmpty(_movieName)) return "No movie name entered. Please try again.";
            
        if(_movieName != "Finding Nemo") return $"Movie: {_movieName} not found in database, in other words... It failed.";
            
        return $"Movie: {_movieName}, Renowned Phrase: {_phrase} - Times Repeated: {_timesPhraseWasRepeated}, " +
               $"BoxOffice Failed: {_wasBoxOfficeFailure}, Chlorine Levels in Tank: {_tankChlorineLevels}";
    }
}
