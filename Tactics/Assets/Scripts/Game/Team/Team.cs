using System.Collections;
using System.Collections.Generic;

public class Team {

    public string teamName { get; set; }
    public string description { get; }

    List<IUnit> members { get; }

    public Team() {
        members = new List<IUnit>();
    }

    private void addMember( IUnit unit ) {
        members.Add(unit);
    }

    private void removeMember( IUnit unit ) {
        members.Remove(unit);
    }
}
