//using UnityEngine;
//using System.Collections;

//public class Walk : BaseAbility {
//    private float _moveSpeed;

//    public bool canExecute(ITile from, ITile to, int moveRange) {
//        Vector3Int delta = Vector3.Distance(to.Location - from.Location);
//        int distance = delta.x + delta.z;
//        if (distance > moveRange) {
//            return false;
//        }

//        return true;
//	}

//    public override void execute(Transform transform, Vector3 destination) {
//        StartCoroutine(animateMove(transform, destination));
//	}

//    private IEnumerator animateMove(Transform transform, Vector3 destination) {
//        float step = this._moveSpeed * Time.deltaTime;
//        while (transform.position != destination) {
//            transform.position = Vector3.MoveTowards(transform.position, destination, step);
//            yield return null;
//        }
//    }
//}