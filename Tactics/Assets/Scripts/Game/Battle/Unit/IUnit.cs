using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit {

    string Name { get; set; }
    Vector3Int Index { get; set; }
    Player Owner { get;  }


    void move(ITile tile);
    bool canPassThrough(ITile tile);
    bool canEndTurnOn(ITile tile);
}