using System;

abstract class Character
{
    private string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() =>
        false;

    public override string ToString() =>
        $"Character is a {characterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) =>
        target.Vulnerable()? 10 : 6;
}

class Wizard : Character
{
    private bool spell;
    public Wizard() : base("Wizard")
    {
        spell = false;
    }

    public override bool Vulnerable() =>
        !spell;

    public override int DamagePoints(Character target) =>
        spell? 12 : 3;

    public void PrepareSpell()
    {
        spell = true;
    }
}
