using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Coord Coord1 { get; }
    public Coord Coord2 { get; }
    public Coord Coord3 { get; }
    public Coord Coord4 { get; }

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Coord1 = coord1;
        Coord2 = coord2;
        Coord3 = coord3;
        Coord4 = coord4;
    }
}

public class ClaimsHandler
{
    private List<Plot> Claims { get; } = new();
    public void StakeClaim(Plot plot) => Claims.Add(plot);
    public bool IsClaimStaked(Plot plot) => Claims.Contains(plot);
    public bool IsLastClaim(Plot plot) => Claims.Last().Equals(plot);

    public Plot GetClaimWithLongestSide()
    {
        var longestSide = 0;
        var plotWithLongestSide = new Plot();
        foreach (var plot in Claims)
        {
            var side1 = Math.Sqrt(Math.Pow(plot.Coord1.X - plot.Coord2.X, 2) +
                                  Math.Pow(plot.Coord1.Y - plot.Coord2.Y, 2));
            var side2 = Math.Sqrt(Math.Pow(plot.Coord2.X - plot.Coord3.X, 2) +
                                  Math.Pow(plot.Coord2.Y - plot.Coord3.Y, 2));
            var side3 = Math.Sqrt(Math.Pow(plot.Coord3.X - plot.Coord4.X, 2) +
                                  Math.Pow(plot.Coord3.Y - plot.Coord4.Y, 2));
            var side4 = Math.Sqrt(Math.Pow(plot.Coord4.X - plot.Coord1.X, 2) +
                                  Math.Pow(plot.Coord4.Y - plot.Coord1.Y, 2));
            var longestSideInPlot = Math.Max(Math.Max(side1, side2), Math.Max(side3, side4));
            if (!(longestSideInPlot > longestSide)) continue;
            longestSide = (int)longestSideInPlot;
            plotWithLongestSide = plot;
        }
        return plotWithLongestSide;
    }
}
