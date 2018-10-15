using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour {

	public void HandleExit () {
        //Bonus, not in tutorial
        //Allow user to terminate application

        //TODO: add confirmation dialog
        Debug.Log("User Clicked Exit Game");
        Application.Quit();        
    }
}
