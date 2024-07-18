using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _healthComponent;
    [SerializeField] private RectTransform _foreground;

    void Update()
    {
        _foreground.localScale = new Vector3(_healthComponent.GetFraction(), 1f, 1f);

    }
}
