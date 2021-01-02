using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    [RequireComponent(typeof(Image))]
    public class AlphaControl : EventTrigger
    {
        public Image image;
        public UnityAction<float> OnChangeAlpha;
        public UnityAction OnEndChangeAlpha;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        public override void OnDrag(PointerEventData eventData)
        {
            var alpha = Mathf.Clamp01(eventData.position.x / image.rectTransform.rect.width);
            OnChangeAlpha?.Invoke(alpha);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            OnEndChangeAlpha?.Invoke();
        }
    }
}
