using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectileAbility : MonoBehaviour {

    private List<BaseEffect> Effects { get; }

    public void addEffect(BaseEffect effect) {
        Effects.Add( effect );
    }

    public void removeEffect( BaseEffect effect ) {
        Effects.Remove( effect );
    }

    public void removeAllEffects() {
        Effects.Clear();
    }
}
