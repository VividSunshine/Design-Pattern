using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FSMPattern : MonoBehaviour
{ 
    //열거형으로 단순한 FSM / 상태 패턴 구현
    private enum State
    {
        Idle,
        Move,
        Attack
    }
    private State _state;

    private void Start()
    {
        _state = State.Idle;
    }

    private void Update()
    {
        switch(_state)
        {
            case State.Idle:
                break;
            case State.Move:
                break;
            case State.Attack:
                break;
        }
    }
}

public abstract class BaseState
 //각 상태를 구현하기 위한 필수적인 내용을 미리 정의하는 추상 클래스 정의
{
    protected FSMPattern _monster;

    protected BaseState(FSMPattern monster)
    {
        _monster = monster;
    }

    public abstract void OnStateEnter();    //상태에 처음 진입했을 때 한 번만 호출되는 메서드
    public abstract void OnStateUpdate();   //매 프레임마다 호출되어야 하는 메서드
    public abstract void OnStateExit();     //상태가 변경될 때 호출되는 메서드
}

//각 몬스터 AI가 지닐 수 있는 각 상태들은 BaseState를 상속받은 각각의 클래스로 구현한다.
public class IdleState : BaseState
{
    public IdleState(FSMPattern monster) : base(monster) { }
    public override void OnStateEnter()
    {
        Debug.Log("Idle");
    }
    public override void OnStateUpdate() { }
    public override void OnStateExit() { }
}

public class MoveState : BaseState
{
    public MoveState(FSMPattern monster) : base(monster) { }
    public override void OnStateEnter()
    {
        Debug.Log("Move");
    }
    public override void OnStateUpdate() { }
    public override void OnStateExit() { }
}

public class AttackState : BaseState
{
    public AttackState(FSMPattern monster) : base(monster) { }
    public override void OnStateEnter()
    {
        Debug.Log("Attack");
    }
    public override void OnStateUpdate() { }
    public override void OnStateExit() { }
}

public class FSM
{
    public FSM(BaseState initState)
    {
        _curState = initState;
        ChangeState(_curState);
    }

    private BaseState _curState;

    public void ChangeState(BaseState nextState)
    {
        if (nextState == _curState)
            return;
        //다음 상태가 현재 상태와 동일한지 확인한다.

        if (_curState != null)
            _curState.OnStateExit();
        //현재 상태가 있는 경우, 다음 상태로 전환하기 전 현재 상태를 종료한다.

        _curState = nextState;
        _curState.OnStateEnter();
        //현재 상태를 전환되는 상태로 설정하고 새 상태로 진입할 때 호출되는 메서드를 쓴다.
    }

    public void UpdateState()
    {
        if(_curState != null)
            _curState.OnStateUpdate();
        //현재 상태가 있는지 확인하고 상태를 계속 업데이트 한다.
    }
}