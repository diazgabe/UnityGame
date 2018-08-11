using UnityEngine;
using System.Collections;

public interface IAbility {
    bool canExecute();
    void execute();
}