using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour, IUnit {

    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }
    public string Name { get; set; } 
    public int MoveRange { get; }
    public int JumpRane { get; }
    public Vector3Int Index { get; set; }
    private IMoveAbility moveAbility;


    public void attack(BaseUnit unit) {
        unit.takeDamage(1);
    }

    public void takeDamage(int damage) {
        int result = this.CurrentHP - damage;
        if (result < 0) {
            this.CurrentHP = 0;
            this.KO();
        }
        else {
            this.CurrentHP = result;
        }
    }

    private void KO() {

    }

    public void move(ITile tile) {
        //if (canMoveTo(tile)) {
        //    moveTo(tile);
        //}
    }

    //protected bool canMoveTo(ITile tile) {
    //    if (this.moveAbility.canExecute(this.Location, tile.Index, this.MoveRange)) {
    //        return true;
    //    }

    //    return false;
    //}

    //protected void moveTo(ITile tile) {
    //    this.moveAbility.execute(this.transform, tile.Index);
    //    this.Location = tile.Index;
    //}

    public bool canPassThrough( ITile tile ) {
        return false;
    }

    public bool canEndTurnOn( ITile tile ) {
        return false;
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
