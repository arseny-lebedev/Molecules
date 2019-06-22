using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class MoleculeDescription
    {
        public SupportedMolecules Type;
        [Range(0.0f,1.0f)]
        public float Rate;
    }
}