using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnPoint;

    public Vector3 getPlayerSpawnPoint() {

        return SpawnPoint.transform.position;

    }
}
