using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadzoneVisuals : MonoBehaviour
{
    [SerializeField] private Slider DeadzoneSlider;

    private RectTransform rectTransform;
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        DeadzoneSlider.onValueChanged.AddListener(delegate { UpdateVisuals(DeadzoneSlider.value); });
        UpdateVisuals(DeadzoneSlider.value);
    }


    void UpdateVisuals(float deadzone)
    {
        rectTransform.localScale = new Vector3(deadzone / 100, deadzone / 100);
    }
}
