using Characters;
using TagComponents;

namespace StateMachine
{
    public class EnemyStateMachineBase : UnitStateMachineBase
    {
        public override void OnSensorEnter(TagComponentBase tag)
        {
            if (tag is IShootableCharacter_Tag && _currentVisibleEnemies.Contains(tag) == false) { _currentVisibleEnemies.Add(tag); }
        }

        public override void OnSensorExit(TagComponentBase tag)
        {
            if (tag is IShootableCharacter_Tag) { _currentVisibleEnemies.Remove(tag); }
        }

        public override void TurnDie()
        {
            var enemy = GetComponent<EnemyInfo>();
            _characterManager.torchGoblinPooling.Put(enemy);
        }
    }
}