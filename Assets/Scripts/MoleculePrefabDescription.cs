using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class MoleculePrefabDescription
    {
        [SerializeField] public SupportedMolecules Type;
        [SerializeField] public GameObject Prefab;
    }
}