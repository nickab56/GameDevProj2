using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public GameObject CornerOne;
    public GameObject CornerTwo;
    public GameObject CornerThree;
    public GameObject CornerFour;
    public GameObject FourSidesOne;
    public GameObject FourSideTwo;
    public GameObject FourSideThree;


    // The Acutally Rooms
    private GameObject RoomOne;
    private GameObject RoomTwo;
    private GameObject RoomThree;       //  1|2|3
    private GameObject RoomFour;        //  4|5|6
    private GameObject RoomFive;        //  7|8|9
    private GameObject RoomSix;
    private GameObject RoomSeven;
    private GameObject RoomEight;
    private GameObject RoomNine;

    void Start()
    {
        RoomFive = Instantiate(FourSidesOne);
        RoomFive.transform.position = Vector3.zero;
        RoomSix = Instantiate(CornerOne);
        RoomSix.transform.position = new Vector3(9, 0, 0);
        RoomThree = Instantiate(CornerTwo);
        RoomThree.transform.position = new Vector3(9, 9, 0);


    }
}
