using System;
using _Project.Scripts.Configs;
using _Project.Scripts.Gameplay;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using Core.Character;

namespace _Project.Scripts.Infrastructure.Factories
{
    public class StatusEffectFactory
    {
        public void CreateBuffEffectFor(BaseStatus status, BuffConfig config)
        {
           // status.AddStatusEffect<StatusEffect>(new BuffStatusEffect(status.CurrentStatus, config));
           // status.RefreshStatus();
        }
    }
}