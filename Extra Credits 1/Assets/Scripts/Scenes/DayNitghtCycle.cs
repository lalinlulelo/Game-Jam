using System;
using UnityEngine;
using UnityEngine.UI;

public class DayNitghtCycle : MonoBehaviour
{
    private static readonly int SECOND_IN_DAY = 24 * 60 * 60;

    public float currentTimeOfDay;
    public Transform SunTransform;
    public Light SunLight;
    public Text timetext;
    public int days;

    public float intensity;
    public Color fogday = Color.white;
    public Color fognight = Color.grey;

    public int speed;

    public Transform sun;

    //Has to be at least 4 so-called control points
    public Transform startPoint;
    public Transform endPoint;
    public Transform controlPointLeft;
    public Transform controlPointRight;

    private void Start()
    {
        this.sun.position = this.startPoint.position;
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
        if (this.currentTimeOfDay > SECOND_IN_DAY / 4 && this.currentTimeOfDay < SECOND_IN_DAY / 4 * 3)
        {
            this.sun.position = this.DeCasteljausAlgorithm((this.currentTimeOfDay - SECOND_IN_DAY / 4) / (SECOND_IN_DAY / 2),
                this.startPoint.position, this.controlPointLeft.position, this.controlPointRight.position, this.endPoint.position);
        }
        else
        {
            Vector3 p;
            if (this.currentTimeOfDay < SECOND_IN_DAY / 4)
            {
                p = this.DeCasteljausAlgorithm((this.currentTimeOfDay + (SECOND_IN_DAY / 4)) / (SECOND_IN_DAY / 2),
                          this.startPoint.position, this.controlPointLeft.position, this.controlPointRight.position, this.endPoint.position);
            }
            else
            {
                p = this.DeCasteljausAlgorithm((this.currentTimeOfDay - (SECOND_IN_DAY / 4 * 3)) / (SECOND_IN_DAY / 2),
                            this.startPoint.position, this.controlPointLeft.position, this.controlPointRight.position, this.endPoint.position);
            }
            this.sun.position = -p;//Vector3.Reflect(p, Vector3.right);
        }
    }

    public void ChangeTime()
    {
        this.currentTimeOfDay += Time.deltaTime * this.speed;
        if (this.currentTimeOfDay > SECOND_IN_DAY)
        {
            this.days += 1;
            this.currentTimeOfDay = this.currentTimeOfDay % SECOND_IN_DAY;
        }
        this.timetext.text = TimeSpan.FromSeconds(this.currentTimeOfDay).ToString();

        this.SunTransform.rotation = Quaternion.Euler(new Vector3((this.currentTimeOfDay - SECOND_IN_DAY / 4) / SECOND_IN_DAY * 360, 0, 0));

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
