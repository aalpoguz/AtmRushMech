using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed;
    public float swipeSpeed;

    private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }

    private void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit; //çarpılan noktayı almak için
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) //çarpıp çarpmama kontrolü
        {
            GameObject firstCube = ATMRush.instance.cubes[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCube.transform.localPosition.y;
            hitVec.z = firstCube.transform.localPosition.z;

            firstCube.transform.localPosition = Vector3.MoveTowards(firstCube.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
        }
    }
}
