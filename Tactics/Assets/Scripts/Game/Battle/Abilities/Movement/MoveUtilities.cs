using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoveUtilities {

    public static bool IsInRangeOf( int range, Vector3Int a, Vector3Int b ) {
        int distance = HorizontalDistanceBetweenIndexes(a, b);
        if ( range >= distance ) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Returns the horizontal distance between two indexes.
    /// </summary>
    /// <param name="a"> The first index. </param>
    /// <param name="b"> The second index. </param>
    /// <returns> The horizontal distance between two indexes. </returns>
    public static int HorizontalDistanceBetweenIndexes( Vector3Int a, Vector3Int b ) {
        Vector3Int distance = (a - b);
        distance.x = Mathf.Abs( distance.x );
        distance.y = Mathf.Abs( distance.y );
        distance.z = Mathf.Abs( distance.z );

        return ( distance.x + distance.z );
    }

}
