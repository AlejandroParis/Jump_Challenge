using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateMap : MonoBehaviour
{
    public float jumpTime;
    public bool rotating = false;
    public Vector3 newRotation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!rotating)
            {
                RotateRoom();
            }
        }
        if (transform.rotation.eulerAngles == newRotation)
        {
            rotating = false;
        }
    }
    public void RotateRoom()
    {
        newRotation = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + 90);
        transform.DORotate(newRotation, jumpTime, RotateMode.Fast);
        StartCoroutine(Wait());
        rotating = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(jumpTime);
        if (newRotation.z == 360)
        {
            newRotation.z = 0;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }
}
