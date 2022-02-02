using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandAnimation : MonoBehaviour
{
    [SerializeField] private GameObject ILookGetter;
    private ILookGetter lookGetter;
    [SerializeField] private Transform handTransform;

    private void Awake()
    {
        lookGetter = ILookGetter.GetComponent<ILookGetter>();
    }

    private void Update()
    {
        Vector3 newDirection = (Vector3) lookGetter.Look - handTransform.position;
        handTransform.rotation = Quaternion.FromToRotation(handTransform.right, newDirection) * handTransform.rotation;
    }
}
