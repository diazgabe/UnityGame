using UnityEngine;

public class Teleport : BaseMoveAbility {

    public Teleport(BaseUnit user, int range) : base(user, range) { }

    public override bool canExecute( BaseTile targetDestination ) {
        if ( !base.canExecute( targetDestination ) ) {
            return false;
        }

        if ( Utilities.getHorizontalDistanceBetweenIndexes( targetDestination.Index, this.user.Index ) > this.range ) {
            return false;
        }
        return true;
    }

    public override void execute( BaseTile targetDestination ) {
        if ( !this.canExecute( targetDestination ) ) {
            return;
        }
        user.GetComponent<MeshRenderer>().enabled = false;
        user.transform.position = targetDestination.transform.position;
        user.GetComponent<MeshRenderer>().enabled = true;
    }

    //StartCoroutine( animateMove( transform, destination ) );
    //private IEnumerator animateMove( Transform transform, Vector3 destination ) {
    //    transform.GetComponent<Animation>().Play();
    //}
}