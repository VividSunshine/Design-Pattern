using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FSMPattern : MonoBehaviour
{ 
    //���������� �ܼ��� FSM / ���� ���� ����
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
 //�� ���¸� �����ϱ� ���� �ʼ����� ������ �̸� �����ϴ� �߻� Ŭ���� ����
{
    protected FSMPattern _monster;

    protected BaseState(FSMPattern monster)
    {
        _monster = monster;
    }

    public abstract void OnStateEnter();    //���¿� ó�� �������� �� �� ���� ȣ��Ǵ� �޼���
    public abstract void OnStateUpdate();   //�� �����Ӹ��� ȣ��Ǿ�� �ϴ� �޼���
    public abstract void OnStateExit();     //���°� ����� �� ȣ��Ǵ� �޼���
}

//�� ���� AI�� ���� �� �ִ� �� ���µ��� BaseState�� ��ӹ��� ������ Ŭ������ �����Ѵ�.
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
        //���� ���°� ���� ���¿� �������� Ȯ���Ѵ�.

        if (_curState != null)
            _curState.OnStateExit();
        //���� ���°� �ִ� ���, ���� ���·� ��ȯ�ϱ� �� ���� ���¸� �����Ѵ�.

        _curState = nextState;
        _curState.OnStateEnter();
        //���� ���¸� ��ȯ�Ǵ� ���·� �����ϰ� �� ���·� ������ �� ȣ��Ǵ� �޼��带 ����.
    }

    public void UpdateState()
    {
        if(_curState != null)
            _curState.OnStateUpdate();
        //���� ���°� �ִ��� Ȯ���ϰ� ���¸� ��� ������Ʈ �Ѵ�.
    }
}