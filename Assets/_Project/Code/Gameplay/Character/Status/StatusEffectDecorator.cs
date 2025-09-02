public abstract class StatusEffectDecorator : StatusEffect
{
    protected StatusEffect _statusEffect;
    
    public StatusEffectDecorator(StatusEffect statusEffect, string id) : base(id)
    {
        _statusEffect = statusEffect;
    }
}