using UnityEngine;
using System.Collections;

public abstract class BaseAbility : MonoBehaviour, IAbility {
    public abstract bool canExecute();
    public abstract void execute();
}