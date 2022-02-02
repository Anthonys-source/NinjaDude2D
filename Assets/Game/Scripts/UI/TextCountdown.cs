using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextCountdown : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    private void Awake()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void SetTextTo(string text)
    {
        textComponent.text = text;
    }

    public void StartCountdown(float time)
    {
        StartCoroutine(Countdown(time,0.1f));
    }

    public IEnumerator Countdown(float time,float updateFrecuency)
    {
        float timeElapsed = 0.0f;
        while(timeElapsed < time)
        {
            SetTextTo((time - timeElapsed).ToString("F1"));
            yield return new WaitForSeconds(updateFrecuency);
            timeElapsed += updateFrecuency;
        }
        SetTextTo("");
    }
}
