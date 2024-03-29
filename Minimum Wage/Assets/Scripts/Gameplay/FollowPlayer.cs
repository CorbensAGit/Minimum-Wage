using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform Player;
    public Transform TopPlatform;
    public Transform BottomPlatform;
    public Transform LWall;
    public Transform RWall;
    private float middlePoint;

    void Start () 
    {
        middlePoint = (LWall.transform.position.x + ((RWall.transform.position.x - LWall.transform.position.x)/ 2));
    }

    // Update is called once per frame
    void Update () {
        if (Player != null)
        {
            if (Player.transform.position.y < (TopPlatform.transform.position.y+2) && Player.transform.position.y > BottomPlatform.transform.position.y+12)
            {

                transform.position = new Vector3(middlePoint, Player.transform.position.y, -28);
            }  
        }
    }
}
