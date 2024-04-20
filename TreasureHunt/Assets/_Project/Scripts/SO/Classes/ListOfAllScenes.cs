using DataClasses;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllScenes), menuName = "Scriptables/" + nameof(ListOfAllScenes))]
    public class ListOfAllScenes : ScriptableObject
    {
        [field: SerializeField] public GameLevel[] gameLevels { get; private set; }
        [field: SerializeField] public GameLevel mainMenuScene { get; private set; }
    }
}