using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickVisuals : MonoBehaviour
{
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rectTransform.localPosition = new Vector3((50 * horizontal), (50 * vertical));
    }
}
