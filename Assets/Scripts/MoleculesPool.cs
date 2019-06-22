using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoleculesPool:MonoBehaviour
    {
        private MoleculesPoolConfiguration _moleculesPoolConfiguration;
        private Dictionary<SupportedMolecules, GameObject> _moleculesPrefabs;
        private Transform _parent;
        public void SetConfiguration(MoleculesPoolConfiguration moleculesPoolConfiguration, Transform parent)
        {
            _moleculesPoolConfiguration = moleculesPoolConfiguration;
            _parent = parent;
            _moleculesPrefabs= new Dictionary<SupportedMolecules, GameObject>();
            foreach (var item in _moleculesPoolConfiguration.MoleculesPool)
            {
                _moleculesPrefabs[item.Type] = item.Prefab;
            }
        }

        public GameObject Build(SupportedMolecules type)
        {
            return Instantiate(_moleculesPrefabs[type], _parent);
        }
    }
}