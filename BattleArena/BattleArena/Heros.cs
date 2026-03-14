using SuperheroBattleArena;
using System;
using System.Collections.Generic;
using System.Text;


public class Archer : BaseHero
{
    public Archer(string name)
    {
        maxHealth = 200;
        Name = name;
        Power = 50;
        Health = maxHealth;
        Accuracy = 0.90;
        Recover = 50;
    }
    public override void Attack(BaseHero baseHero)
    {
        if (Extensions.CanAttack(Accuracy))
        {
            baseHero.TakeDamage(Power);
            BattleArena.message = $"{Name} attacked {baseHero.Name}";
        }
        else
        {
            BattleArena.message = $"{Name} missed";
        }
    }
}
public class Mage : BaseHero
{
    public Mage(string name)
    {
        maxHealth = 180;
        Name = name;
        Power =40;
        Accuracy = 0.80;
        Health = maxHealth;
        Recover = 70;
    }
    public override void Attack(BaseHero baseHero)
    {
        if (Extensions.CanAttack(Accuracy))
        {
            baseHero.TakeDamage(Power);
            BattleArena.message = $"{Name} attacked {baseHero.Name}";
        }
        else
        {
            BattleArena.message = $"{Name} missed";
        }
    }
}
public class Warrior : BaseHero
{
    public Warrior(string name)
    {
        maxHealth = 220;
        Name = name;
        Power = 60;
        Accuracy = 0.65;
        Health = maxHealth;
        Recover = 30;
    }
    public override void Attack(BaseHero baseHero)
    {
        if (Extensions.CanAttack(Accuracy))
        {
            baseHero.TakeDamage(Power);
            BattleArena.message = $"{Name} attacked {baseHero.Name}";
        }
        else
        {
            BattleArena.message = $"{Name} missed";
        }
    }
}


static class Extensions
{
    private static Random random = new Random();

    public static bool CanAttack(double accuracy)
    {

        return random.NextDouble() < accuracy;
    }
}