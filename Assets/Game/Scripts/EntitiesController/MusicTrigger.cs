using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!source.isPlaying)
        {
            source.clip = clip;
            source.loop = true;
            source.volume = 0.0f;
            source.Play();
            StartCoroutine(FadeInMusic());
        }
    }

    private IEnumerator FadeInMusic()
    {
        while(source.volume < 0.98f)
        {
            source.volume += 0.01f;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
