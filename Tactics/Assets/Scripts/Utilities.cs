using UnityEngine;
using System.Collections;

public static class Utilities {
    public static Vector3Int vector3Abs(Vector3Int v) {
        return new Vector3Int(Mathf.Abs(v.x), Mathf.Abs(v.y), Mathf.Abs(v.z));
    }
}