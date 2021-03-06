﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleConfig : IConfig {

    public MapConfig map;
    public List<UnitConfig> Allies;
    public List<UnitConfig> Enemies;
}