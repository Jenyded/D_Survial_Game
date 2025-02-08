public abstract class StatusEffectDecorator : StatusEffect
{
    protected StatusEffect _statusEffect;
    
    public StatusEffectDecorator(StatusEffect statusEffect)
    {
        _statusEffect = statusEffect;
    }
}