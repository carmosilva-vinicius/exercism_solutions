class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40; 

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int t) => 40 - t; 

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int l) => 2 * l;

    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int l, int t) => 2 * l + t;
}
