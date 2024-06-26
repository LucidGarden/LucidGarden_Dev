﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{
    public RectTransform rectTransform;
    public void Update()
    {
        if (GameManager.instance.marketManager.marketUI.marketUI.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Input.mousePosition;
                if(!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos))
                {
                    rectTransform.gameObject.SetActive(false);
                }
            }
        }

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 0f);
                if (hit.collider != null && hit.collider.GetComponent<Market>() != null)
                {
                    GameManager.instance.marketManager.marketUI.marketUI.SetActive(true);
                }
            }
        }
    }
}
