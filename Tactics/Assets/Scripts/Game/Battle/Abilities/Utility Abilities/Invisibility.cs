using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility: BaseAbility {
    BaseUnit owner;

    public void execute() {
        owner.IsVisible = false;
    }
}
