using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

/*
 * applem - Unity 3D Roll-a-ball Tutorial
 * Dec 5 2017
 * Dec 4 2017
 * Nov 20 2017
 * 
 * MonoBehaviour - "the base class from which every Unity script derives."
 */
public class PlayerController : MonoBehaviour {
    //private const string AXISNAME_V = "Vertical";
    //private const string AXISNAME_H = "Horizontal";
    private const int MAX_COLLECT = 8;
    private Rigidbody rb;

    private int count;
    public Text countText;

    public Text winText;

    private IDeviceType deviceType;


    //Public fields will apppear as *editable* fields in Unity Inspector
    public float speed;


    //Called on the first frame in which the script is active
    // (Often the first frame of the application)
    void Start()
    {
        //speed = 1.0f; //This would always reset speed to 1, regardless of value entered in Inspector

        //Count of objects collected
        //****** NB: displayed in UI Text component,
        //******     which must be a child of a Canvas to display properly
        //
        //Set Text anchor to Top Left (Anchor Presets view under Inspector>Rect transform)
        // also set Pivot(Shift key) and Position(Alt key)
        //
        //***** NB: Set both Horiz and Vert Overflow to "Overflow" (instead of Wrap or Truncate)
        //*****      in order to see full text if it is too long for text box ...
        count = 0;
        UpdateStatsDisplay();
        //winText.text = ""; //see "Bonus, not in tutorial"

        //Gets attached Rigidbody if there is one
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            throw new System.Exception("No RigidBody attached to Component");
        }

        //Bonus, not in tutorial
        deviceType = DeviceTypeFactory.getDeviceType();
        //TODO: place in separate object
        string devicename = deviceType.ToString();
        winText.text = "applem34 Demo:\n" + devicename.TrimStart("Assets.Scripts.".ToCharArray());

    }

    private void UpdateStatsDisplay()
    {
        countText.text = "Cubes Collected: " + count.ToString();
        if (count == MAX_COLLECT)
        {
            winText.text = "WINNER ☺";
            return;
        }
        //Bonus, not in tutorial
        winText.text = "Cubes Remaining: " + (MAX_COLLECT - count).ToString();

    }

    //Called before each attempt to render a frame 
    void Update()
    { }

    //Called before performing any physics calculations
    void FixedUpdate()
    {
        //Bonus, not in tutorial
        // Get movement from factory method based on device type
        Vector3 vecMove = deviceType.MovePlayer();

        rb.AddForce(vecMove * speed );

    }

    //Detect collisions between Player and other
    // Called when playerGameObject touches other's trigger collider
    private void OnTriggerEnter(Collider other)
    {
        //Remove other's gameObjects/components/children from scene
        //Destroy(other.gameObject);

        //Handle PickUp collisions
        HandlePickup(other);

    }

    private void HandlePickup(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {

            //Static collider - non moving objects (walls, ground, ..)
            // - not affected by collision  
            //
            // 
            // **** NB: 
            //      - volumes of static colliders are calculated once by Unity Engine, then cached for performance
            //      - if a static collider is moved/rotated/scaled, volume is recalculated and recached - takes time

            //Dynamic collider - moving objects (player, ...)
            // - is affected by collision

            //Gamobjects with Collider but no Rigidbody:
            //  ==> STATIC 

            //Gamobjects with Collider AND Rigidbody:
            //  ==> DYNAMIC
            
            //Rigidbody.IsKinematic: RB doesnt react to physics forces (like static collider)

            //Trigger collider - collider which allow overlapping with other colliders without bouncing off each other
            //  - detect events via
            //      OnTrigger event message
            //
            //  - set via "Is Trigger" checkbox in Inspector> Collidder

            //Deactivate PickUp object:
            // code equivalent of clicking active checkbox next to gameObject in Inspector
            other.gameObject.SetActive(false);

            count++;

            UpdateStatsDisplay();
        }
    }
}
