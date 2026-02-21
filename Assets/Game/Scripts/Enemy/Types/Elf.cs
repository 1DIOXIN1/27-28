using System;

public class Elf : Enemy
{
    public override void Initialization(EnemyConfig config)
    {
        if(config is ElfConfig result)
            Mana = result.Mana;
        else
            throw new ArgumentException("Не правильный конфиг");
    }

    public int Mana { get; private set; }
}
