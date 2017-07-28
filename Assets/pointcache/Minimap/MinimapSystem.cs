namespace pointcache.Minimap {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MinimapSystem : MonoBehaviour {

        protected static MinimapSystem m_instance;
        public static MinimapSystem Instance
        {
            get {
                if (!m_instance)
                    m_instance = GameObject.FindObjectOfType<MinimapSystem>();
                return m_instance;
            }
        }

        protected List<MinimapIcon> m_iconsPool = new List<MinimapIcon>();

        protected Dictionary<MinimapObject, MinimapIcon> m_objs_iconsDict = new Dictionary<MinimapObject, MinimapIcon>();

        [SerializeField]
        protected Transform m_mapFocus;

        [SerializeField]
        protected RectTransform m_iconsRoot;

        [SerializeField]
        protected GameObject m_iconPrefab;

        protected Vector3 minimapCenter
        {
            get {
                return m_iconsRoot.rect.center;
            }
        }

        [SerializeField]
        protected float m_maxIconDistance = 100f;

        [SerializeField]
        protected float m_Scale = 1f;

        internal void RegisterMMObject(MinimapObject obj) {

            var icon = ConstructIcon(obj);
            m_iconsPool.Add(icon);
            m_objs_iconsDict.Add(obj, icon);
        }

        internal void UnRegisterMMObject(MinimapObject obj) {

            MinimapIcon icon;

            m_objs_iconsDict.TryGetValue(obj, out icon);

            if (!icon) {
                Debug.LogError("Trying to unregister icon that is not registered, how did this happen?");
                return;
            }

            m_iconsPool.Remove(icon);
        }

        protected virtual void Update() {

            int count = m_iconsPool.Count;

            for (int i = 0; i < count; i++) {

                var icon = m_iconsPool[i];

                icon.gameObject.SetActive(CheckVisibility(icon));

                icon.rectTransform.anchoredPosition = ConvertPosition(icon.target.transform.position) * m_Scale;

            }
        }

        protected virtual MinimapIcon ConstructIcon(MinimapObject mmobj) {

            if (!m_iconPrefab) {
                Debug.Log("Icon prefab is null, aborting icon construction.");
                return null;
            }

            m_iconPrefab.SetActive(false);

            var go = Instantiate(m_iconPrefab, m_iconsRoot, false);

            var icon = go.GetComponent<MinimapIcon>();

            icon.target = mmobj;

            icon.gameObject.SetActive(true);

            m_iconPrefab.SetActive(true);


            return icon;

        }

        protected virtual bool CheckVisibility(MinimapIcon icon) {
            return Vector3.Distance(icon.rectTransform.anchoredPosition, Vector3.zero) < m_maxIconDistance;
        }

        protected virtual Vector3 ConvertPosition(Vector3 position) {

            Vector3 transformed = m_mapFocus.transform.InverseTransformPoint(position);
            return new Vector3(transformed.x, transformed.z, 0f);

        }

    }

}