using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DetectionScript : MonoBehaviour
{
    public bool isSpotted = false;
    //private float sightDistance = 10f;
    private Camera firstperson;

    private void Start()
    {
        firstperson = Camera.main;
    }

    private void FixedUpdate()
    {
        Ray ray = firstperson.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        RaycastHit hit;
        ray.origin = ray.GetPoint(100);
        ray.direction = -ray.direction;

        while (Physics.Raycast(ray, out hit, Mathf.Infinity, 7))
        {
            Debug.Log("Enemy is in sight");
            isSpotted = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
        
    }
    
}
