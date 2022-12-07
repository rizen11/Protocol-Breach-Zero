using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeRoomController : MonoBehaviour
{
    public GameObject[] bonuses;

    public Transform spawner1;
    public Transform spawner2;
    public Transform spawner3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other) {
        int rand1 = Random.Range(0, bonuses.Length);
        
        int rand2 = Random.Range(0, bonuses.Length);

        int rand3 = Random.Range(0, bonuses.Length);
        Instantiate(bonuses[rand1], spawner1);
        Instantiate(bonuses[rand2], spawner2);
        Instantiate(bonuses[rand3], spawner3);
    }
}
