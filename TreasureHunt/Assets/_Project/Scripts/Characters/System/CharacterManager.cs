using System.Collections.Generic;
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
            SetCharactersList();
        }

        private void SetCharactersList()
        {
            var warriorObjects = _warriorPooling.GetList(4);
            var goblinObjects = _torchGoblinPooling.GetList(4);

            List<CharacterInfo> characters = new List<CharacterInfo>();
            List<EnemyInfo> enemies = new List<EnemyInfo>();

            foreach (var warriorObject in warriorObjects)
            {
                var character = warriorObject.GetComponent<CharacterInfo>();
                if (character != null)
                {
                    characters.Add(character);
                }
            }

            foreach (var goblinObject in goblinObjects)
            {
                var goblinEnemy = goblinObject.GetComponent<EnemyInfo>();
                if (goblinEnemy != null)
                {
                    enemies.Add(goblinEnemy);
                }
            }

            listOfAllWarriors.Initialize(characters.ToArray(), enemies.ToArray());
        }

    }
}
