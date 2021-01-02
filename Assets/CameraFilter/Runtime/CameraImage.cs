using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    [RequireComponent(typeof(RawImage))]
    public class CameraImage : MonoBehaviour
    {
        private RawImage image;
        private void Awake()
        {
            image = GetComponent<RawImage>();
        }
        public void SetMaterial(Material mat)
        {
            image.material = mat;
        }
        
    }
}
