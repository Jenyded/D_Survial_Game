using System;
using System.Collections.Generic;
using System.Linq;
//using Sirenix.OdinInspector;
using UnityEngine;

namespace Configs
{
    [Serializable]
    public class BuffConfig
    {
        public Dictionary<StatId, BuffModifier> Modifiers;
    }

    [Serializable]
    public class BuffModifier
    {
        public ModifierType Type;
        public float Value;

        public float MergeWith(float baseValue)
        {
            return Type == ModifierType.Add ? baseValue + Value : baseValue * Value;
        }
    }

    public enum ModifierType
    {
        Add = 0,
        Multiply = 1
    }
}