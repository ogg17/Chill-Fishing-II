using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneLoader : MonoBehaviour
{
    [SerializeField] private float logoDuration = 6;
    [SerializeField] private float logoFade = 2;

    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        var colorZero = spriteRender.color;
        colorZero.a = 0;
        yield return new WaitForSeconds(logoDuration);
        spriteRender.DOColor(colorZero, logoFade - 0.5f);
        yield return new WaitForSeconds(logoFade);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

}
