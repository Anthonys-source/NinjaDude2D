using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Audio Manager")]
public class AudioManager : ScriptableObject
{
    public void PlayClipOnce(AudioClip audioClip,Vector3 position)
    {
        GameObject audioSource = new GameObject();
        AudioSource source = audioSource.AddComponent<AudioSource>();
        source.transform.position = position;
        source.PlayOneShot(audioClip);
    }
}