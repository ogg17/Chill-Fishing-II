using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DinSound : MonoBehaviour
{
    [SerializeField] private float startTime = 3;

    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(DinSoundStart());
    }
     private IEnumerator DinSoundStart()
    {
        yield return new WaitForSeconds(startTime);
        source.Play();
    }
}
