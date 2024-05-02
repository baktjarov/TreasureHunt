using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllTowers),
                   menuName = "Scriptables/" + nameof(ListOfAllTowers))]
    public class ListOfAllTowers : ScriptableObject
    {
        public List<TowerInfo> towerObjects;

        public void Initialize(TowerInfo[] tower)
        {
            towerObjects = new List<TowerInfo>(tower);
        }
    }
}