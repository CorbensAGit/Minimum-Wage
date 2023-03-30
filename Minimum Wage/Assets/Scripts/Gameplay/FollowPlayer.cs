using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;

    // Update is called once per frame
    void Update () {
        if (player != null)
        {
            if (player.transform.position.y < 16 && player.transform.position.y > 0)
            {
                transform.position = new Vector3(0, player.transform.position.y, -20);
            }  
        }
    }
}
