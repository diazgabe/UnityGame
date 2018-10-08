public class Omnimove : BaseMoveAbility {

    public Omnimove( BaseUnit user, int range ) : base( user, range ) { }

    public override bool canExecute( BaseTile targetDestination ) {
        if ( !base.canExecute( targetDestination ) ) {
            return false;
        }

        return true;
    }

    public override void execute( BaseTile targetDestination ) {
        if (!this.canExecute(targetDestination)) {
            return;
        }
        user.transform.position = targetDestination.transform.position;
    }
}
