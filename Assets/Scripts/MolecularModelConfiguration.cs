using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Molecular Model Configuration", menuName = @"Scriptable Object/ Molecular Model Configuration")]
    public class MolecularModelConfiguration:ScriptableObject
    {
        public int MinMoleculesCount;
        public int MaxMoleculesCount;
        public float MinMoleculesSpeed;
        public float MaxMoleculesSpeed;

        public List<MoleculeDescription> GasConsistence;
    }
}