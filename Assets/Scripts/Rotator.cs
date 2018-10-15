using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * applem - Unity 3D Roll-a-ball Tutorial - 5 of 8 : Creating Collectibles
 * Nov 27 2017
 * 
 * Prefab - Asset which contains a template for GameObjects
 *      1. Create prefab from existing GameObject
 *          A. Create "Prefabs" folder in Project view
 *          B. Select GameObject in Hierarchy view (Roll a Ball: PickupCube)
 *          C. Drag GameObject to Hierachy > Prefabs.  This automatically creates the Prefabs template.
 *          
 *      2. Can change behaviour/properties on all instances of this GameObject by changing behaviour/properties in prefab
 */
public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {

        //Multiplier for smooth and framerate-independent actions
        float smoothingTimeFactor = Time.deltaTime;

        //Rotate the transform component smoothly
        transform.Rotate(new Vector3(15, 30, 45) * smoothingTimeFactor );
		
	}
}
