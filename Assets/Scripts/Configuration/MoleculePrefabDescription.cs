using System;
using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Configuration
{
    [Serializable]
    public class MoleculePrefabDescription
    {
        [SerializeField] public SupportedMolecules Type;
        [SerializeField] public GameObject Prefab;
    }
}