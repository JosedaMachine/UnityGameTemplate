using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralllaxing : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smotthing = 1f;

    [SerializeField] GameObject cam;
    private Vector3 previousCamPos;

    // Use this for initialization
    void Start()
    {
        previousCamPos = cam.transform.position;

        parallaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
            parallaxScales[i] = backgrounds[i].position.z * -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.transform.position.x) * parallaxScales[i];

            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smotthing * Time.deltaTime);
        }

        previousCamPos = cam.transform.position;
    }
}