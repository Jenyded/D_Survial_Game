using System.Collections.Generic;
using System;
using Core.Character;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Character.Status
{
    public abstract class BaseStatus
    {
        public StatusEffect CurrentStatus { get; protected set; }
        protected Dictionary<Type, List<StatusEffect>> StatusEffects { get; } = new()
        {
            [typeof(EquipmentEffect)] = new(),
            [typeof(BuffStatusEffect)] = new List<StatusEffect>()
        };

        public abstract void AddStatusEffect<T>(StatusEffect effect) where T : StatusEffect;
        public abstract void RemoveStatusEffect<T>(StatusEffect effect) where T : StatusEffect;
        public abstract void RefreshStatus();
    }
}