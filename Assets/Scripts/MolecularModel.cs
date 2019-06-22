using System.Collections.Generic;

namespace Assets.Scripts
{
    public class MolecularModel
    {
        public float DesiredVelocity { get; set; }
        public Dictionary<SupportedMolecules,int> Population { get; set; }
    }
}