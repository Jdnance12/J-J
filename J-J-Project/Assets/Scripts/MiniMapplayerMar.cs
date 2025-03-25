using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapplayerMar : MonoBehaviour
{

    public Transform player;
    public RectTransform marker;


    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.position;

        marker.localPosition = new Vector3(playerPosition.x, playerPosition.z, 0);
    }
}
