using System.Collections.Generic;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllWarriors),
                   menuName = "Scriptables/" + nameof(ListOfAllWarriors))]
    public class ListOfAllWarriors : ScriptableObject
    {
        public List<Characters.CharacterInfo> moveableObjects;

        public void Initialize(Characters.CharacterInfo[] characters)
        {
            moveableObjects = new List<Characters.CharacterInfo>(characters);
        }
    }
}
