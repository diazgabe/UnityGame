using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : IStateMachine {

    private List<IState> States;
    private IState State;

    private void attemptTransitionTo(IState state) {

    }

}