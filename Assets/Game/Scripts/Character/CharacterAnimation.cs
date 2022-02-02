using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterAnimation : MonoBehaviour
{
    private Animator animator;
    private IGroundedGetter groundedGetter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


}
