using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class PlatformAnimationScript : MonoBehaviour, IAnimatable
    {
        [SerializeField] private float verticalShift;
        [SerializeField] private float horizontalShift;
        [SerializeField] private int platformCount;
        [SerializeField] private float animDelay;
        [SerializeField] private float animDuration;
        [SerializeField] private Vector2 hiddenPos;

        [SerializeField] private GameObject platform;
        [SerializeField] private GameObject scenePlatform;

        private Vector2 platformStartPos;

        private readonly List<GameObject> platforms = new List<GameObject>();

        private void Awake()
        {
            platformStartPos = scenePlatform.transform.localPosition;
            scenePlatform.transform.localPosition = hiddenPos;
            
            platforms.Add(scenePlatform);
            Vector3 offset = hiddenPos;
            for (int i = 0; i < platformCount; i++)
            {
                offset.x -= horizontalShift;
                offset.y -= verticalShift;
                offset.z += 0.1f;
                platforms.Add(Instantiate(platform, offset, transform.rotation, transform ));
            }
        }

        public void StartAnim()
        {
            var sequence = DOTween.Sequence()
                .SetEase(Ease.OutCubic)
                .SetDelay(0);
            var i = 0f;
            foreach (var o in platforms)
            {
                sequence.Insert(i, o.transform.DOLocalMove(
                    (Vector3)platformStartPos + (o.transform.position - (Vector3)hiddenPos), animDuration));
                i += animDelay;
                //sequence.AppendInterval(animDelay);

            }            
        }
    }
}
