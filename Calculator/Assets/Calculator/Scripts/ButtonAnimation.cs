using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    [Tooltip("Specifies punch intensity")]
    [SerializeField] private float _punchAmount = 0.2f;

    [Tooltip("Specifies punch duration")]
    [SerializeField] private float _punchDuration = 0.1f;

    [Tooltip("Specifies vibrates")]
    [SerializeField] private int _vibrator =  3;

    [Tooltip("Specifies elasticity")]
    [SerializeField] private float _elasticity = 0.5f;

    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = transform.localScale;
    }
    public void PlayAnimation()
    {
        transform.DOKill(); 
        transform.localScale = _defaultScale;

        transform.DOPunchScale(
            Vector3.one * _punchAmount,
            _punchDuration,
            _vibrator,
            _elasticity
        );
    }
}
