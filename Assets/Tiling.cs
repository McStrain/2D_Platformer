using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {
    public int offsetX = 2;  // the offset so we don't get any wierd errors

    //  these are used for checking if we need to instantiate stuff
    public bool hasARightBuddy = false;  
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;  // used if the object is not tilable

    private float spriteWidth = 0f;  // the width of our element
    private Camera cam;
    private Transform myTransform;

    void Awake()
    {
        cam = Camera.main;
        myTransform = transform;

    }

	// Use this for initialization
	void Start () {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
        // does it still need buddies?
        if (hasALeftBuddy == false || hasARightBuddy == false)
        {
            // calculate the camers extend (half the width) of what the camera can see in world coordinates.
            float camHorizontalExtend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate the x position where the camera can see the edge of the sprite (element)
            float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePostionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExtend;
        }
	
	}
}
