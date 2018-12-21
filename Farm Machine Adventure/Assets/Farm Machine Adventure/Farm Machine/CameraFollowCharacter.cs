using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCharacter : MonoBehaviour
{
    public GameObject camara;
    public GameObject player;
    // private Vector3 offset;
    public float offset;
    private Vector3 PlayerPosition;
    public float SmoothingTime;
    // Start is called before the first frame update
    void Start()
    {
        //offset = camara.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // camara.transform.position = player.transform.position + offset;

        PlayerPosition = new Vector3(player.transform.position.x, camara.transform.position.y, camara.transform.position.z);

        if(player.transform.localScale.x>0f)
        {
            PlayerPosition = new Vector3(PlayerPosition.x + offset, PlayerPosition.y, PlayerPosition.z);
        }
        else
        {
            PlayerPosition = new Vector3(PlayerPosition.x - offset, PlayerPosition.y, PlayerPosition.z);
        }

        camara.transform.position = Vector3.Lerp(camara.transform.position, PlayerPosition, SmoothingTime*Time.deltaTime);

       // camara.transform.position = PlayerPosition;
    }
}
