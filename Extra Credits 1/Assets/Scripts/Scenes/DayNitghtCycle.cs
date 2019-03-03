using System;
using UnityEngine;
using UnityEngine.UI;

public class DayNitghtCycle : MonoBehaviour
{
    private static readonly int SECOND_IN_DAY = 24 * 60 * 60;

    public float currentTimeOfDay;
    private Light SunLight;
    private Transform SunTransform;
    public Text timetext;

    private float intensity;
    public Color fogday = Color.white;
    public Color fognight = Color.grey;

    public int speed = 10000;

    //Has to be at least 4 so-called control points
    public Vector2 startPoint;
    public Vector2 endPoint;
    public Vector2 controlPointLeft;
    public Vector2 controlPointRight;

    private void Start()
    {
        this.SunLight = this.GetComponentInChildren<Light>();
        this.SunTransform = this.GetComponent<Transform>();
        this.SunTransform.position = new Vector3(startPoint.x, startPoint.y, this.SunTransform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        this.ChangeTime();
        this.ChangePosition();
        // this.sun.transform.RotateAround(Vector3.zero, Vector3.back, 15f * Time.deltaTime);
    }

    //The De Casteljau's Algorithm
    public Vector3 DeCasteljausAlgorithm(float t, Vector3 A, Vector3 B, Vector3 C, Vector3 D)
    {
        //Linear interpolation = lerp = (1 - t) * A + t * B
        //Could use Vector3.Lerp(A, B, t)

        //To make it faster
        float oneMinusT = 1f - t;

        //Layer 1
        Vector3 Q = oneMinusT * A + t * B;
        Vector3 R = oneMinusT * B + t * C;
        Vector3 S = oneMinusT * C + t * D;

        //Layer 2
        Vector3 P = oneMinusT * Q + t * R;
        Vector3 T = oneMinusT * R + t * S;

        //Final interpolated position
        Vector3 U = oneMinusT * P + t * T;

        return U;
    }

    public void ChangePosition()
    {
        Vector2 p;
        if (this.currentTimeOfDay > SECOND_IN_DAY / 4 && this.currentTimeOfDay < SECOND_IN_DAY / 4 * 3)
        {
            p = this.DeCasteljausAlgorithm((this.currentTimeOfDay - SECOND_IN_DAY / 4) / (SECOND_IN_DAY / 2),
                this.startPoint, this.controlPointLeft, this.controlPointRight, this.endPoint);
            this.SunTransform.position = new Vector3(p.x, p.y, this.SunTransform.position.z);
        }
       /* else
        {

            if (this.currentTimeOfDay < SECOND_IN_DAY / 4)
            {
                p = this.DeCasteljausAlgorithm((this.currentTimeOfDay + (SECOND_IN_DAY / 4)) / (SECOND_IN_DAY / 2),
                          this.startPoint, this.controlPointLeft, this.controlPointRight, this.endPoint);
            }
            else
            {
                p = this.DeCasteljausAlgorithm((this.currentTimeOfDay - (SECOND_IN_DAY / 4 * 3)) / (SECOND_IN_DAY / 2),
                            this.startPoint, this.controlPointLeft, this.controlPointRight, this.endPoint);
            }
            this.SunTransform.position = new Vector3(-p.x, -p.y, this.SunTransform.position.z);//Vector3.Reflect(p, Vector3.right);
        }*/
    }

    public void ChangeTime()
    {
        this.currentTimeOfDay += Time.deltaTime * this.speed;
        if (this.currentTimeOfDay > SECOND_IN_DAY)
        {
            ApplicationModel.days += 1;
            this.currentTimeOfDay = this.currentTimeOfDay % SECOND_IN_DAY;
        }
        this.timetext.text = TimeSpan.FromSeconds(this.currentTimeOfDay).ToString();

        this.SunLight.transform.rotation = Quaternion.Euler(new Vector3((this.currentTimeOfDay + SECOND_IN_DAY / 3) / SECOND_IN_DAY * 360, 0, 0));

        if (this.currentTimeOfDay < SECOND_IN_DAY / 2)
        {
            this.intensity = 1 - (SECOND_IN_DAY / 2 - this.currentTimeOfDay) / (SECOND_IN_DAY / 2);
        }
        else
        {
            this.intensity = 1 - (this.currentTimeOfDay - SECOND_IN_DAY / 2) / (SECOND_IN_DAY / 2);
        }

        RenderSettings.fogColor = Color.Lerp(this.fognight, this.fogday, this.intensity * this.intensity);
        this.SunLight.intensity = this.intensity;
    }
}
