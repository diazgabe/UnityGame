//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TileFactory : MonoBehaviour, IFactory {

//    GameObject landTile;
    

//    private void Awake() {
//        landTile = Resources.Load<GameObject>("Prefabs/Tiles/Land");
//    }

//    public IConfigurable generateFromConfig(IConfig config) {
//        TileConfig tileConfig = config as TileConfig;
//        GameObject tile;
//        switch(tileConfig.tileType) {
//            case TileType.Land: {
//                    //tile = Instantiate(landTile, tilePosition, Quaternion.identity);
//                    break;
//            }
//            case TileType.Lava: {
//                    break;
//            }
//            case TileType.Water: {
//                    break;
//            }
//        }
//        return tile;
//    }

//}