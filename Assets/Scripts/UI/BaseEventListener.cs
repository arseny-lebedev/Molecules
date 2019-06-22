using UnityEngine;

namespace Assets.Scripts.UI
{
    public class BaseEventListener : MonoBehaviour
    {
        public delegate void VoidDelegate(GameObject go);
        public delegate void BoolDelegate(GameObject go, bool state);
        public delegate void floatDelegate(GameObject go, float value);

        public VoidDelegate onClick;
        public BoolDelegate onStateChanged;
        public floatDelegate onValueChanged;

        protected void OnStateChanged(bool b)
        {
            if (onStateChanged != null)
            {
                onStateChanged(gameObject, b);
            }
        }

        protected void OnClick()
        {
            if (onClick != null)
            {
                onClick(gameObject);
            }

        }
        protected void OnValueChanged(float value)
        {
            if (onValueChanged != null)
            {
                onValueChanged(gameObject, value);
            }

        }
        public void Clear()
        {
            onClick = null;
        }
    }
}