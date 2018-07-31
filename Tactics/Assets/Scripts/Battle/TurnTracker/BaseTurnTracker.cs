using System.Collections.Generic;
using UnityEngine;

public class BaseTurnTracker : ITurnTracker {

    private Queue<Turn> turnOrder { get; }

    private int roundCount;
    private int turnCount;

    public BaseTurnTracker() {
        roundCount = 0;
        turnCount = 0;
    }

    public Turn advanceTurn(int i = 1) {
        Turn turn = turnOrder.Dequeue();
        turnCount += i;
        turnOrder.Enqueue(turn);
        return turn;
    }

    public void advanceRound(int i = 1) {
        roundCount += i;
    }
}