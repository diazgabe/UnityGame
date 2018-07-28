using UnityEngine;
using System.Collections;

public class Teleport : BaseMoveAbility {

    //public bool canExecute( ITile from, ITile to, int moveRange ) {
    //    Vector3Int delta = Vector3.Distance(to.Location - from.Location);
    //    int distance = delta.x + delta.z;
    //    if ( distance > moveRange ) {
    //        return false;
    //    }

    //    return true;
    //}

    public override bool canEndTurnOn( ITile tile ) {
        return true;
    }

    public override bool canPassThrough( ITile tile ) {
        return true;
    }

    public void execute( Transform transform, Vector3 destination ) {
        //StartCoroutine( animateMove( transform, destination ) );
    }

    //private IEnumerator animateMove( Transform transform, Vector3 destination ) {
    //    transform.GetComponent<Animation>().Play();
    //}
}