using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit {

    string Name { get; set; }
    int MoveRange { get; }
    Vector3Int Location { get; set; }


    void move(ITile tile);
}