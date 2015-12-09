using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {
    public float speed;

    void FixedUpdate()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Quaternion rotation = Quaternion.LookRotation(transform.position - mousePosition, Vector3.back);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        GetComponent<Rigidbody2D>().angularVelocity =-0f;
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0.0f, speed * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
		Vector3 pos = transform.position;
		if (pos.y > Camera.main.orthographicSize) {
			pos.y =  Camera.main.orthographicSize;
		}
		if (pos.y < -Camera.main.orthographicSize) {
			pos.y =  -Camera.main.orthographicSize;
		}
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		if (pos.x > widthOrtho) {
			pos.x =  widthOrtho;
		}
		if (pos.x < -widthOrtho) {
			pos.x =  -widthOrtho;
		}
		transform.position = pos;
	}

    }

   

