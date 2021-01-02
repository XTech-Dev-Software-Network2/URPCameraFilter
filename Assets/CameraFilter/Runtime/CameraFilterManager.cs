using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CameraFilter.Runtime
{
    public class CameraFilterManager : MonoBehaviour
    {
        public CameraImage CameraImage;
        public Transform FilterContent;
        public List<FilterData> Filters;
        public CameraFilter PrefabCameraFilter;
        private List<CameraFilter> cameraFilters;
        
        [SerializeField] private AlphaTextManager alphaTextManager;
        [SerializeField] private AlphaControl alphaControl;

        private void Awake()
        {
            for (int i = 0; i < FilterContent.childCount; i++)
            {
                Destroy(FilterContent.GetChild(i).gameObject);
            }

            cameraFilters = new List<CameraFilter>();
            foreach (var filter in Filters)
            {
                var f = Instantiate(PrefabCameraFilter, FilterContent);
                f.SetData(filter);
                f.OnClick += OnClick;
                cameraFilters.Add(f);
            }

            alphaControl.OnChangeAlpha += UpdateAlpha;
            alphaControl.OnEndChangeAlpha += EndUpdateAlpha;
            alphaTextManager.Hide();
        }
        

        private void OnDestroy()
        {
            foreach (var cf in cameraFilters)
            {
                cf.OnClick -= OnClick;
            }
            alphaControl.OnChangeAlpha -= UpdateAlpha;
            alphaControl.OnEndChangeAlpha -= EndUpdateAlpha;
        }

        private void UpdateAlpha(float alpha)
        {
            foreach (var filter in Filters)
            {
                filter.Material.SetFloat("_Alpha", alpha);
            }
            alphaTextManager.Show();
            alphaTextManager.UpdateText(alpha);
        }

        private void EndUpdateAlpha()
        {
            alphaTextManager.Hide();
        }

        private FilterData GetfFilterData(string filterName) => Filters.Find(data => data.FilterName == filterName);
        private void OnClick(string filterName)
        {
            try
            {
                var filter = GetfFilterData(filterName);
                CameraImage.SetMaterial(filter.Material);
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}
