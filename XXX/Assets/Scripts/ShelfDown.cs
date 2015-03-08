using UnityEngine;
using System.Collections;

public class ShelfDown : MonoBehaviour {

	public float delayTime;
	public float dropSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" &&
		    Mathf.Abs(col.contacts[0].point.y - col.contacts[1].point.y) < 0.01f &&
		    transform.position.y < col.contacts[0].point.y)
		{
			StartCoroutine(Down());
		}
	}

    IEnumerator Down()
    {
		yield return new WaitForSeconds(delayTime);

        do
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y - dropSpeed,
                                                        gameObject.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        } while (gameObject.transform.position.y > -30);
        Destroy(gameObject);
    }
}