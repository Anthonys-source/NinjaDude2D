using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAbilities : MonoBehaviour
{
    [System.Serializable]
    public struct AbilityStruct
    {
        public AbilitySO abilitySO;
        public UnityEvent<float> OnAbilityCooldownStart;
    }

    public Transform proyectileEmission;
    [SerializeField] private List<AbilityStruct> characterAbilities = new List<AbilityStruct>();
    [SerializeField] private UnityEvent<float> OnAbilityCastTimeStart = new UnityEvent<float>();

    private List<Ability> abilities = new List<Ability>();

    [HideInInspector] public ICharacterInput input;
    [HideInInspector] public Rigidbody2D rigidBody;
    [HideInInspector] public CharacterMovement characterMovement;
    [HideInInspector] public bool currentlyCasting = false;

    private void Awake()
    {
        input = GetComponent<ICharacterInput>();
        rigidBody = GetComponent<Rigidbody2D>();
        characterMovement = GetComponent<CharacterMovement>();

        for (int i = 0; i < characterAbilities.Count; i++)
        {
            Ability abilityToAdd = characterAbilities[i].abilitySO.GetAbility(this);
            abilityToAdd.onCooldownStart += characterAbilities[i].OnAbilityCooldownStart.Invoke;
            abilityToAdd.onCastTimeStart += OnAbilityCastTimeStart.Invoke;

            abilities.Add(abilityToAdd);
        }
    }

    private void CastAbility(int abilityIndex)
    {
        if(abilities.Count > abilityIndex && !abilities[abilityIndex].OnCooldown && !currentlyCasting)
        {
            StartCoroutine(abilities[abilityIndex].Cast());
        }
    }

    public IEnumerator ResetLockedCasting(float time)
    {
        yield return new WaitForSeconds(time);
        currentlyCasting = false;
    }

    private void OnEnable()
    {
        input.CastAbility += CastAbility;
    }

    private void OnDisable()
    {
        input.CastAbility -= CastAbility;
    }

}
