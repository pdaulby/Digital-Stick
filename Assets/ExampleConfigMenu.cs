using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExampleConfigMenu : MonoBehaviour
{
    private float verticalAngle;
    private float horizontalAngle;
    private float deadzone;
    private bool validSettings = true;

    [SerializeField] private Slider VerticalSlider;
    [SerializeField] private Slider HorizontalSlider;
    [SerializeField] private Slider DeadzoneSlider;
    [SerializeField] private TextMeshProUGUI VerticalText;
    [SerializeField] private TextMeshProUGUI HorizontalText;
    [SerializeField] private TextMeshProUGUI DeadzoneText;
    [SerializeField] private TextMeshProUGUI DirectionText;

    private BinaryStickInput binaryStickInput;

    void Start()
    {
        verticalAngle = VerticalSlider.value;
        horizontalAngle = HorizontalSlider.value;
        deadzone = DeadzoneSlider.value / 100;

        VerticalText.text = VerticalSlider.value.ToString();
        HorizontalText.text = HorizontalSlider.value.ToString();
        DeadzoneText.text = DeadzoneSlider.value.ToString();
        DirectionText.text = Direction.Neutral.ToString();

        VerticalSlider.onValueChanged.AddListener(delegate { UpdateVerticalAngle(); });
        HorizontalSlider.onValueChanged.AddListener(delegate { UpdateHorizontalAngle(); });
        DeadzoneSlider.onValueChanged.AddListener(delegate { UpdateDeadzone(); });
        UpdateVisualsAndInput();
    }

    void Update()
    {        
        if (!validSettings)
        {
            DirectionText.text = "Angles are too large";
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Direction direction = binaryStickInput.GetDirection(horizontal, vertical);
        DirectionText.text = direction.ToString();
    }

    private void UpdateVerticalAngle()
    {
        verticalAngle = VerticalSlider.value;
        VerticalText.text = verticalAngle.ToString();
        UpdateVisualsAndInput();
    }

    private void UpdateHorizontalAngle()
    {
        horizontalAngle = HorizontalSlider.value;
        HorizontalText.text = horizontalAngle.ToString();
        UpdateVisualsAndInput();
    }

    private void UpdateDeadzone()
    {
        DeadzoneText.text = DeadzoneSlider.value.ToString();
        deadzone = DeadzoneSlider.value / 100;
        UpdateVisualsAndInput();
    }

    private void UpdateVisualsAndInput()
    {
        validSettings = BinaryStickInput.AllowsAngles(horizontalAngle, verticalAngle);
        if (!validSettings) return;

        binaryStickInput = BinaryStickInput.FromAngles(horizontalAngle, verticalAngle, deadzone);
    }
}
