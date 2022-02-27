using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombKey : MonoBehaviour
{
    
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform bombSpawnPoint;
    private void Reset()
    {
        onClick();    
    }

    public void onClick()
    {
        Instantiate(bomb, bombSpawnPoint.position, Quaternion.identity);
    }
    
}