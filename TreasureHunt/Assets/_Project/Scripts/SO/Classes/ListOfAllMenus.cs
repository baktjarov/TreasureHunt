using System.Linq;
using UI;
using UnityEngine;

namespace SO
{
    [CreateAssetMenu(fileName = nameof(ListOfAllMenus), menuName = "Scriptables/" + nameof(ListOfAllMenus))]
    public class ListOfAllMenus : ScriptableObject
    {
        [field: SerializeField] public MenuBase[] menus { get; private set; }

        public T GetMenu<T>() where T : MenuBase
        {
            return (T)menus.First(x => x.GetType() == typeof(T));
        }
    }
}