//using UnityEngine;
//using System.Collections;

//public class Teleport : MonoBehaviour {
//    public bool canExecute(ITile from, ITile to, int moveRange) {
//        Vector3Int delta = Utilities.vector3Abs(to.Location - from.Location);
//        int distance = delta.x + delta.y;
//        if (distance > moveRange) {
//            return false;
//        }

//        return true;
//    }

//    public void execute(Transform transform, Vector3 destination) {
//        StartCoroutine(animateMove(transform, destination));
//    }

//    private IEnumerator animateMove(Transform transform, Vector3 destination) {
//        transform.GetComponent<Animation>().Play();
//    }
//}