using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject ballPrefab;
    public GameObject ball;
    public float ballVelocity;

    [Header("Set Dynamically")]
    public GameObject holdingPoint;
    public Vector3 holdPos;
    public bool swingMode;
    private Rigidbody ballRigidbody;
    public Vector3 mouseDelta;
    public Vector3 launchVector = new Vector3();
    void Awake()
    {
        Transform holdingPointTrans = transform.Find("HoldingPoint");
        holdingPoint = holdingPointTrans.gameObject;
        holdingPoint.SetActive(false);
        holdPos = holdingPointTrans.position;
        print(ballVelocity);
    }

    private void OnMouseDown()
    {
        ball = Instantiate<GameObject>(ballPrefab);
        swingMode = true;
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!swingMode) return;

        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = holdingPoint.transform.position;
        pos.x = mousePos3D.x;
        pos.y = mousePos3D.y;
        holdingPoint.transform.position = pos;

        mouseDelta = mousePos3D - holdPos;
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 batPos = holdPos + mouseDelta;
        this.transform.position = batPos;

        if (Input.GetMouseButtonUp(0))
        {
            swingMode = false;

        }
    }

    private void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.CompareTag("Ball"))
        {
            launchVector.x = Random.value * 5;
            launchVector.y = Random.value * 5;
            ballVelocity = Random.value * 10;
            ballRigidbody.velocity = (launchVector * ballVelocity);
            TrackCamera.POI = ball;
        }
    }
}
