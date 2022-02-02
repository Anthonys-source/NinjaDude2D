using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Abilities/Dash")]
public class AbilityDashSO : AbilitySO<AbilityDash>
{
    public GameObject areaDamagePrefab;
    public float dashVelocity = 10;
    public float dashTime = 0.1f;
    public float damageAreaSize = 1.0f;

    protected override Ability GetConcreteAbility()
    {
        AbilityDash ability = new AbilityDash();
        ability.dashVelocity = dashVelocity;
        ability.dashDuration = dashTime;
        ability.damageAreaSize = damageAreaSize;
        ability.areaDamagePrefab = areaDamagePrefab;
        return ability;
    }
}

public class AbilityDash : Ability
{
    public GameObject areaDamagePrefab;
    public float dashVelocity = 10;
    public float dashDuration = 0.1f;
    public float damageAreaSize = 1.0f;

    public override IEnumerator Cast()
    {
        abilitiesController.characterMovement.movementEnabled = false;
        StartCasting();

        #region Ability Behavior

        float elapsedTime = 0.0f;
        Vector2 direction = (abilitiesController.input.Look - (Vector2)abilitiesController.transform.position).normalized;

        GameObject areaDamager = Object.Instantiate(areaDamagePrefab, abilitiesController.transform);

        while (elapsedTime < dashDuration)
        {
            abilitiesController.rigidBody.velocity = direction * dashVelocity;
            yield return new WaitForSeconds(0.05f);
            elapsedTime += 0.05f;
        }

        Object.Destroy(areaDamager);
        abilitiesController.rigidBody.velocity = Vector2.ClampMagnitude(abilitiesController.rigidBody.velocity, 2.5f);

        #endregion

        abilitiesController.characterMovement.movementEnabled = true;

        StartCooldown();
        StopCasting();
    }
}