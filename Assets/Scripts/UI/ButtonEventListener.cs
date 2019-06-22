using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ButtonEventListener : BaseEventListener
    {
        private void OnEnable()
        {
            Button button = GetComponent<Button>();
            if (button != null)
            {
                button.onClick.RemoveListener(OnClick);
                button.onClick.AddListener(OnClick);
            }
        }

        static public BaseEventListener Get(Button go)
        {
            if (go == null)
            {
                Debug.LogError("Can not create event source: Button is null!");
                return null;
            }

            BaseEventListener listener = go.GetComponent<BaseEventListener>();
            if (listener == null) listener = go.gameObject.AddComponent<ButtonEventListener>();
            return listener;
        }
    }
}
