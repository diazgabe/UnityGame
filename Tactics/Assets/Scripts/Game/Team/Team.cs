using System.Collections.Generic;

[System.Serializable]
public class Team {

    private List<BaseUnit> members;

    public Team() {
        members = new List<BaseUnit>();
    }

    private void addMember( BaseUnit unit ) {
        members.Add(unit);
    }

    private void removeMember( BaseUnit unit ) {
        members.Remove(unit);
    }
}