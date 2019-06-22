using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public class Simulation : MonoBehaviour
    {
        private float _desiredVelocity = 1.0f;
        private MolecularModel _model;
        private MoleculesPool _moleculesPool;
        private readonly Dictionary<SupportedMolecules, List<GameObject>> _molecules = new Dictionary<SupportedMolecules, List<GameObject>>();
        private List<Rigidbody> _bodies = new List<Rigidbody>();

        public void Activate()
        {
            for (int i = 0; i < 10; i++)
            {
                var type = i < 8 ? SupportedMolecules.N2 : SupportedMolecules.O2;
                AddMolecule(type);
            }
        }

        void FillInBodies()
        {
            _bodies = new List<Rigidbody>();
            foreach (var typo in _molecules)
            {
                foreach (var vp in typo.Value)
                    _bodies.Add(vp.GetComponent<Rigidbody>());
            }
        }

        void FixedUpdate()
        {
            for (int i = 0; i < _bodies.Count; i++)
            {
                SetDesiredSpeed(_bodies[i]);
            }
        }

        void SetDesiredSpeed(Rigidbody body)
        {
            // при желании можно сделать итеративное изменение скорости
            body.velocity = body.velocity.normalized * _desiredVelocity;
        }

        void Update()
        {
            CheckModel();
        }

        private void CheckModel()
        {
            foreach (var typo in _molecules)
            {
                if (typo.Value.Count == _model.Population[typo.Key])
                    continue;
                SetNewMoleculesCount(typo.Key, _model.Population[typo.Key]);
            }
        }

        private void SetNewMoleculesCount(SupportedMolecules typoKey, int newCount)
        {
            while (_molecules[typoKey].Count != newCount)
            {
                if (_molecules[typoKey].Count > newCount)
                    RemoveMolecule(typoKey);
                else
                    AddMolecule(typoKey);
            }
        }

        private void AddMolecule(SupportedMolecules type)
        {
            GameObject currentMolecule = _moleculesPool.Build(type);
            Rigidbody rb = currentMolecule.GetComponent<Rigidbody>();
            rb.velocity = Random.onUnitSphere * _desiredVelocity;
            if (!_molecules.ContainsKey(type)) _molecules.Add(type, new List<GameObject>());
            _molecules[type].Add(currentMolecule);
            FillInBodies();
        }

        private void RemoveMolecule(SupportedMolecules type)
        {
            var go = _molecules[type][0];
            _molecules[type].Remove(go);
            go.SetActive(false);
            Destroy(go);
            FillInBodies();
        }

        public void ModelChanged(MolecularModel model)
        {
            _desiredVelocity = model.DesiredVelocity;
            _model = model;
        }

        public void SetConfiguration(MoleculesPool moleculesPool)
        {
            _moleculesPool = moleculesPool;
        }
    }
}
