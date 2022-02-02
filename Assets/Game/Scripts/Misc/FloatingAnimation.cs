using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    public float amplitude;
    public float speed;
    private Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        Vector3 newPosition = startPosition;
        newPosition.y = newPosition.y + amplitude * Mathf.Sin(speed*Time.time);
        transform.position = newPosition;
    }
}
