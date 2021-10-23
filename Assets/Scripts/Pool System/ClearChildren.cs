using UnityEngine;

namespace Grincewicz.PoolSystem
{
    ///<summary>
    ///@author
    ///Aaron Grincewicz
    ///</summary>
    public class ClearChildren : MonoBehaviour
    {
        private static ClearChildren _instance;
        public static ClearChildren Instance { get => _instance; }

        private void Awake()
        {
            _instance = this;
        }
        public void ClearChildObjects(Transform transform)
        {
            if (transform.childCount > 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    var child = transform.GetChild(i);
                    if(!child.gameObject.activeInHierarchy)
                        Destroy(child.gameObject);
                }
            }
        }
    }
}
