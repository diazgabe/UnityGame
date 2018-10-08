using UnityEngine;
using System.Collections;

public class Walk : BaseMoveAbility {
    private int jumpRange;

    public Walk( BaseUnit user, int range, int jumpRange ) : base( user, range ) {
        this.jumpRange = jumpRange;
    }

    public bool canExecute( BaseTile targetDestination ) {
        if ( !base.canExecute( targetDestination ) ) {
            return false;
        }

        // getPathFromAToB
        // if path !exist, return false
        // return true;
        throw new System.NotImplementedException();
    }

    public override void execute( BaseTile targetDestination ) {
        if ( !this.canExecute( targetDestination ) ) {
            return;
        }
        throw new System.NotImplementedException();
        //StartCoroutine( animateMove( transform, destination ) );
    }

    //private IEnumerator animateMove( Transform transform, Vector3 destination ) {
    //    float step = this._moveSpeed * Time.deltaTime;
    //    while ( transform.position != destination ) {
    //        transform.position = Vector3.MoveTowards( transform.position, destination, step );
    //        yield return null;
    //    }
    //}
}