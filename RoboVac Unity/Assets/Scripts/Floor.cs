﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    
    Roomba roomba = null;
    public GameObject room;
    private Room _room;

    // Start is called before the first frame update
    void Start()
    {
        _room = room.GetComponent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if(roomba == null)
        {
            roomba = GameObject.FindGameObjectWithTag("roomba").GetComponent<Roomba>();
        }
        else if(Object.FindObjectOfType<Simulation>().IsPlaying())
        {
            if(other.gameObject.tag == "whiskers")
            {
                _room.VacuumCell(roomba);
            }
            else if(other.gameObject.tag == "vacuum")
            {
                _room.WhiskerCell(roomba);
            }
        }

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.gameObject.tag;

        if (tag.Equals("North") ||
            tag.Equals("South") ||
            tag.Equals("West") ||
            tag.Equals("East"))
        {
            Debug.Log("Found a wall");
        }
    }

}
