using System;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class StartPanelView : MonoBehaviour
    {
        public event Action OnStartButtonClick;
        [SerializeField]
        private Button butPlay;

        void OnEnable()
        {

            ButtonEventListener.Get(butPlay).onClick += playClick;
        }

        void OnDisable()
        {
            ButtonEventListener.Get(butPlay).onClick -= playClick;
        }

        void playClick(GameObject sender)
        {
            if (OnStartButtonClick != null)
            {
                OnStartButtonClick();
            }

            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
