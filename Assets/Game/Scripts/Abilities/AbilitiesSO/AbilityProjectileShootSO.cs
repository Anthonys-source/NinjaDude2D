using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Abilities/Projectile Shoot")]
public class AbilityProjectileShootSO : AbilitySO<AbilityProjectileShoot>
{
    public GameObject projectilePrefab = null;
    public float projectileVelocity = 25f;

    protected override Ability GetConcreteAbility()
    {
        AbilityProjectileShoot ability = new AbilityProjectileShoot();
        ability.projectilePrefab = projectilePrefab;
        ability.projectileVelocity = projectileVelocity;
        return ability;
    }
}

public class AbilityProjectileShoot : Ability
{
    public float damage = 10.0f;
    public GameObject projectilePrefab = null;
    public float projectileVelocity = 25f;
    public Vector3 projectileSpawnOffset = new Vector2();

    public override IEnumerator Cast()
    {

        #region Ability Behavior

        Vector2 direction = (abilitiesController.input.Look - (Vector2)abilitiesController.proyectileEmission.position).normalized;
        GameObject shuriken = Object.Instantiate(projectilePrefab, abilitiesController.proyectileEmission.position, Quaternion.identity);
        ProjectileController shurikePC = shuriken.GetComponent<ProjectileController>();
        shurikePC.Initialize(abilitiesController.gameObject, direction * projectileVelocity, 0.0f, damage);

        #endregion

        StartCooldown();

        yield return null;
    }
}