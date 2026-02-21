using System;

public class Ork : Enemy
{
    public override void Initialization(EnemyConfig config)
    {
        if(config is OrkConfig result)
            Damage = result.Damage;
        else
            throw new ArgumentException("Не правильный конфиг");
    }

    public int Damage { get; private set; }
}
