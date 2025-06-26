namespace ProgressionFramework_Dante_Level0.Katas;

public class ReactionKata
{
    public ReactionResponseTypes React(ActionTimes actionTimes, int reactionTime)
    {
        if (reactionTime < actionTimes.GoodTiming.Millisecond) return ReactionResponseTypes.Failure;
        if (reactionTime > actionTimes.TotalTime.Millisecond) return ReactionResponseTypes.Failure;
        if (reactionTime >= actionTimes.GoodTiming.Millisecond && reactionTime < actionTimes.PerfectTiming.Millisecond) return ReactionResponseTypes.Good;
        if (reactionTime >= actionTimes.PerfectTiming.Millisecond && reactionTime < actionTimes.TotalTime.Millisecond) return ReactionResponseTypes.Perfect;
        return ReactionResponseTypes.BadResponse;
    }
}

public enum ReactionResponseTypes
{
    Failure,
    Good,
    Perfect,
    BadResponse
}

public class ActionTimes
{
    public readonly TimeOnly TotalTime;
    public readonly TimeOnly GoodTiming;
    public readonly TimeOnly PerfectTiming;

    public ActionTimes(TimeOnly totalTime, TimeOnly goodTiming, TimeOnly perfectTiming)
    {
        TotalTime = totalTime;
        GoodTiming = goodTiming;
        PerfectTiming = perfectTiming;
    }
}

public static class TimeOnlyExtensions
{
    public static TimeOnly InSeconds(int seconds)
    {
        return new TimeOnly(0, 0, seconds);
    } 
    
    public static TimeOnly InMilliSeconds(int milliseconds)
    {
        return new TimeOnly(0, 0, 0,milliseconds);
    }
}

[TestFixture]
internal class TestsReactionKata
{
    [Test]
    public void React_Failure_GivenEarlyInputTime()
    {
        //Arrange
        var sut = new ReactionKata();
        var actionTimes = CreateOneSecondActionTimes();
        //Act
        var result = sut.React(actionTimes, 50);
        //Assert
        Assert.That(result, Is.EqualTo(ReactionResponseTypes.Failure));
    }

    [Test]
    public void React_Failure_GivenLateInputTime()
    {
        //Arrange
        var sut = new ReactionKata();
        var actionTimes = CreateOneSecondActionTimes();
        //Act
        var result = sut.React(actionTimes, 110);
        //Assert
        Assert.That(result, Is.EqualTo(ReactionResponseTypes.Failure));
    }

    [Test]
    public void React_Good_GivenGoodInputTime()
    {
        //Arrange
        var sut = new ReactionKata();
        var actionTimes = CreateOneSecondActionTimes();
        //Act
        var result = sut.React(actionTimes, 70);
        //Assert
        Assert.That(result, Is.EqualTo(ReactionResponseTypes.Good));
    }
    
    [Test]
    public void React_Perfect_GivenPerfectInputTime()
    {
        //Arrange
        var sut = new ReactionKata();
        var actionTimes = CreateOneSecondActionTimes();
        //Act
        var result = sut.React(actionTimes, 90);
        //Assert
        Assert.That(result, Is.EqualTo(ReactionResponseTypes.Perfect));
    }

    private ActionTimes CreateOneSecondActionTimes()
    {
        return new ActionTimes(
            TimeOnlyExtensions.InMilliSeconds(100),
            TimeOnlyExtensions.InMilliSeconds(60),
            TimeOnlyExtensions.InMilliSeconds(80)
        );
    }
}
