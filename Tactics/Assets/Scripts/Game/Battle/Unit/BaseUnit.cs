using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour, IUnit {

    public Player Owner { get; }
    
    public int CurrentHP { get; set; }
    public int MaxHP { get; set; }
    public string Name { get; set; } 
    public int AttackRange { get; }
    public int AttackDamage { get; }
    public int MoveRange { get; }
    public int JumpRange { get; }
    public Vector3Int Index { get; set; }

    public bool IsVisible { get; set; }
    public bool isKOd { get; private set; }

    public void attack(BaseUnit unit) {
        unit.takeDamage(this.AttackDamage);
    }

    public int takeDamage( int damage ) {
        int damageTaken = 0;

        if ( damage >= this.CurrentHP ) {
            damageTaken = this.CurrentHP;
            this.CurrentHP = 0;
            this.KO();
        } else {
            damageTaken = damage;
            this.CurrentHP -= damage;
        }

        return damageTaken;
    }

    public void heal( int amount ) {
        int hp = CurrentHP + amount;
        CurrentHP = ( hp < this.MaxHP ) ? hp : MaxHP;
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
