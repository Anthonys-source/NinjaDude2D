using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSetter : MonoBehaviour
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
}
