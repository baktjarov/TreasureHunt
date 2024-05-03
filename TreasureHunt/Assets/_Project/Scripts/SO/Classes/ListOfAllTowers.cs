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
        public int _towersCount => towerObjects.Count;

        public void Initialize(TowerInfo[] tower)
        {
            towerObjects = new List<TowerInfo>(tower);
        }

        public TowerInfo GetTower(int index)
        {
            if(index >= towerObjects.Count)
            {
                index = 0;
            }
            if(index < 0)
            {
                index = 0;
            }

            return towerObjects[index];
        }
    }
}