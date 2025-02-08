public class StatusEffectDecoratorFactory
{
    public StatusEffect CreateStatusEffectDecorator<T>(StatusEffect statusEffect) where T: StatusEffectDecorator, new()
    {
        return new T();
    }
}