using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMap {
    void setTile(Vector3Int index, GameObject tile);
}
