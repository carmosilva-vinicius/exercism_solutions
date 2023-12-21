using System;

public class Player
{
    private Random randon = new Random();
    public int RollDie() => randon.Next(1, 18);
    public double GenerateSpellStrength() => 
        randon.NextDouble() * 100;
}
