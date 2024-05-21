using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform HealthRectTransform;
    public float _maxValue;

    void Start()
    {
        _maxValue = value;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            Destroy(gameObject);
        }
        DrawHealthBar();
    }

    public void DrawHealthBar()
    {
        HealthRectTransform.anchorMax = new Vector2 (value / _maxValue, 1);
    }
}
