using GameMaker.Core.Runtime;
using UnityEngine;

namespace Game.GamePlay
{
    public enum PlayerStateType
    {
        Idling,
        Running,
        Attack,
        Purification,
        Buff,
        Jump
    }
    public class PlayerStateMachine : BaseStateMachine<PlayerStateType>
    {
        
    }
}
