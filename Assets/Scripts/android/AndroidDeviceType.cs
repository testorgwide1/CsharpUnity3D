using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * applem - Unity 3D Roll-a-ball Tutorial
 * Dec 28 2017
 * Bonus, not in tutorial
 */

namespace Assets.Scripts.android
{

    public class AndroidDeviceType : IDeviceType
    {


        public static Vector3 defaultAccel;
        public static Vector3 currAccel;
        private static float accelV;
        private static float accelH;

        public Vector3 MovePlayer()
        {
            currAccel = Vector3.Lerp(currAccel, Input.acceleration - defaultAccel, Time.deltaTime / 0.5f);
            accelV = Mathf.Clamp(currAccel.y * 10f, -1, 1);
            accelH = Mathf.Clamp(currAccel.x * 10f, -1, 1);

            //Capture user input for player movement
            float moveV = accelV;
            float moveH = accelH;

            //Moving only in 2D, no movement in Y-axis
            Vector3 vecMove = new Vector3(moveH, 0.0f, moveV);
            return vecMove;
        }
    }
}
