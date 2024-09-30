// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

namespace ConwaysGameOfLife;

public class Neighbourhood
{
    private Map _lifeMap;
    public Neighbourhood(Map lifeMap)
    {
        _lifeMap = lifeMap;
    }
    
    public int CheckCellNeighbours(Cell cellToCheck)
    {
        var allCells = _lifeMap.GetAllCells();
        int amountOfNeighbours = 0;
        bool allNeighboursScanned = false;
        var cell = new Cell(cellToCheck.GetPosition());
        var cellQuery = allCells.Where(c => c != cellToCheck).ToList();
        while (amountOfNeighbours < 4 && !allNeighboursScanned)
        {
            if (TopNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (BottomNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (LeftNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (RightNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (TopLeftNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (TopRightNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (BottomLeftNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            if (BottomRightNeighbourExists(cell, cellQuery)) amountOfNeighbours += 1;
            allNeighboursScanned = true;
        }
        return amountOfNeighbours;
    }
    
    private bool TopNeighbourExists(Cell cell, List<Cell> cells)
    {
        var topPos = SetTempPos(cell);
        topPos[0] -= 1;
        topPos[0] = HandleHeightPositionRegulation(topPos[0]);
        if (cells.Any(c => c.GetPosition() == topPos)) return true;
        return false;
    }
    
    private bool BottomNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[0] += 1;
        pos[0] = HandleHeightPositionRegulation(pos[0]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }
    
    private bool LeftNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[1] -= 1;
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }
    
    private bool RightNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[1] += 1;
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }
    
    private bool TopLeftNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[0] += 1;
        pos[1] -= 1;
        pos[0] = HandleHeightPositionRegulation(pos[0]);
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }
    
    private bool TopRightNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[0] += 1;
        pos[1] += 1;
        pos[0] = HandleHeightPositionRegulation(pos[0]);
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }

    private bool BottomLeftNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[0] -= 1;
        pos[1] -= 1;
        pos[0] = HandleHeightPositionRegulation(pos[0]);
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }
    
    private bool BottomRightNeighbourExists(Cell cell, List<Cell> cells)
    {
        var pos = SetTempPos(cell);
        pos[0] -= 1;
        pos[1] += 1;
        pos[0] = HandleHeightPositionRegulation(pos[0]);
        pos[1] = HandleWidthPositionRegulation(pos[1]);
        if (PositionsAreEqual(cells, pos)) return true;
        return false;
    }

    private int HandleHeightPositionRegulation(int yPos)
    {
        var mapHeight = _lifeMap.GetMapSize()[0] - 1;
        if (yPos < 0) return mapHeight;
        if (yPos > mapHeight) return 0;
        return yPos;
    }
    
    private int HandleWidthPositionRegulation(int xPos)
    {
        var mapWidth = _lifeMap.GetMapSize()[1] - 1;
        if (xPos < 0) return mapWidth;
        if (xPos > mapWidth) return 0;
        return xPos;
    }

    private int[] SetTempPos(Cell cell)
    {
        return new int[] { cell.GetPosition()[0],cell.GetPosition()[1] };
    }

    private bool PositionsAreEqual(List<Cell> cells, int[] pos)
    {
        if (cells.Any(c => c.GetPosition()[0] == pos[0] && c.GetPosition()[1] == pos[1])) return true;
        return false;
    }
}
