namespace DialogueSystem.UI.Components;

public class ProgressBar
{
    private readonly int _currentValue;
    private readonly int _maxValue;
    private readonly int _incrementLength;
    
    public ProgressBar(int currentValue, int maxValue, int incrementLength = 5)
    {
        _currentValue = currentValue;
        _maxValue = maxValue;
        _incrementLength = incrementLength;
        Validate();
    }

    private void Validate()
    {
        if (_currentValue < 0) throw new ArgumentOutOfRangeException(nameof(_currentValue), "Current value cannot be a negative.");
        if (_maxValue < _currentValue) throw new ArgumentOutOfRangeException(nameof(_maxValue), "Max value cannot be less than the current value.");
    }

    public string Build()
    {
        string progressBarIndicator = "[";
        int increments = _currentValue / _incrementLength;
        int index = 0;
        while (index < _maxValue)
        {
            for (int i = 0; i < increments; i++)
            {
                progressBarIndicator += "_";
                index += _incrementLength;
            }

            for (int i = index; i < _maxValue; i++)
            {
                progressBarIndicator += " ";
                index += _incrementLength;
            }
        }
        
        return progressBarIndicator;
    }
}
