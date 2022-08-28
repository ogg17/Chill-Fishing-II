using System;
using DG.Tweening;
using UnityEngine;

namespace GameNameAnimation
{
    public class GameNameAnimation : MonoBehaviour
    {
        [SerializeField] private GameObject fishingObject;
        [SerializeField] private Vector2 fishingHiddenPosition;
        private Vector3 _fishingPos;
        
        [Space]
        [SerializeField] private GameObject chiObject;
        [SerializeField] private Vector2 chiHiddenPosition;
        private Vector3 _chiPos;
        
        [Space]
        [SerializeField] private GameObject llObject;
        [SerializeField] private Vector2 llHiddenPosition;
        private Vector3 _llPos;
        
        [Space]
        [SerializeField] private GameObject houseObject;
        [SerializeField] private Vector2 houseHiddenPosition;
        private Vector3 _housePos;
        
        [Space]
        [SerializeField] private float animDuration;

        [SerializeField] private float animDelay;

        private void Awake()
        {
            _fishingPos = fishingObject.transform.position;
            _chiPos = chiObject.transform.position;
            _llPos = llObject.transform.position;
            _housePos = houseObject.transform.position;
            
            fishingObject.transform.position = fishingHiddenPosition;
            chiObject.transform.position = chiHiddenPosition;
            llObject.transform.position = llHiddenPosition;
            houseObject.transform.position = houseHiddenPosition;
        }

        private void Start()
        {
            var sequence = DOTween.Sequence();
            sequence
                .SetEase(Ease.OutCubic)
                .SetDelay(animDelay)
                .Append(fishingObject.transform.DOMove(_fishingPos, animDuration))
                .Append(chiObject.transform.DOMove(_chiPos, animDuration))
                .Append(llObject.transform.DOMove(_llPos, animDuration))
                .Append(houseObject.transform.DOMove(_housePos, animDuration));
            //sequence.Kill();
        }

        public void OnFinishedSplashScreen()
        {
            
        }
    }
}
