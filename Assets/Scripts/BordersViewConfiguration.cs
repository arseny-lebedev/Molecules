using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Borders View Configuration", menuName = @"Scriptable Object/ Borders View Configuration")]
    public class BordersViewConfiguration:ScriptableObject
    {
        public Color Cold;
        public Color Hot;
    }
}