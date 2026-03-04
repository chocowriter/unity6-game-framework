using UnityEngine;

namespace Framework
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>, new()
    {
        protected static bool autoDestroy;

        public static T instance
        {
            get { return Singleton<T>.instance; }
        }

        protected virtual void Awake()
        {

            if (this == instance) DontDestroyOnLoad(transform.root.gameObject);

            else if (autoDestroy) Destroy(this);

            else Debug.LogErrorFormat(this, "Singleton<{0}> has excess instance {1}.", typeof(T), name);
        }
    }
}