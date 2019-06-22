using System.Collections.Generic;
using Assets.Scripts.Configuration;

namespace Assets.Scripts.Core
{
    public class MolecularModelFactory
    {
        private MolecularModelConfiguration _configuration;
        private float _temperature;
        public void SetConfiguration(MolecularModelConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
        }

        public MolecularModel Build()
        {
            var model = new MolecularModel();
            model.DesiredVelocity = _configuration.MinMoleculesSpeed + _temperature * (_configuration.MaxMoleculesSpeed - _configuration.MinMoleculesSpeed);
            var totalMoleculesCount = _configuration.MinMoleculesCount +
                                      (_configuration.MaxMoleculesCount - _configuration.MinMoleculesCount) *
                                      (1.0f - _temperature);
            model.Population = new Dictionary<SupportedMolecules, int>();
            for (int i = 0; i < _configuration.GasConsistence.Count; i++)
            {
                var molecule = _configuration.GasConsistence[i];
                model.Population[molecule.Type] = (int)(totalMoleculesCount * molecule.Rate);
            }

            return model;
        }
    }
}