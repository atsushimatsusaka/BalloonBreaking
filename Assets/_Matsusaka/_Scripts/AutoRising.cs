using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRising : MonoBehaviour
{
    private Vector2 risingSpeedRange = new Vector2(0.5f, 1f);
    private float risingSpeed;
    private float posY;
    private Vector3 iniPos;
    public bool shoot = false;
    //public bool up = false;
    //[SerializeField] private Renderer targetRenderer;
    // Start is called before the first frame update
    void Start()
    {
        var rotY = Random.Range(0f,360f);
        GetComponent<Transform>().localEulerAngles = new Vector3(0f, rotY, 0f);

        iniPos = GetComponent<Transform>().position;
        posY = iniPos.y;

        risingSpeed = Random.Range(risingSpeedRange.x,risingSpeedRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (posY > 5f)
        {
            DestroyObj();
        }

        posY += Time.deltaTime * risingSpeed;
        gameObject.transform.position = new Vector3(iniPos.x, posY, iniPos.z);

        //if (!shoot)
        //{
        //    //posY += Time.deltaTime;
        //    //gameObject.transform.position = new Vector3(iniPos.x, posY, iniPos.z);
        //}
        //else
        //{

        //}

        //if (!targetRenderer.isVisible && up)
        //{
        //    shoot = true;
        //    //Debug.Log("Invisible");
        //}
    }

    //BrokenBalloonTL‚Å‚àŒÄ‚Ô
    public void DestroyObj()
    {
        Destroy(gameObject);
    }
}
