using System;

public class Dragon : Enemy
{
    public override void Initialization(EnemyConfig config)
    {
        if(config is DragonConfig result)
            Agility = result.Agility;
        else
            throw new ArgumentException("Не правильный конфиг");
    }

    public int Agility { get; private set; }
}
