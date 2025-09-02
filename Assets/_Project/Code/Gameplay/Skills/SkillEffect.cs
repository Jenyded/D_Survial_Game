using System;
using System.Collections.Generic;
using _Project.Scripts.Gameplay.Character;
using _Project.Scripts.Gameplay.Character.Status;
using Configs;
using Core.Character;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Skills
{
    [Serializable]
    public abstract class SkillEffect
    {
        public abstract void Use(GameObject caster, GameObject target);
    }

    [Serializable]
    public class HealEffect : SkillEffect
    {
        public bool OnSelf;
        public float Heal;
        
        public override void Use(GameObject caster, GameObject target)
        {
            GameObject targetObject = OnSelf ? caster : target;
            targetObject.GetComponent<IHealth>().TakeHeal(Heal);
        }
    }

    [Serializable]
    public class DashEffect : SkillEffect
    {
        public float Distance;
        
        public override void Use(GameObject caster, GameObject target)
        {
            Vector2 direction= (caster.transform.position - target.transform.position).normalized;
            caster.GetComponent<CharacterMovement>().PushTo(direction, Distance);
        }
    }

    [Serializable]
    public class DamageEffect : SkillEffect
    {
        public int Damage;
        
        public override void Use(GameObject caster, GameObject target)
        {
            target.GetComponent<IHealth>().TakeDamage(Damage);
        }
    }

    [Serializable]
    public class AoeEffect : SkillEffect
    {
        public float Radius;
        public LayerMask Layer;
        protected List<Collider2D> DetectedObjects;
            
        public override void Use(GameObject caster, GameObject target)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(caster.transform.position, Radius);
            foreach (var hit in hits)
            {
                if (hit.gameObject.layer != Layer)
                    continue;
                
                DetectedObjects.Add(hit);
            }
        }
    }

    [Serializable]
    public class AoeDamageEffect : AoeEffect
    {
        public float Damage;
        
        public override void Use(GameObject caster, GameObject target)
        {
            base.Use(caster, target);
            DetectedObjects.ForEach(x => x.GetComponent<IHealth>().TakeDamage(Damage));
        }
    }

    [Serializable]
    public class AoeBuffEffect : AoeEffect
    {
        public BuffEffect Buff;
        
        public override void Use(GameObject caster, GameObject target)
        {
            base.Use(caster, target);
            
            DetectedObjects.ForEach(x =>
            {
                Buff.Use(caster, x.gameObject);
            });
        }
    }

    [Serializable]
    public class BuffEffect : SkillEffect
    {
        public string Id;
        public bool OnSelf;
        public SerializableDictionary<StatId, BuffModifier> Modifiers;
        
        public override void Use(GameObject caster, GameObject target)
        {
            GameObject buffObject = OnSelf ? caster : target;
            
            BaseStatus status = buffObject.GetComponent<StatusHolder>().StatusInstance;
            status.AddStatusEffect<BuffStatusEffect>(new BuffStatusEffect(status.CurrentStatus, Modifiers, Id));
        }
    }
}