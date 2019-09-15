using UnityEngine;

public class FakeParallax : MonoBehaviour {

    public Transform target;    // The object to follow
    [SerializeField] Transform closeTrees;
    [SerializeField] Transform midTrees;
    public float speedMod = 20.0f;  // Camera speed
    public float topMargin = 0.2f;  // Top rotation margin

// The position of the target
    private Vector3 point;
// Point if the camera is rotating to the left
    private bool toLeft;

// Use this for initialization
    void Start () {
        point = target.transform.position;
        transform.LookAt (point);
    }

// Update is called once per frame
    void Update () {


        // The camera is moving to the right until it reaches the top margin, then it changes it movement direction
        if (!toLeft) {
            transform.RotateAround (point, new Vector3 (0f, 1f, 0f), Time.deltaTime * speedMod);
            rotateCloseTrees (1);
            rotateMidTrees (-1);
            if (transform.rotation.y >= topMargin) {
                toLeft = true;
            }
        } else {
            transform.RotateAround (point, new Vector3 (0f, -1f, 0f), Time.deltaTime * speedMod);
            rotateCloseTrees (-1);
            rotateMidTrees (1);
            if (transform.rotation.y <= -topMargin) {
                toLeft = false;
            }
        } 
    }


// Direction = 1 (left) | -1 (right)
    public void rotateCloseTrees(float direction)
    {
        closeTrees.transform.Rotate (new Vector3(0, Time.deltaTime * (speedMod * 2) * direction, 0));
    }

    public void rotateMidTrees(float direction)
    {
        midTrees.transform.Rotate (new Vector3(0, Time.deltaTime * (speedMod * 1) * direction, 0));
    }
}