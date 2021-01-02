using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    [RequireComponent(typeof(Button))]
    public class CameraFilter : MonoBehaviour
    {
        private Button button;
        public Image SampleImage;
        public Text FilterNameText;
        public UnityAction<string> OnClick;
        
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClickImpl);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnClickImpl);
        }

        public void SetData(FilterData data)
        {
            SampleImage.material = data.Material;
            FilterNameText.text = data.FilterName;
        }

        private void OnClickImpl()
        {
            OnClick?.Invoke(FilterNameText.text);
        }
        
    }

    [Serializable]
    public struct FilterData
    {
        public Material Material;
        public string FilterName;
    }
}
