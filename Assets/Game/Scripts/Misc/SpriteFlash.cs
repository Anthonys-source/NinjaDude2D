using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private Color color;

    private void Awake()
    {
        color = sprite.color;
    }

    public void Flash()
    {

    }

}
