using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [Inject] public ListOfAllWarriors listOfAllWarriors { get; private set; }
        
        private void Awake()
        {
            var characters = FindObjectsOfType<CharacterInfo>();
            listOfAllWarriors.Initialize(characters);
        }
    }
}
