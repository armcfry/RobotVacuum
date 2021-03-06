using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IResizable
{
    public Vector2 start;
    public Vector2 stop;

    public int width
    {
        get
        {
            return (int)(this.stop.x - this.start.x);
        }
        private set {}
    }

    public int height
    {
        get
        {
            return (int)(this.stop.y - this.start.y);
        }
        private set {}
    }
    
    public Vector2 GetStart()
    {
        return this.start;
    }

    public Vector2 GetStop()
    {
        return this.stop;
    }

    public Vector2 SetStart(Vector2 position)
    {
        this.start.x = Mathf.Round(position.x + 0.5f);
        this.start.y = Mathf.Round(position.y + 0.5f);
        return start;
    }

    public Vector2 SetStop(Vector2 position)
    {
        this.stop.x = Mathf.Round(position.x + 0.5f);
        this.stop.y = Mathf.Round(position.y + 0.5f);
        return stop;
    }

    public Vector2 SetLeft(float position)
    {
        this.start.x = Mathf.Round(position + 0.5f);
        return start;
    }

    public Vector2 SetRight(float position)
    {
        this.stop.x = Mathf.Round(position + 0.5f);
        return stop;
    }

    public Vector2 SetTop(float position)
    {
        this.stop.y = Mathf.Round(position + 0.5f);
        return stop;
    }

    public Vector2 SetBottom(float position)
    {
        this.start.y = Mathf.Round(position + 0.5f);
        return start;
    }

    void Update() {
        this.transform.position = new Vector3(((this.start.x + this.stop.x) / 2f - 0.5f), ((this.start.y + this.stop.y) / 2f - 0.5f), this.transform.position.z);
        this.transform.localScale = new Vector3(this.width, this.height, 1.0f);
    }
}