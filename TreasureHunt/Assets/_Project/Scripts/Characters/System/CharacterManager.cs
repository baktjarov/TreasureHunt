using System.Collections.Generic;
using SO;
using UnityEngine;
using Zenject;

namespace Characters
{
    public class CharacterManager : MonoBehaviour
    {
        /*[Inject] public ListOfAllUnits listOfAllUnits;

        [field: SerializeField] public WarriorPooling warriorPooling { get; private set; }
        [field: SerializeField] public TorchGoblinPooling torchGoblinPooling { get; private set; }

        private List<CharacterInfo> characters;
        private List<EnemyInfo> enemies;

        private CharacterInfo[] warriorObjects;
        private EnemyInfo[] goblinObjects;

        private void Awake()
        {
            SetCharactersList();
        }

        private void OnDisable()
        {
            ResetCharactersList();
        }

        private void SetCharactersList()
        {
            warriorObjects = warriorPooling.GetList(2);
            goblinObjects = torchGoblinPooling.GetList(2);

            characters = new List<CharacterInfo>();
            enemies = new List<EnemyInfo>();

            foreach (var warriorObject in warriorObjects)
            {
                if (warriorObject != null)
                {
                    var character = warriorObject.GetComponent<CharacterInfo>();
                    if (character != null)
                    {
                        characters.Add(character);
                        warriorPooling.Put(character);
                    }
                }
            }

            foreach (var goblinObject in goblinObjects)
            {
                if (goblinObject != null)
                {
                    var enemy = goblinObject.GetComponent<EnemyInfo>();
                    if (enemy != null)
                    {
                        enemies.Add(enemy);
                        torchGoblinPooling.Put(enemy);
                    }
                }
            }

            listOfAllUnits.Initialize(enemies.ToArray(), characters.ToArray());
        }

        private void ResetCharactersList()
        {

        }*/
    }
}