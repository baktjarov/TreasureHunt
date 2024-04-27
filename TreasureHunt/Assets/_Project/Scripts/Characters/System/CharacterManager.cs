using System.Collections.Generic;
using SO;
using UnityEngine;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [SerializeField] private ListOfAllUnits listOfAllUnits;

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
                    _warriorPooling.Put(character);
                }
            }

            foreach (var goblinObject in goblinObjects)
            {
                var enemy = goblinObject.GetComponent<EnemyInfo>();
                if (enemy != null)
                {
                    enemies.Add(enemy);
                    _torchGoblinPooling.Put(enemy);
                }
            }

            listOfAllUnits.Initialize(enemies.ToArray(), characters.ToArray());
        }
    }
}
