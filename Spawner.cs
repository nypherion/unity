using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    uint value;
    [SerializeField] uint speed, dist, cldwn;
    [SerializeField] GameObject spawner, prefab;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeValue(Text valueText)
    {
        bool parse = uint.TryParse(valueText.text, out uint parsedValue);
        if (parse) value = parsedValue;
        else value = 0;
    }

    public void SetValue(string valueType)
    {
        switch (valueType)
        {
            case "speed":
                speed = value;
                break;
            case "distance":
                dist = value;
                break;
            case "cooldown":
                cldwn = value;
                break;
        }
        StopAllCoroutines();
        if (speed > 0 && dist > 0 && cldwn > 0) StartCoroutine(Spawn());
        value = 0;
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject cube = Instantiate(prefab);
            cube.transform.position = spawner.transform.position;
            cube.GetComponent<Movement>().MoveForward(dist, speed);
            //Movement(cube);
            yield return new WaitForSecondsRealtime(cldwn);
        }
    }

    //void Movement(GameObject cube) ## Накуролесил с функциями и проебался с апдейтом сука блядская, пришлось делать через префаб и отдельный скрипт на ебучем кубе
    //{
    //    float xpos = cube.transform.position.x + dist;
    //    Vector3 target = new Vector3(xpos, cube.transform.position.y, cube.transform.position.z);
    //    cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, speed * Time.fixedDeltaTime);
    //    if (cube.transform.position == target) Destroy(cube.transform);
    //}
}
