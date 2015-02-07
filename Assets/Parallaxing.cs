using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {
    public Transform[] backgrounds; // Array of all the back and foregrounds to be parallaxed.
    private float[] parallaxScales; // Proportion of the cameras movement to move the backgrounds by.
	public float smoothing = 1f;               // How smooth the parallax is going to be.  Make sure to set this above zero, or parallaxing will not work.
    
    private Transform cam;          // reference to the mian camers transform
    private Vector3 previousCamPos;  // the postion of the camer in the previous frame
    
    // Is called before initialization.  Great for references
    void Awake()
    {   // set up camera reference
        cam = Camera.main.transform;
    }

    // Use this for initialization
	void Start () {
        // The previous frame had the current frame's camera position
        previousCamPos = cam.position;
        
        // assigning corresponding parallax scales
        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
	// for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camer movement because the previous frame multiplied by the scale.
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];
            
            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the backgrounds current position with it's target x position
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
        
            // fade between current postion and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
            
            
        }

        // set the previousCamPosition to the camera's position at the end of the frame
        previousCamPos = cam.position;
	}
}
