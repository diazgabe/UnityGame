using System.Collections.Generic;

[System.Serializable]
public class UnitData : IUnitData {

    public string superName { get; }
    private List<BaseAbility> _abilities;
    public IReadOnlyList<BaseAbility> abilities {
        get {
            return _abilities.AsReadOnly();
        }
    }

    public UnitData() {
        _abilities = new List<BaseAbility>();
    }

    public void addAbility(BaseAbility ability) {
        this._abilities.Add(ability);
    }

    public void removeAbility( BaseAbility ability ) {
        this._abilities.Remove( ability );
    }

    public static UnitData generateUnit() {
        UnitData unit = new UnitData();

        return unit;
    }
	
}
