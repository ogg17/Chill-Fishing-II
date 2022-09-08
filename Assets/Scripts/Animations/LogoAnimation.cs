using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Animations
{
    

public class LogoAnimation : MonoBehaviour, IAnimatable
{
    [SerializeField] private float logoDuration = 6;
    [SerializeField] private float logoFade = 2;

    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    public void StartAnim()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {        
        var colorZero = spriteRender.color;
        colorZero.a = 0;
        yield return new WaitForSeconds(logoDuration);
        spriteRender.DOColor(colorZero, logoFade);     
        yield return new WaitForSeconds(logoFade + 1f);
        Destroy(this);   
    }

}
}
