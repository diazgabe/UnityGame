using System.Collections.Generic;

public abstract class BaseAbility {

    // Let's only worry about aftereffects for right now.
    protected List<BaseEffect> Effects { get; }

    public void addEffect( BaseEffect effect ) {
        Effects.Add( effect );
    }

    public void removeEffect( BaseEffect effect ) {
        Effects.Remove( effect );
    }

    public void removeAllEffects() {
        Effects.Clear();
    }

    //public abstract void execute();

}