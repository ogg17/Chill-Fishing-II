using DG.Tweening;
using UnityEngine;

namespace Audio
{
    public class AudioStart : MonoBehaviour
    {
        [SerializeField][Range(0, 1)] private float volumeLevel = 0.5f;
        [SerializeField] private float duration = 3;
        private void Awake()        
        {
            var audioSource = GetComponent<AudioSource>();
            audioSource.volume = 0;
            audioSource.DOFade(volumeLevel, duration).SetEase(Ease.InCubic);
        }
    }
}
