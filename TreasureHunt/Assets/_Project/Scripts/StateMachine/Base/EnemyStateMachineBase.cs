using Characters;
using SO;
using TagComponents;
using Zenject;

namespace StateMachine
{
    public class EnemyStateMachineBase : UnitStateMachineBase
    {
        [Inject] public TorchGoblinPooling torchGoblinPooling;

        public override void OnSensorEnter(TagComponentBase tag)
        {
            if (tag is IShootableCharacter_Tag || tag is IShootableTower_Tag && _currentVisibleEnemies.Contains(tag) == false) { _currentVisibleEnemies.Add(tag); }
        }

        public override void OnSensorExit(TagComponentBase tag)
        {
            if (tag is IShootableCharacter_Tag || tag is IShootableTower_Tag) { _currentVisibleEnemies.Remove(tag); }
        }

        public override void TurnDie()
        {
            var enemy = GetComponent<EnemyInfo>();
            torchGoblinPooling.Put(enemy);
        }
    }
}