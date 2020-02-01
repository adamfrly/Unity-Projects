using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty {

    static float secondToMaxDifficulty = 60;

    public static float getDifficultyPercent()
    {
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondToMaxDifficulty);
    }

}
