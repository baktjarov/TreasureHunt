using SO;
using TagComponents;
using Zenject;

namespace StateMachine
{
    public class CharacterStateMachineBase : UnitStateMachineBase
    {
        [Inject] public WarriorPooling warriorPooling;

        public override void OnSensorEnter(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag && _currentVisibleEnemies.Contains(tag) == false) { _currentVisibleEnemies.Add(tag); }
        }

        public override void OnSensorExit(TagComponentBase tag)
        {
            if (tag is IShootableEnemy_Tag) { _currentVisibleEnemies.Remove(tag); }
        }

        public override void TurnDie()
        {
            var character = GetComponent<Characters.CharacterInfo>();
            warriorPooling.Put(character);
        }
    }
}