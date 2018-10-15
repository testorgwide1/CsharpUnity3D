using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.windows
{
    /*
     * applem - Unity 3D Roll-a-ball Tutorial
     * Dec 28 2017
     */
    public class WindowsDeviceType : IDeviceType
    {

        private const string AXISNAME_V = "Vertical";
        private const string AXISNAME_H = "Horizontal";

        public float speed;

        public Vector3 MovePlayer()
        {
            //Capture user input for player movement
            float moveV = Input.GetAxis(AXISNAME_V);
            float moveH = Input.GetAxis(AXISNAME_H);

            //Moving only in 2D, no movement in Y-axis
            Vector3 vecMove = new Vector3(moveH, 0.0f, moveV);
            return vecMove;

        }

    }
}
