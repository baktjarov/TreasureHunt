using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllCharacters),
                   menuName = "Scriptables/" + nameof(ListOfAllCharacters))]
    public class ListOfAllCharacters : ScriptableObject
    {
        public List<Characters.CharacterInfo> moveableObjects;
        public List<EnemyInfo> enemiesList;

        public void Initialize(Characters.CharacterInfo[] characters, EnemyInfo[] enemies)
        {
            moveableObjects = new List<Characters.CharacterInfo>(characters);
            enemiesList = new List<EnemyInfo>(enemies);
        }
    }
}
