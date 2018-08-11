using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestComparer : IComparer<IUnit> {

    public int Compare( IUnit a, IUnit b ) {

        if (a.MoveRange > b.MoveRange) {
            return 1;
        } else if (a.MoveRange == b.MoveRange) {
            return 1;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
        }

        return -1;
    }

}
