using SuperheroBattleArena;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public abstract class BaseHero
{
    protected int maxHealth;
    public string Name { get; set; }
    protected int Power { get; set; }
    protected double Accuracy { get; set;  }
    protected int Health { get; set; }
    protected int Recover { get; set; }

    public abstract void Attack(BaseHero baseHero);

    public bool IsAlive()
    {
        if(Health > 0)
            return true;
        else 
            return false;
    }
    public void Heal()
    {
        Health += Recover;
        if (Health > maxHealth)
            Health = maxHealth;
        BattleArena.message = $"{Name} healed";
    }
    
    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health < 0)
            Health = 0;
    }
   
    public  override string ToString()
    {
        return $"{Name,-10}: {Power}P {Accuracy*100}A {maxHealth}H {Recover}R ";
    }
        
      public static void PrintStatus(BaseHero a, BaseHero b)
    {
        Console.WriteLine(a);
        Console.WriteLine($"{HealthBar(a)} {a.Health} HP");
        Console.WriteLine(b);
        Console.WriteLine($"{HealthBar(b)} {b.Health} HP");


    }
    private static string HealthBar(BaseHero a)
    {
        int filled =(int)( 20 * ((decimal)a.Health / a.maxHealth));
        return "[" + new string('█', filled) + new string('░', 20 - filled) + "]";
    }
}