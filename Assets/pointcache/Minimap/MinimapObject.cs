namespace pointcache.Minimap {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class MinimapObject : MonoBehaviour {


        [SerializeField]
        private Config m_config = new Config();

        public Config config
        {
            get { return m_config; }
        }

        [System.Serializable]
        public class Config {

            public Sprite icon;
            public Color color = Color.white;

        }

        protected virtual void OnEnable() {
            MinimapSystem.Instance.RegisterMMObject(this);
        }

        protected virtual void OnDisable() {
            MinimapSystem.Instance.UnRegisterMMObject(this);
        }
    }

}