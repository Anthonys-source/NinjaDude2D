using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game/Abilities/Projectile Fan")]
public class AbilityProjectileFanSO : AbilitySO<AbilityProjectileFan>
{
    public GameObject projectilePrefab = null;
    public float projectileVelocity = 25f;
    public float rotationSpeed = 480f;
    public int projectileAmount = 3;
    public float fanSizeInDegrees = 45f;

    protected override Ability GetConcreteAbility()
    {
        AbilityProjectileFan ability = new AbilityProjectileFan();
        ability.projectilePrefab = projectilePrefab;
        ability.projectileVelocity = projectileVelocity;
        ability.rotationSpeed = rotationSpeed;
        ability.projectileAmount = projectileAmount;
        ability.fanSizeInDegrees = fanSizeInDegrees;
        return ability;
    }
}

public class AbilityProjectileFan : Ability
{
    
    public GameObject projectilePrefab = null;
    public float damage = 10.0f;
    public float projectileVelocity = 25f;
    public float rotationSpeed = 480f;
    public int projectileAmount = 3;
    public float fanSizeInDegrees = 45f;

    public override IEnumerator Cast()
    {

        #region Ability Behavior

        Vector2 direction = (abilitiesController.input.Look - (Vector2)abilitiesController.transform.position).normalized;

        for (int i = 0; i < projectileAmount; i++)
        {
            GameObject projectile = Object.Instantiate(projectilePrefab, abilitiesController.proyectileEmission.position, Quaternion.identity);

            ProjectileController projectilePC = projectile.GetComponent<ProjectileController>();
            projectilePC.Initialize(abilitiesController.gameObject, CalculateDirection(i, direction) * projectileVelocity, rotationSpeed, damage);
        }

        #endregion

        StartCooldown();

        yield return null;
    }

    private Vector3 CalculateDirection(int i, Vector3 baseDirection)
    {
        float directionSpreadOffset = 0.0f;
        if (projectileAmount - 1 != 0)
        {
            //Normalize the range from [0,spreadAngle] to [-spreadAngle/2,spreadAngle/2]
            directionSpreadOffset = fanSizeInDegrees * ((float)i / (projectileAmount - 1));
            directionSpreadOffset = ((directionSpreadOffset * (fanSizeInDegrees) / fanSizeInDegrees)) - (fanSizeInDegrees / 2);
        }
        return Quaternion.Euler(0.0f, 0.0f, directionSpreadOffset) * baseDirection;
    }
}