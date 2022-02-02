using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerHitFXController : MonoBehaviour
{
    [SerializeField] private Volume volume;
    private Vignette vignette;
    [SerializeField] private float changePerUpdate = 0.0025f;
    [SerializeField] private float updateRate = 0.05f;
    [SerializeField] private VoidEventChannelSO playerHitEvent;

    private void OnEnable()
    {
        playerHitEvent.onEventRaised += SetRedVignette;
    }

    private void OnDisable()
    {
        playerHitEvent.onEventRaised -= SetRedVignette;
    }

    private void Awake()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet<Vignette>(out vignette);
    }

    public void SetRedVignette()
    {
        vignette.intensity.value = 0.3f;
        StopCoroutine(ResetVignette());
        StartCoroutine(ResetVignette());
    }

    private IEnumerator ResetVignette()
    {
        while(vignette.intensity.value > 0.0f)
        {
            vignette.intensity.value -= changePerUpdate;
            yield return new WaitForSeconds(updateRate);
        }
    }
}
