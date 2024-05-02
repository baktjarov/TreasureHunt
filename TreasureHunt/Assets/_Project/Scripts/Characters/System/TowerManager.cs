using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class TowerManager : MonoBehaviour
    {
        [Inject] public ListOfAllTowers listOfAllTowers;

        private void Awake()
        {
            TowerInfo[] towers = FindObjectsOfType<TowerInfo>();
            listOfAllTowers.Initialize(towers);
        }
    }
}