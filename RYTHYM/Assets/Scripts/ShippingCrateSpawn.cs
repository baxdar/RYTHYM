using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingCrateSpawn : MonoBehaviour {

    public int numberOfContainers = 15;
    public GameObject[] shippingContainersObjects;

    private void Start()
    {
        for(int i =0; i<numberOfContainers; i++)
        {
            float randomFloat = Random.Range(.1f, 1f);
            int randomNumber = Random.Range(0, 3);
            Vector3 randomVector3 = new Vector3(Random.Range(-150f, 150f), Random.Range(-80f, 80f), Random.Range(-6f, 9f));
            GameObject cont = Instantiate(shippingContainersObjects[randomNumber], randomVector3, Quaternion.identity);
            cont.transform.localScale = new Vector3(randomFloat, randomFloat, 1);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
