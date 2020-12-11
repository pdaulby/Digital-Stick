using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngleVisuals : MonoBehaviour
{
    [SerializeField] private Slider AngleSlider;

    private Image[] images;
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        AngleSlider.onValueChanged.AddListener(delegate { UpdateVisuals(AngleSlider.value); });
        UpdateVisuals(AngleSlider.value);
    }


    void UpdateVisuals(float angle)
    {
        foreach(Image i in images)
        {
            i.fillAmount = 0.25f * angle / 180f;
        }
    }
}
