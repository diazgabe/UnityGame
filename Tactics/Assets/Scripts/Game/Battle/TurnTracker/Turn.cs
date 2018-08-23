using System.Collections.Generic;

public class Turn {
    public List<Player> players { get; }

    public Turn (List<Player> players) {
        this.players = players;
    }

    public Turn( Player player ) {
        this.players = new List<Player>();
        this.players.Add( player );
    }
}