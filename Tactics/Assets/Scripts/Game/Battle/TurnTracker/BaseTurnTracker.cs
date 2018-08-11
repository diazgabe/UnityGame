using System.Collections;
using System.Collections.Generic;

public class BaseTurnTracker : ITurnTracker {

    public Queue<Turn> turnOrder { get; }

    public int roundCount { get; private set; }
    public int turnCount { get; private set; }

    IComparer<IUnit> bySpeed_AllyFirst;

    public BaseTurnTracker(List<BaseUnit> units) {
        turnOrder = new Queue<Turn>();
        units.Sort(new TestComparer());
        units.ForEach(unit => {
            Turn turn = new Turn(unit.Owner, unit);
        });

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