using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float slideSpeed;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousePos);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            GameObject firstCup = StackController.instance.cups[0];
            Vector3 hitVec = hit.point;
            hitVec.y = firstCup.transform.localPosition.y;
            hitVec.z = firstCup.transform.localPosition.z;

            firstCup.transform.localPosition = Vector3.MoveTowards(firstCup.transform.localPosition, hitVec, Time.deltaTime* slideSpeed);
        }
    }
}
