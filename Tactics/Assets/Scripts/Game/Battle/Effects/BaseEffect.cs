using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEffect : MonoBehaviour {

    public abstract void execute(Vector3Int position);
}
