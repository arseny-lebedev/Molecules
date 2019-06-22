using System;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class GameMenuView : MonoBehaviour
    {

        public event Action<float> OnTemperatureChanged;
        [SerializeField]
        private Slider temperature;

        public float Temperature { get; set; }

        void OnEnable()
        {
            var temperatureSlider = SliderEventListener.Get(temperature);
            temperatureSlider.onValueChanged += ValueChanged;
            Temperature = temperature.value;
        }

        void OnDisable()
        {
            SliderEventListener.Get(temperature).onValueChanged -= ValueChanged;
        }

        void ValueChanged(GameObject sender,float value)
        {
            if (OnTemperatureChanged != null)
            {
                OnTemperatureChanged(value);
            }

        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
