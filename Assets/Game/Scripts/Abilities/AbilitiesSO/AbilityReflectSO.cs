using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Abilities/Reflect")]
public class AbilityReflectSO : AbilitySO
{
    public GameObject reflectHitboxPrefab;
    protected override Ability GetConcreteAbility()
    {
        AbilityReflect ability = new AbilityReflect();
        ability.reflectHitboxPrefab = reflectHitboxPrefab;
        return ability;
    }
}
public class AbilityReflect : Ability
{
    public GameObject reflectHitboxPrefab;
    public override IEnumerator Cast()
    {
        StartCasting();

        #region Ability Behavior

        Vector2 direction = (abilitiesController.input.Look - (Vector2)abilitiesController.transform.position).normalized;
        GameObject hitbox = Object.Instantiate(reflectHitboxPrefab, abilitiesController.transform);
        ReflectHitbox hitboxReflect = hitbox.GetComponent<ReflectHitbox>();
        hitboxReflect.newEmitter = abilitiesController.gameObject;

        float timeElapsed = 0.0f;
        while (timeElapsed < castTime)
        {
            direction = (abilitiesController.input.Look - (Vector2)abilitiesController.transform.position).normalized;
            hitbox.transform.rotation = Quaternion.FromToRotation(hitbox.transform.right, direction) * hitbox.transform.rotation;
            hitboxReflect.newDirection = direction;

            timeElapsed += 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
        Object.Destroy(hitbox);

        #endregion

        StartCooldown();
        StopCasting();
    }
}
