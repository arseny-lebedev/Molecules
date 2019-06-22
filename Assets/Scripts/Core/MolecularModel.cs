using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    public class MolecularModel
    {
        public float DesiredVelocity { get; set; }
        public Dictionary<SupportedMolecules,int> Population { get; set; }
    }
}