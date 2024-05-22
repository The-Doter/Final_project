using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float value = 100;
    public RectTransform HealthRectTransform;
    public float _maxValue;
    public GameObject DieScreen;
    public GameObject LoseAudioScript;
    private bool OneTime = true;

    void Start()
    {
        DieScreen.SetActive(false);
        _maxValue = value;
        DrawHealthBar();
    }

    public void DealDamage(float damage)
    {
        value -= damage;
        if(value <= 0)
        {
            if(OneTime)
            {
                OneTime = false;
                Instantiate(LoseAudioScript);
            }
            Time.timeScale = 0;
            DieScreen.SetActive(true);
        }
        DrawHealthBar();
    }

    public void DrawHealthBar()
    {
        HealthRectTransform.anchorMax = new Vector2 (value / _maxValue, 1);
    }
}
