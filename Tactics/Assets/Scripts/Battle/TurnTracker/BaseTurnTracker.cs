﻿//using System.Linq;
//using System.Collections.Generic;
//using UnityEngine;

//public class TurnTracker {

//    private int round;
//    private int turn;
//    private List<GameUnit> turnList;

//    public TurnTracker() {
//        round = 0;
//        turn = 0;
//    }

//    public GameUnit getCurrentActor() {
//        return turnList[turn];
//    }

//    public List<GameUnit> getTurnList() {
//        return turnList;
//    }

//    public void advanceTurn(int i = 1) {
//        if (i < 1) {
//            if (i == 0) {
//                Debug.LogWarning("Are you sure you meant to advance by 0 turns?");
//            }
//            throw new System.Exception("Advance only takes positive arguments.");
//        }

//        turn += i;
//        if (turn >= turnList.Count) {
//            round += turn / turnList.Count;
//            turn %= turnList.Count;
//        }
//    }
//}
