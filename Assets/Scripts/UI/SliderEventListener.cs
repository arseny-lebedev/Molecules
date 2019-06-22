using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class SliderEventListener : BaseEventListener
    {
        private void OnEnable()
        {
            Slider button = GetComponent<Slider>();
            if (button != null)
            {
                button.onValueChanged.RemoveListener(OnValueChanged);
                button.onValueChanged.AddListener(OnValueChanged);
            }
        }

        static public BaseEventListener Get(Slider go)
        {
            if (go == null)
            {
                Debug.LogError("Can not create event source: Button is null!");
                return null;
            }

            BaseEventListener listener = go.GetComponent<BaseEventListener>();
            if (listener == null) listener = go.gameObject.AddComponent<SliderEventListener>();
            return listener;
        }
    }
}