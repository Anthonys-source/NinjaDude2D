using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Ability
{
    public CharacterAbilities abilitiesController;
    public float cooldownTime;
    public float castTime;
    public bool OnCooldown { get; protected set; } = false;

    public UnityAction<float> onCooldownStart;
    public UnityAction onCooldownEnd;
    public UnityAction<float> onCastTimeStart;
    public UnityAction onCastTimeEnd;

    public abstract IEnumerator Cast();

    protected void StartCooldown()
    {
        OnCooldown = true;
        onCooldownStart?.Invoke(cooldownTime);
        abilitiesController.StartCoroutine(CooldownTimer());
    }

    protected void StartCasting()
    {
        abilitiesController.currentlyCasting = true;
        onCastTimeStart?.Invoke(castTime);
    }

    protected void StopCasting()
    {
        abilitiesController.currentlyCasting = false;
        onCastTimeEnd?.Invoke();
    }

    protected IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(cooldownTime);
        OnCooldown = false;
        onCooldownEnd?.Invoke();
    }


}
