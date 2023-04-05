using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform Player;
    public Transform TopPlatform;

    // Update is called once per frame
    void Update () {
        if (Player != null)
        {
            if (Player.transform.position.y < TopPlatform.transform.position.y && Player.transform.position.y > 0)
            {
                transform.position = new Vector3(-14, Player.transform.position.y, -20);
            }  
        }
    }
}
