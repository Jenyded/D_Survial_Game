using System.Collections.Generic;
using System;
using UnityEngine;

namespace _Project.Scripts.Gameplay
{
    public abstract class Status
    {
        public StatusEffect CurrentStatus { get; protected set; }
        protected Dictionary<Type, List<StatusEffect>> StatusEffects { get; } = new();

        public abstract void AddStatusEffect<T>(StatusEffect effect) where T : StatusEffect;
        public abstract void RemoveStatusEffect<T>(StatusEffect effect) where T : StatusEffect;
        public abstract void RefreshStatus();
    }
}