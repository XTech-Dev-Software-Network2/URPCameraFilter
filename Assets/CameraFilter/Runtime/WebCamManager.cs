using System;
using UnityEngine;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    public class WebCamManager : MonoBehaviour
    {
        public RawImage TargetImage;
        private WebCamTexture tex;
        private int deviceID;
        private bool initialize = false;

        private void Start()
        {
            initialize = false;
            ChangeToNextDevice();
        }

        private void Update()
        {
            if (tex.isPlaying)
            {
                var screenAspect = 16.0f / 9.0f;
                var camAspect = 1.0f*tex.width / tex.height;

                if (camAspect > screenAspect)
                {
                    var w = camAspect*1080.0f;
                    var h = 1080.0f;
                    TargetImage.rectTransform.sizeDelta = new Vector2(w, h);
                }
                else
                {
                    var w = 1920.0f;
                    var h = 1920.0f / camAspect;
                    TargetImage.rectTransform.sizeDelta = new Vector2(w, h);
                }
            }
            
        }

        public void ChangeToNextDevice()
        {
            var deviceNum = WebCamTexture.devices.Length;
            if (deviceNum == 0) return;
            deviceID = (deviceID + 1) % deviceNum;
            if (tex && tex.isPlaying)
            {
                tex.Stop();
            }

            var device = WebCamTexture.devices[deviceID];
            tex = new WebCamTexture(device.name);
            tex.requestedFPS = 60.0f;
            tex.Play();
            TargetImage.texture = tex;
            var scale = device.isFrontFacing ? new Vector3(-1, 1, 1) : new Vector3(-1, -1, 1);
            TargetImage.rectTransform.localScale = scale;
            initialize = true;
        }
    }
}
