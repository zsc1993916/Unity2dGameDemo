using UnityEngine;
using System.Collections;

public class GoodsUp : MonoBehaviour {

    public float UpLimit = 2.0f;
    public float UpSpeed = 0.1f;
    public float UpStartRange = 15.0f;
    private bool UpStaus;

	// Use this for initialization
	void Start () {
        UpStaus = false;

		gameObject.transform.position = new Vector3 (gameObject.transform.position.x,
		                                             gameObject.transform.position.y - UpLimit,
		                                             gameObject.transform.position.z);
	}

    IEnumerator GoUp()
    {
        //Debug.Log("Scripts GoodsUp,fun GoUp : go to here???");
        float now = 0.0f;

        while(now <= UpLimit)
        {
            now += UpSpeed;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y + UpSpeed,
                                                        gameObject.transform.position.z);

            yield return new WaitForSeconds(0.01f);
        }

		gameObject.transform.position = new Vector3 (gameObject.transform.position.x,
		                                             gameObject.transform.position.y,
		                                             -1.9f);
    }
	
	// Update is called once per frame
	void Update () {
        if (!UpStaus)
        {
            Vector3 PlayerPos = GameObject.Find("PlayerCC/Player").transform.position;

            if (System.Math.Abs(transform.position.x - PlayerPos.x) < UpStartRange)
            {
                UpStaus = true;
                StartCoroutine(GoUp());
            }
        }
	}
}
