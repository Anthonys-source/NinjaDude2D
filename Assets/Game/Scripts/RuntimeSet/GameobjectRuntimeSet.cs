using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectRuntimeSet : MonoBehaviour
{
    [SerializeField] private GameObjectSet runtimeSet;

    private void Start()
    {
        if(runtimeSet == null)
        {
            throw new MissingReferenceException();
        }
    }

    private void OnEnable()
    {
        if(runtimeSet)
        runtimeSet.Add(this.gameObject);
    }

    private void OnDisable()
    {
        runtimeSet.Remove(this.gameObject);
    }
}
