﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPath : Path
{
    public override void Move(){
        //Debug.Log("Random Move");
        StartCoroutine(RandomMove());
    }

    protected IEnumerator RandomMove(){
        Backoff(-currentDirection.x, -currentDirection.y);
        yield return new WaitForSeconds(.1F);
        //Debug.Log("Stop");
        Stop();

        float randomX = Random.Range(-1F, 1F);
        float randomY = Random.Range(-1F, 1F);

        float angleChange = CalculateAngleChange(randomX, randomY);
        //Debug.Log("Angle change = " + angleChange);

        vacuum.angularVelocity = angularVelocity;

        float waitTime = angleChange / Mathf.Abs(angularVelocity);        
        
        yield return new WaitForSeconds(waitTime);
        vacuum.angularVelocity = 0;

        //Debug.Log("Ready for launch");
        Launch(randomX, randomY);
    }

    protected float CalculateAngleChange(float randomX, float randomY){
        float currentAngle = GetCurrentAngle();

        float newAngle = Mathf.Atan(randomY / randomX) * 180 / Mathf.PI;

        //The new angle will depend on whether the new direction coordinates are each positive or negative
        if(randomX < 0) { //2nd and 3rd quadrant
            newAngle = newAngle + 180;
        } else if (randomY < 0) { //4th quadrant
            newAngle = newAngle + 360;
        } else { //1st quandrant
            //no change needed
        }

        float angleChange = newAngle - currentAngle;

        //Make sure the change is positive
        if(angleChange < 0){
            angleChange = angleChange + 360;
        }

        //Reset the velocity to being positive
        angularVelocity = Mathf.Abs(angularVelocity);

        if(angleChange > 180){
            //Rotate clockwise for a shorter length than it would take to go counterclockwise
            angularVelocity = -1 * angularVelocity;
            angleChange = 360 - angleChange;
        } 

        return angleChange;
    } 
}
