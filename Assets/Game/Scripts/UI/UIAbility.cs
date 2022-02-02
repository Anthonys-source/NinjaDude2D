using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAbility : MonoBehaviour
{
    private List<Image> images = new List<Image>();

    [SerializeField] private FloatEventChannelSO abilityStartCooldownEvent;
    [SerializeField] private FloatEventChannelSO abilityBlockCastingEvent;
    [SerializeField] private float dimmedValue = 0.5f;

    private Color baseColorRGB = new Color(1f, 1f, 1f, 1f);
    private float H;
    private float S;
    private float V;

    public UnityEvent<float> OnSetOnCooldown;

    private void OnEnable()
    {
        abilityStartCooldownEvent.onEventRaised += SetOnCooldown;
        abilityBlockCastingEvent.onEventRaised += SetOnCasting;
    }

    private void OnDisable()
    {
        abilityStartCooldownEvent.onEventRaised -= SetOnCooldown;
        abilityBlockCastingEvent.onEventRaised -= SetOnCasting;
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Image childImageComponent = transform.GetChild(i).GetComponent<Image>();
            if (childImageComponent != null)
            {
                images.Add(childImageComponent);
            }
        }
        Color.RGBToHSV(baseColorRGB, out H, out S, out V);
    }

    public void SetOnCooldown(float time)
    {
        V -= dimmedValue;
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = Color.HSVToRGB(H, S, V);
        }
        OnSetOnCooldown.Invoke(time);
        StopCoroutine(SetOffCooldownTimer(time));
        StartCoroutine(SetOffCooldownTimer(time));
    }

    public void SetOffCooldown()
    {
        V += dimmedValue;
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = Color.HSVToRGB(H, S, 1f);
        }
    }

    public void SetOnCasting(float time)
    {
        V -= dimmedValue;
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = Color.HSVToRGB(H, S, 1 - dimmedValue);
        }
        StopCoroutine(SetOffCastingTimer(time));
        StartCoroutine(SetOffCastingTimer(time));
    }

    private void SetOffCasting()
    {
        V += dimmedValue;
        for (int i = 0; i < images.Count; i++)
        {
            images[i].color = Color.HSVToRGB(H, S, V);
        }
    }

    private IEnumerator SetOffCastingTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SetOffCasting();
    }

    private IEnumerator SetOffCooldownTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SetOffCooldown();
    }
}
