using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSystem : MonoBehaviour {

    private static MinimapSystem m_instance;
    public static MinimapSystem Instance
    {
        get {
            if (!m_instance)
                m_instance = GameObject.FindObjectOfType<MinimapSystem>();
            return m_instance;
        }
    }

    private List<MinimapObject> m_minimapObjectsPool = new List<MinimapObject>();

    
    private class MinimapIcon {

        public RectTransform iconTransform;
        public Transform targetTransform;

        public MinimapIcon(MinimapObject.Config config) {

        }

    }


    internal void RegisterMMObject(MinimapObject obj) {
        m_minimapObjectsPool.Add(obj);
    }

    internal void UnRegisterMMObject(MinimapObject obj) {
        m_minimapObjectsPool.Remove(obj);
    }

    private void Update() {

        int count = m_minimapObjectsPool.Count;

        for (int i = 0; i < count; i++) {



        }

    }

}
