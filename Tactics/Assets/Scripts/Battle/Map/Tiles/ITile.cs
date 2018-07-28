using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITile: IConfigurable {
    Vector3Int Index { get; }
    bool IsOccupied { get; set; }
}
