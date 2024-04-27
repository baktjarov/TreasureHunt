using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [Inject] public ListOfAllCharacters listOfAllWarriors { get; private set; }

        [Header("Components")]
        [SerializeField] private WarriorPooling _warriorPooling;
        [SerializeField] private TorchGoblinPooling _torchGoblinPooling;

        private void Awake()
        {
            PoolCharacters();
        }

        private void PoolCharacters()
        {
            var warrior = _warriorPooling.Get();
            warrior.Inititlize(_warriorPooling);

            var enemy = _torchGoblinPooling.Get();
            enemy.Inititlize(_torchGoblinPooling);
        }

        private void SetCharactersList()
        {
            var characters = FindObjectsOfType<CharacterInfo>();
            var enemies = FindObjectsOfType<EnemyInfo>();

            listOfAllWarriors.Initialize(characters, enemies);
        }
    }
}
