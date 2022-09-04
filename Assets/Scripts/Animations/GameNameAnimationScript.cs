using DG.Tweening;
using UnityEngine;

namespace Animations
{
    public class GameNameAnimationScript : MonoBehaviour, IAnimatable
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

        public Tween StartAnim()
        {
            var sequence = DOTween.Sequence()
                .SetEase(Ease.OutCubic)
                .SetDelay(0)
                .Insert(1*animDelay,fishingObject.transform.DOLocalMove(_fishingPos, animDuration))
                .Insert(2*animDelay,chiObject.transform.DOLocalMove(_chiPos, animDuration))
                .Insert(3*animDelay,llObject.transform.DOLocalMove(_llPos, animDuration));

            //.Append(houseObject.transform.DOMove(_housePos, animDuration));
            return sequence;
        }

        public void OnFinishedSplashScreen()
        {
            
        }
    }
}
