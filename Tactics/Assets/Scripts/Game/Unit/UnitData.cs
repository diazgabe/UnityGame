using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UnitData : IUnitData {

    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string SuperName { get; set; }

    public string Backstory { get; set; }

    public UnitData() {

    }

    public static UnitData generateUnit() {
        UnitData unit = new UnitData();

        return unit;
    }
	
}
