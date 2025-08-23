using System;
using Configs;

public abstract class StatusEffect
{
    public string Id { get; private set; }

    public StatusEffect(string id)
    {
        Id = id;
    }
    
    public abstract float GetStatValue(StatId statId);
    public abstract StatusEffect CloneWith(StatusEffect statusEffect);
}