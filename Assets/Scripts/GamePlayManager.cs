using Assets.Scripts.Configuration;
using Assets.Scripts.Core;
using Assets.Scripts.View;
using UnityEngine;

namespace Assets.Scripts
{
    public class GamePlayManager : MonoBehaviour
    {
        [SerializeField]
        private Simulation _simulation;
        [SerializeField]
        private BordersView _bordersView;
        [SerializeField]
        private BordersViewConfiguration _bordersViewConfiguration;
        [SerializeField]
        private MolecularModelConfiguration _molecularModelConfiguration;
        [SerializeField]
        private MoleculesPoolConfiguration _moleculesPoolConfiguration;
        [SerializeField]
        private Transform _moleculesParrent;
        private MolecularModelFactory _molecularModelFactory;
        private MoleculesPool _moleculesPool;

        public void Initialize()
        {
            _molecularModelFactory = new MolecularModelFactory();
            _molecularModelFactory.SetConfiguration(_molecularModelConfiguration);
            _bordersView.SetConfigurations(_bordersViewConfiguration);
            _moleculesPool = gameObject.AddComponent<MoleculesPool>();
            _moleculesPool.SetConfiguration(_moleculesPoolConfiguration, _moleculesParrent);
            _simulation.SetConfiguration(_moleculesPool);
            _simulation.Activate();
        }

        public void SetTemperature(float f)
        {
            _molecularModelFactory.SetTemperature(f);
            _bordersView.SetTemperature(f);
            _simulation.ModelChanged(_molecularModelFactory.Build());
        }
    }
}