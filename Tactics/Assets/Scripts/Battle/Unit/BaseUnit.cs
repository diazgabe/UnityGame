//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class BaseUnit : MonoBehaviour, IUnit {

//    public int CurrentHP { get; set; }
//    public int MaxHP { get; set; }
//    public string Name { get; set; }
//    public int MoveRange { get; }
//    public Vector3Int Location { get; set; }
//    private IMoveAbility moveAbility;

//    public void move(ITile tile) {
//        if (canMoveTo(tile)) {
//            moveTo(tile);
//        }
//    }

//    public void attack(BaseUnit unit) {
//        unit.takeDamage(1);   
//    }

//    public void takeDamage(int damage) {
//        int result = this.CurrentHP - damage;
//        if(result < 0){
//            this.CurrentHP = 0;
//            this.KO();
//        } 
//        else {
//            this.CurrentHP = result;
//        }
//    }

//    private void KO() {
        
//    }

//    protected bool canMoveTo(ITile tile) {
//        if (this.moveAbility.canExecute(this.Location, tile.Location, this.MoveRange)) {
//            return true;
//        }

//        return false;
//    }

//    protected void moveTo(ITile tile) {
//        this.moveAbility.execute(this.transform, tile.Location);
//        this.Location = tile.Location;
//    }

//    // Use this for initialization
//    void Start() {

//    }

//    // Update is called once per frame
//    void Update() {

//    }
//}
