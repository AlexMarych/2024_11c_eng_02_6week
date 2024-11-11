using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Follow : MonoBehaviour
{
    public Transform ObjectToFollow;
    RectTransform rectTransform;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (ObjectToFollow)
        {
            rectTransform.anchoredPosition = ObjectToFollow.position;
        }
    }
}
