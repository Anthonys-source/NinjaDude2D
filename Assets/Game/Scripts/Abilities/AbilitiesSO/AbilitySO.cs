using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySO : ScriptableObject
{
    public float cooldown;
    public float castTime;

    public Ability GetAbility(CharacterAbilities controller)
    {
        Ability ability = GetConcreteAbility();
        ability.abilitiesController = controller;
        ability.cooldownTime = cooldown;
        ability.castTime = castTime;
        return ability;
    }

    protected abstract Ability GetConcreteAbility();
}

public class AbilitySO<T> : AbilitySO where T : Ability, new()
{
    protected override Ability GetConcreteAbility()
    {
        return new T();
    }
}