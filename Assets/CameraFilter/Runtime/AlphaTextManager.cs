using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    public class AlphaTextManager : MonoBehaviour
    {
        public Image AlphaTextBackground;
        public Text AlphaText;

        public void UpdateText(float alpha)
        {
            AlphaText.text = $"Alpha: {alpha:0.00}";
        }

        public void Show()
        {
            AlphaTextBackground.gameObject.SetActive(true);
            AlphaText.gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            AlphaTextBackground.gameObject.SetActive(false);
            AlphaText.gameObject.SetActive(false);
        }
    }
}
