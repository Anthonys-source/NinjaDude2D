using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeController : MonoBehaviour
{
    public float lifetime = 2.5f;

    [SerializeField] private SpriteRenderer sprite;

    private void OnEnable()
    {
        StartCoroutine(DestroyTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(lifetime);
        while (sprite.color.a > 0.01f)
        {
            Color newColor = sprite.color;
            newColor.a -= 0.01f;
            sprite.color = newColor;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(this.gameObject);
    }
}
