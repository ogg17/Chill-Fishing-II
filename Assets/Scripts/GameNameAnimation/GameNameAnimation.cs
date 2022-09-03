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
        
        /*[Space]
        [SerializeField] private GameObject houseObject;
        [SerializeField] private Vector2 houseHiddenPosition;
        private Vector3 _housePos;*/
        
        [Space]
        [SerializeField] private float animDuration;

        [SerializeField] private float animDelay;

        private void Awake()
        {
            _fishingPos = fishingObject.transform.localPosition;
            _chiPos = chiObject.transform.localPosition;
            _llPos = llObject.transform.localPosition;
            //_housePos = houseObject.transform.position;
            
            fishingObject.transform.localPosition = fishingHiddenPosition;
            chiObject.transform.localPosition = chiHiddenPosition;
            llObject.transform.localPosition = llHiddenPosition;
            //houseObject.transform.position = houseHiddenPosition;
        }

        private void Start()
        {
            var sequence = DOTween.Sequence();
            sequence
                .SetEase(Ease.OutCubic)
                .SetDelay(animDelay)
                .Append(fishingObject.transform.DOLocalMove(_fishingPos, animDuration))
                .Append(chiObject.transform.DOLocalMove(_chiPos, animDuration))
                .Append(llObject.transform.DOLocalMove(_llPos, animDuration));
                //.Append(houseObject.transform.DOMove(_housePos, animDuration));
            //sequence.Kill();
        }

        public void OnFinishedSplashScreen()
        {
            
        }
    }
}
