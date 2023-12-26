using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material material;

    private Vector2 offset;
    public float yVelocity, xVelocity;

    public bool moveBG = false;
    public static Background instance;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveBG)
        {
            MoveBackground();
        }
    }

    public void MoveBackground()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
