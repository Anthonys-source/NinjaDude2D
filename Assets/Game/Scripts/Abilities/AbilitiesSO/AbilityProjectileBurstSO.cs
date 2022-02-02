using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Abilities/Shuriken Burst")]
public class AbilityProjectileBurstSO : AbilitySO<AbilityProjectileBurst>
{
    public GameObject projectilePrefab = null;
    public float projectileVelocity = 25f;
    public float rotationSpeed = 480f;
    public int projectileAmount = 3;
    public float delayBetweenShurikens = 0.1f;

    protected override Ability GetConcreteAbility()
    {
        AbilityProjectileBurst ability = new AbilityProjectileBurst();
        ability.projectilePrefab = projectilePrefab;
        ability.projectileVelocity = projectileVelocity;
        ability.rotationSpeed = rotationSpeed;
        ability.projectileAmount = projectileAmount;
        ability.delayBetweenShurikens = delayBetweenShurikens;
        return ability;
    }
}

public class AbilityProjectileBurst : Ability
{
    public GameObject projectilePrefab = null;
    public float damage = 10.0f;
    public float projectileVelocity = 25f;
    public float rotationSpeed = 480f;
    public int projectileAmount = 3;
    public float delayBetweenShurikens = 0.1f;

    public override IEnumerator Cast()
    {
        StartCasting();

        #region Ability Behavior

        for (int i = 0; i < projectileAmount; i++)
        {
            Vector2 direction = (abilitiesController.input.Look - (Vector2)abilitiesController.transform.position).normalized;

            GameObject shuriken = Object.Instantiate(projectilePrefab, abilitiesController.proyectileEmission.position, Quaternion.identity);
            ProjectileController shurikePC = shuriken.GetComponent<ProjectileController>();
            shurikePC.Initialize(abilitiesController.gameObject, direction * projectileVelocity, rotationSpeed, damage);

            yield return new WaitForSeconds(delayBetweenShurikens);
        }

        #endregion

        StartCooldown();
        StopCasting();
    }
}