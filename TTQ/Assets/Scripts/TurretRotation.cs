using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    GameObject cannon;
    void Start()
    {
        cannon = transform.Find("Cannon").gameObject;
        //cannon.transform.position = new Vector3(transform.position.x, transform.position.y + 6f, transform.position.z);
        //cannon.transform.rotation = transform.rotation;
    }

    GameObject prevGo;
    GameObject hitted;

    Vector3 firstRot;
    Vector3 finalRot;

    Vector3 cannonFirstRot;
    Vector3 cannonFinalRot;
    bool changeRot = false;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        if (Physics.Raycast(ray, out hit, 500.0f))
        {
            if (hit.transform.gameObject.tag == "selectable")
            {
                hitted = hit.transform.gameObject;
                if (hitted != prevGo)
                {
                    if (prevGo)
                    {
                        prevGo.GetComponent<ColorSaver>().isHitted = false;
                    }
                    prevGo = hitted;
                }
                else
                {
                    hitted.GetComponent<ColorSaver>().isHitted = true;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    changeRot = true;
                    transform.LookAt(hitted.transform);
                    finalRot.y = transform.rotation.eulerAngles.y;
                    transform.rotation = Quaternion.Euler(firstRot);
                    cannon.transform.rotation = Quaternion.LookRotation(-(hitted.transform.position-transform.position), Vector3.up);
                    cannonFinalRot = cannon.transform.rotation.eulerAngles;
                    cannon.transform.rotation = Quaternion.Euler(cannonFirstRot);
                    finalRot.x = cannonFinalRot.x;
                    
                }
            }
            else
            {
                if (prevGo)
                {
                    prevGo.GetComponent<ColorSaver>().isHitted = false;
                }
            }
        }
        firstRot = transform.rotation.eulerAngles;
        cannonFirstRot = cannon.transform.rotation.eulerAngles;
        if (!changeRot)
        {
            finalRot = firstRot;
            cannonFinalRot = cannonFirstRot;
        }

        transform.rotation = Quaternion.Slerp(Quaternion.Euler(firstRot), Quaternion.Euler(-finalRot), Mathf.PingPong(Time.time, 2) / 2);
        cannon.transform.rotation = Quaternion.Slerp(Quaternion.Euler(cannonFirstRot), Quaternion.Euler(cannonFinalRot), Mathf.PingPong(Time.time, 2) / 2);
    }
}
