using System;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Configuration
{
    [Serializable]
    public class MoleculeDescription
    {
        public SupportedMolecules Type;
        [Range(0.0f, 1.0f)]
        public float Rate;
    }
}