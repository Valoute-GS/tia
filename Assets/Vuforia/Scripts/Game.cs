using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text lifeText;
    private int life;
    public Text waveText;
    private int wave;

    private int radius;

    public GameObject chickPrefab;
    public GameObject chickParent;

    // Start is called before the first frame update
    void Start()
    {
        life = 100;
        wave = 1;
        lifeText.text = "Life : " + life;
        waveText.text = "Wave : " + wave;
        InvokeRepeating("SpawnChick", 1.0f, 1.0f);

        radius = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnChick()
    {

        Debug.Log("Spawn");
        float angle = Random.Range(0f, Mathf.PI * 2);
        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;
        var newChick = Instantiate(chickPrefab, new Vector3(x, 0, y), Quaternion.identity);
        newChick.transform.parent = chickParent.transform;
    }
}
