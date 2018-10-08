using UnityEngine;

public static class Utilities {

    public static int getHorizontalDistanceBetweenIndexes(Vector3Int v1, Vector3Int v2) {
        Vector3Int v = v1 - v2;
        return Mathf.Abs( v.x ) + Mathf.Abs( v.z );
    }

    public static int getDistanceBetweenIndexes( Vector3Int v1, Vector3Int v2 ) {
        Vector3Int v = v1 - v2;
        return Mathf.Abs( v.x ) + Mathf.Abs( v.y ) + Mathf.Abs( v.z );
    }

}