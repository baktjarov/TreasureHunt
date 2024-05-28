using System.Collections.Generic;
using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        [Inject] public ListOfAllUnits listOfAllUnits;

        [field: SerializeField] public WarriorPooling warriorPooling { get; private set; }
        [field: SerializeField] public TorchGoblinPooling torchGoblinPooling { get; private set; }

        private List<CharacterInfo> characters;
        private List<EnemyInfo> enemies;

        private void Awake()
        {
            SetCharactersList();
        }

        private void OnDestroy()
        {
            ResetCharacterList();
        }

        private void SetCharactersList()
        {
            var warriorObjects = warriorPooling.GetList(4);
            var goblinObjects = torchGoblinPooling.GetList(4);

            List<CharacterInfo> characters = new List<CharacterInfo>();
            List<EnemyInfo> enemies = new List<EnemyInfo>();

            foreach (var warriorObject in warriorObjects)
            {
                var character = warriorObject.GetComponent<CharacterInfo>();
                if (character != null)
                {
                    characters.Add(character);
                    warriorPooling.Put(character);
                }
            }

            foreach (var goblinObject in goblinObjects)
            {
                var enemy = goblinObject.GetComponent<EnemyInfo>();
                if (enemy != null)
                {
                    enemies.Add(enemy);
                    torchGoblinPooling.Put(enemy);
                }
            }

            listOfAllUnits.Initialize(enemies.ToArray(), characters.ToArray());
        }

        private void ResetCharacterList()
        {
            var warriorObjects = warriorPooling.GetList(4);
            var goblinObjects = torchGoblinPooling.GetList(4);

            foreach (var warriorObject in warriorObjects)
            {
                var character = warriorObject.GetComponent<CharacterInfo>();
                warriorPooling.Put(character);
            }

            foreach (var goblinObject in goblinObjects)
            {
                var enemy = goblinObject.GetComponent<EnemyInfo>();
                torchGoblinPooling.Put(enemy);
            }

            if (enemies != null || characters != null)
            {
                enemies.Clear();
                characters.Clear();
            }
        }
    }
}