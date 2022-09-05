using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderTransition : MonoBehaviour
{
    [SerializeField] private Color transitionColor;
    [SerializeField] private float offsetValue = 0.8f;
   // [SerializeField] private float sizeValue = 0.1f;
    [SerializeField] private float startTime = 4;
    [SerializeField] private float duration = 1.5f;

    private MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(TransitionStart());
    }

    private IEnumerator TransitionStart()
    {
        var startColor = meshRenderer.material.color;
        var startOffset = meshRenderer.material.GetFloat("_TOffset");
       // var startSize = meshRenderer.material.GetFloat("_Size");
        yield return new WaitForSeconds(startTime);
        meshRenderer.material.DOFloat(offsetValue, "_TOffset", duration);
       // meshRenderer.material.DOFloat(sizeValue, "_Size", duration);
        meshRenderer.material.DOColor(transitionColor, duration);
        yield return new WaitForSeconds(duration * 2);
        meshRenderer.material.DOFloat(startOffset, "_TOffset", duration);
       // meshRenderer.material.DOFloat(startSize, "_Size", duration);
        meshRenderer.material.DOColor(startColor, duration);
    }

}
