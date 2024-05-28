using System;
using UnityEngine;

namespace DataClasses
{
    [Serializable]
    public class GameLevel
    {
        [field: SerializeField] public string sceneName { get; private set; }
        [field: SerializeField] public string levelNumber { get; private set; }
    }
}