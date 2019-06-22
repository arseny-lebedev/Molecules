﻿using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Molecules Pool Configuration", menuName = @"Scriptable Object/ Molecules Pool Configuration")]
    public class MoleculesPoolConfiguration : ScriptableObject
    {
        public List<MoleculePrefabDescription> MoleculesPool;
    }
}