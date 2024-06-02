using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllUnits),
                   menuName = "Scriptables/" + nameof(ListOfAllUnits))]
    public class ListOfAllUnits : ScriptableObject
    {
        public List<Characters.CharacterInfo> moveableObjects;
        public List<EnemyInfo> enemyObjects;

        public void Initialize(EnemyInfo[] enemy, Characters.CharacterInfo[] character)
        {
            moveableObjects = new List<Characters.CharacterInfo>(character);
            enemyObjects = new List<EnemyInfo>(enemy);
        }

        public void Clear()
        {
            moveableObjects = null;
            enemyObjects = null;
        }
    }
}