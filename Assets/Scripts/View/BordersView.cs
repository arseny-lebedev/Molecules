using Assets.Scripts.Configuration;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class BordersView : MonoBehaviour
    {
        [SerializeField] private Renderer _heatingPlaneRenderer;

        private BordersViewConfiguration _configuration;

        public void SetConfigurations(BordersViewConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SetTemperature(float temperature)
        {
            _heatingPlaneRenderer.material.color = InterpolateColor(_configuration.Cold, _configuration.Hot, temperature);
        }

        Color InterpolateColor(Color colorA, Color colorB, float time)
        {
            return new Color(Mathf.Lerp(colorA.r, colorB.r, time),
                Mathf.Lerp(colorA.g, colorB.g, time),
                Mathf.Lerp(colorA.b, colorB.b, time),
                Mathf.Lerp(colorA.a, colorB.a, time));
        }
    }
}