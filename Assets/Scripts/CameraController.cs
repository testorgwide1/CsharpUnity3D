using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * applem - Unity 3D Roll-a-ball Tutorial - 3 of 8 : Moving the Camera 
 * Nov 23 2017
 * 
 * - cannot make Camera a child of Player -> camera rolls when player rolls
 * 
 * - so instead make separate Camera controller which maintains steady view while moving with player 
 *    (1st/3rd person perspective)
 *    
 *    *** NB: Remember in Inspector to drag Player (from Hierarchy) 
 *          into MainCamera.Inspector."CameraContoller (Script)".playerGameObj field ...
 *          ... otherwise Camera wont move with object in Game view ...
 */
public class CameraController : MonoBehaviour {

    public GameObject playerGameObj;

    private Vector3 offset;

	// Use this for initialization
	void Start () {

        //transform (lowercase) - references the Transform attached to this component (in Inspector) 

        //Initialize by getting the original diff between Camera and Player
        offset = transform.position - playerGameObj.transform.position;


    }

    // Called once per frame "...if the Behaviour is enabled."  See API
    //
    // Similar to Update(), but is called *after* all other updates have been performed.
    //
    // *** Follow Camera movements should be done here to ensure we get the latest postiion of tracked objects.
    //       Tracked objects may have moved since Update() was called...
    void LateUpdate () {

        //Update Camera position before every frame by adding original offset to current Player position.
        //
        // This allows maintaining a steady Camera view while moving with Player (1st / 3rd person perspective),
        // as opposed to making the Camera child of Player, which causes Camera to roll when Player rolls...
        transform.position = playerGameObj.transform.position + offset;

		
	}
}
