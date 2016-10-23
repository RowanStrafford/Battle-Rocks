using UnityEngine;
using System.Collections;

public class MenuRockMovement : MonoBehaviour {

    public float smooth = 1f;

    private bool startSpin = false;

    private Vector3 targetAngles;


    void Update ()
    {
        if (startSpin == true)
        SpinRock();
    }

    void OnMouseDown()
    {
        StartSpinRock();
    }

    void StartSpinRock()
    {
        startSpin = true;
    }

    void SpinRock()
    {
        if (targetAngles.z < -10f)
        {
            startSpin = false;
        }
        targetAngles = transform.eulerAngles + -180f * -Vector3.forward;
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, targetAngles, smooth * Time.deltaTime);
    } 
}
