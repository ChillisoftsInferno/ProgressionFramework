// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace GameOfLife;

public static class SimulationConfigurations
{
    public static List<Position> SetStartingPositions(Configurations configuration) => configuration switch
    {
        Configurations.Swirl => UseSwirl(),
        Configurations.SmallHeart => UseSmallHeart(),
        Configurations.LargeHeart => UseLargeHeart(),
        Configurations.Pulsar => UsePulsar(),
        Configurations.Pentadecathlon => UsePentadecathlon(),
        Configurations.GosperGliderGun => UseGosperGliderGun(),
        Configurations.Diehard => UseDieHard(),
        Configurations.Acorn => UseAcorn(),
        Configurations.FourWayPeriodFiveOscillator => Use4WayPeriodFiveOscillator(),
    };
    
    private static List<Position> UseSwirl()
    {
        return new List<Position>()
        {
            new (3,3), new (3,4), new (3,5), new (3,6), new (3,7), new (3,8),
            new (4,3), new (4,4), new (4,5), new (4,6), new (4,7), new (4,8),
            
            new (3,10), new (3,11), new (4,10), new (4,11), new (5,10), new (5,11),
            new (6,10), new (6,11), new (7,10), new (7,11), new (8,10), new (8,11),
            
            new (10,6), new (10,7), new (10,8), new (10,9), new (10,10), new (10,11),
            new (11,6), new (11,7), new (11,8), new (11,9), new (11,10), new (11,11),
            
            new (6,3), new (6,4), new (7,3), new (7,4), new (8,3), new (8,4),
            new (9,3), new (9,4),
            new (10,3), new (10,4),
            new (11,3), new (11,4),
        };
    }
    private static List<Position> UseSmallHeart()
    {
        return new List<Position>()
        {
            new (6,6),
            new (7,6),
            new (7,7),
            new (7,8),
            new (8,7),
            new (6,8),
        };
    }
    private static List<Position> UseLargeHeart()
    {
        return new List<Position>()
        {
            new (10,14), new (10,15), new (10,16), new (10,17), new (10,18), new (10,19),
            new (11,12), new (11,13), new (11,14), new (11,15), new (11,16), new (11,17), new (11,18), new (11,19), new (11,20), new (11,21),
            new (12,10), new (12,11), new (12,12), new (12,13), new (12,14), new (12,15), new (12,16), new (12,17), new (12,18), new (12,19), new (12,20), new (12,21), new (12,22), new (12,23),
            new (13,10), new (13,11), new (13,12), new (13,13), new (13,14), new (13,15), new (13,16), new (13,17), new (13,18), new (13,19), new (13,20), new (13,21), new (13,22), new (13,23),
            new (14,12), new (14,13), new (14,14), new (14,15), new (14,16), new (14,17), new (14,18), new (14,19), new (14,20), new (14,21),
            new (15,14), new (15,15), new (15,16), new (15,17), new (15,18), new (15,19),
            new (16,16), new (16,17), new (16,18),
        };
    }
    private static List<Position> UsePulsar()
    {
        return new List<Position>()
        {
            new (5,7), new (5,8), new (5,9), new (5,13), new (5,14), new (5,15),
            new (7,5), new (8,5), new (9,5), new (13,5), new (14,5), new (15,5),
            new (7,10), new (8,10), new (9,10), new (13,10), new (14,10), new (15,10),
            new (10,7), new (10,8), new (10,9), new (10,13), new (10,14), new (10,15),
            new (7,16), new (8,16), new (9,16), new (13,16), new (14,16), new (15,16),
            new (16,7), new (16,8), new (16,9), new (16,13), new (16,14), new (16,15),
        };
    }
    private static List<Position> UsePentadecathlon()
    {
        return new List<Position>()
        {
            new (10,12), new (11,12), new (12,11), new (12,13),
            new (13,12), new (14,12), new (15,12), new (16,12),
            new (17,11), new (17,13), new (18,12), new (19,12),
        };
    }
    private static List<Position> UseGosperGliderGun()
    {
        return new List<Position>()
        {
            new (5,1), new (5,2), new (6,1), new (6,2),
            new (5,11), new (6,11), new (7,11), new (4,12), new (8,12),
            new (3,13), new (9,13), new (3,14), new (9,14),
            new (6,15),
            new (4,16), new (8,16),
            new (5,17), new (6,17), new (7,17),
            new (6,18),
            new (3,21), new (4,21), new (5,21),
            new (3,22), new (4,22), new (5,22),
            new (2,23), new (6,23),
            new (1,25), new (2,25), new (6,25), new (7,25),
            new (3,35), new (4,35), new (3,36), new (4,36),
        };
    }
    private static List<Position> UseDieHard()
    {
        return new List<Position>()
        {
            new (10,16), 
            new (11,10), new (11,11), 
            new (12,11), 
            new (12,15), new (12,16), new (12,17),
        };
    }
    private static List<Position> UseAcorn()
    {
        return new List<Position>()
        {
            new (10,12),
            new (11,14),
            new (12,11), new (12,12),
            new (12,15), new (12,16), new (12,17),
        };
    }
    private static List<Position> Use4WayPeriodFiveOscillator()
    {
        return new List<Position>()
        {
            new (3, 7), new (3, 11),
            new (4, 5), new (4, 8), new (4, 10), new (4, 13),
            new (5, 5), new (5, 8), new (5, 10), new (5, 13),
            new (6, 3), new (6, 4), new (6, 6), new (6, 8), new (6, 10),new (6, 12),new (6, 14),new (6, 15),
            new (7, 5), new (7, 8), new (7, 10), new (7, 13),
            new (8, 2), new (8, 8), new (8, 10), new (8, 16),
            new (9, 3), new (9, 4), new (9, 5), new (9, 6), new (9, 7), new (9, 11), new (9, 12), new (9, 13), new (9, 14), new (9, 15),
            
            new (11, 3), new (11, 4), new (11, 5), new (11, 6), new (11, 7), new (11, 11), new (11, 12), new (11, 13), new (11, 14), new (11, 15),
            new (12, 2), new (12, 8), new (12, 10), new (12, 16),
            new (13, 5), new (13, 8), new (13, 10), new (13, 13),
            new (14, 3), new (14, 4), new (14, 6), new (14, 8), new (14, 10),new (14, 12),new (14, 14),new (14, 15),
            new (15, 5), new (15, 8), new (15, 10), new (15, 13),
            new (16, 5), new (16, 8), new (16, 10), new (16, 13),
            new (17, 7), new (17, 11),
        };
    }

    
    public static List<Position> SetRandomStartingPositions(int amountOfPositions, int mapWith, int mapHeight)
    {
        var positions = new List<Position>();

        for (int i = 0; i < amountOfPositions; i++)
        {
            var xPos = new Random().Next(0, mapWith);
            var yPos = new Random().Next(0, mapHeight);
            positions.Add(new Position(xPos, yPos));
        }

        return positions;
    }
}

public enum Configurations
{
    Swirl,
    SmallHeart,
    LargeHeart,
    Pulsar,
    Pentadecathlon,
    GosperGliderGun,
    Diehard,
    Acorn,
    FourWayPeriodFiveOscillator,
}
