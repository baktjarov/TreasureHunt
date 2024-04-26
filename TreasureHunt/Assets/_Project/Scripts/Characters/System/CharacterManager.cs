using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [Inject] public ListOfAllCharacters listOfAllWarriors { get; private set; }
        
        private void Awake()
        {
            var characters = FindObjectsOfType<CharacterInfo>();
            var enemies = FindObjectsOfType<EnemyInfo>();

            listOfAllWarriors.Initialize(characters, enemies);
        }
    }
}
