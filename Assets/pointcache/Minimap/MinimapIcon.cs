namespace pointcache.Minimap {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class MinimapIcon : MonoBehaviour {

        public MinimapObject target;

        private Image image;

        public RectTransform rectTransform;

        private void OnEnable() {

            image = GetComponent<Image>();

            rectTransform = GetComponent<RectTransform>();

            if (target.config.icon)
                image.sprite = target.config.icon;

            image.color = target.config.color;

        }

    }

}