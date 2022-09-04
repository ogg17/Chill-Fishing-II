using DG.Tweening;
using UnityEngine;

namespace Audio
{
    public class AudioStart : MonoBehaviour
    {
        private void Awake()
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0;
            audioSource.DOFade(0.5f, 4).SetEase(Ease.InCubic);
        }
    }
}
