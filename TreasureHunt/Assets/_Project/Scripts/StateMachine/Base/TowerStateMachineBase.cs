using Characters;
using UnityEngine;

namespace StateMachine
{
    public abstract class TowerStateMachineBase : StateMachineBase
    {
        [Header("Components")]
        [SerializeField] public TowerInfo _towerInfo;
    }
}