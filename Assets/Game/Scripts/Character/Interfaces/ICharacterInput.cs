using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface ICharacterInput : IMovementGetter,IJumpGetter,ILookGetter
{
    public event UnityAction<int> CastAbility;
    public Vector2 SpeedFade { get; }
}
