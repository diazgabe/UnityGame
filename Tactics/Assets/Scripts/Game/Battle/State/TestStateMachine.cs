using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestStateMachine: IStateMachine  {

    private enum States {
        Idle,
        AtackRequest,
        MoveRequest
    }

    private States _state;

    public TestStateMachine() {
        this._state = States.Idle;

        EventManager.addEventListener("Attack", transitionToAttack );
        EventManager.addEventListener("Move", transitionToMove);
    }

    void transitionTo(States state) {
        this._state = state;
        Debug.Log("New state: " + this._state);
    }

    void transitionToAttack() {
        transitionTo(States.AtackRequest);
    }

    void transitionToMove() {
        transitionTo(States.MoveRequest);
    }



}
