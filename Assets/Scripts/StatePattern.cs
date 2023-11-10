using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePattern : MonoBehaviour
{
    public enum MonsterState
    {
        Aggro,
        Attacking,
        Die,
        Idle
    }

    MonsterState _state = MonsterState.Idle;

    void UpdateAggro() { }
    void UpdateAttacking() { }
    void UpdateDie() { }
    void UpdateIdle() { }
    void Update()
    {
        switch (_state)
        {
            case MonsterState.Aggro:
                UpdateAggro(); break;
            case MonsterState.Attacking:
                UpdateAttacking(); break;
            case MonsterState.Die:
                UpdateDie(); break;
            case MonsterState.Idle:
                UpdateIdle(); break;
        }
    }
}
