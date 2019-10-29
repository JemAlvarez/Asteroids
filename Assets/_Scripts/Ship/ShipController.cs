using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] float velocity = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateToMouse();

        Move();
    }

    void RotateToMouse()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void Move()
    {
        Vector2 pos = transform.position;
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");


        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * velocity * Time.deltaTime;

        transform.position += tempVect;

        var currentPos = transform.position;

        currentPos.x = Mathf.Clamp(currentPos.x, -1.5f, 1.5f);
        currentPos.y = Mathf.Clamp(currentPos.y, -1.5f, 1.5f);

        transform.position = currentPos;
    }
}
