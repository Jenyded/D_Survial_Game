using System.Collections.Generic;
using Configs;
using _Project.Scripts.Gameplay;
using Core.Character;

namespace _Project.Scripts.Gameplay.Character.Status
{
    public class CharacterStatus : BaseStatus
    {
        private string Id = "MainStatus";
        private CharacterConfig _config;

        public CharacterStatus(CharacterConfig config)
        {
            _config = config;
        }

        public override void AddStatusEffect<T>(StatusEffect effect)
        {
            if (StatusEffects[typeof(T)].Exists(x => x.Id == effect.Id))
                return;
            
            StatusEffects[typeof(T)].Add(effect);
            RefreshStatus();
        }

        public override void RemoveStatusEffect<T>(StatusEffect effect)
        {
            StatusEffects[typeof(T)].Remove(effect);
            RefreshStatus();
        }

        public override void RefreshStatus()
        {
            CurrentStatus = new CharacterDefaultStatus(_config, Id);

            //Add new layers which will modify default values
            foreach (var (type, effects) in StatusEffects)
            {
                effects.ForEach(x => CurrentStatus = x.CloneWith(CurrentStatus));
            }
        }

    }
}