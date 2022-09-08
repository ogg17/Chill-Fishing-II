using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ColorPulse : MonoBehaviour
{
    [SerializeField] private Color endColor;
    [SerializeField] private float pulseDuration;
    private void Start()
    {
        var sequence = DOTween.Sequence();
        sequence.Insert(0, Rotation()).SetLoops(-1, LoopType.Restart);

    }

    private Tween Color()
    {
        var color = GetComponent<TextMeshPro>();
        var startColor = color.color;
        var sequenceColor = DOTween.Sequence();
        sequenceColor
            //.AppendInterval(pulseDuration)
            .SetEase(Ease.InCubic)
            //.SetDelay(pulseDuration)
            .Insert(0,color.DOColor(endColor, pulseDuration))
            .Insert(pulseDuration,color.DOColor(startColor, pulseDuration));
        return sequenceColor;
    }

    private Tween Rotation()
    {
        var startRot = transform.rotation.eulerAngles;
        startRot.z = -3;
        var endRot = startRot;
        endRot.z = 3;
        var sequenceRotation = DOTween.Sequence();
        sequenceRotation.SetEase(Ease.OutCubic)
            //.SetDelay(pulseDuration)
            //.AppendInterval(pulseDuration)
            .Insert(pulseDuration, transform.DORotate(startRot, pulseDuration))
            .Insert(2*pulseDuration, transform.DORotate(endRot, pulseDuration));            
        return sequenceRotation;
    }
}
