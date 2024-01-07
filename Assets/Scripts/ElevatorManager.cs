using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{
    public bool isElevatorDown = true; 
    public Vector3 translatePos = new Vector3(0,4,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Hand"))
        {
            changePosition();
        }
    }
    void changePosition()
    {
        if (isElevatorDown)
        {
            transform.Translate(translatePos);
            GameManager.instance.player.transform.Translate(translatePos);
        }
        else
        {
            transform.Translate(-translatePos);
            GameManager.instance.player.transform.Translate(-translatePos);
        }
        isElevatorDown = !isElevatorDown;
        
    }
}
