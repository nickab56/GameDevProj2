using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public GameObject RoomCornerBasic;
    public GameObject RoomBottomLeftCorner;
    public GameObject RoomBottomRightCorner;
    public GameObject RoomCornerLeft;
    public GameObject Room0101;
    public GameObject Room1111;
    public GameObject RoomCircle1111;
    public GameObject RoomBroken1011;
    public GameObject Room1110;
    public GameObject StartRoom;
    public GameObject EndRoom;
    


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
        StartRoom = Instantiate(StartRoom);
        StartRoom.transform.position = new Vector3(0, -92, 0);

        RoomOne = Instantiate(RoomCornerLeft);
        RoomOne.transform.position = new Vector3(-46, 46, 0);

        RoomTwo = Instantiate(Room1111);
        RoomTwo.transform.position = new Vector3(0, 46, 0);

        RoomThree = Instantiate(RoomCornerBasic);
        RoomThree.transform.position = new Vector3(46, 46, 0);

        RoomFour = Instantiate(Room1110);
        RoomFour.transform.position = new Vector3(-46, 0, 0);

        RoomFive = Instantiate(Room0101);
        RoomFive.transform.position = Vector3.zero;

        RoomSix = Instantiate(RoomBroken1011);
        RoomSix.transform.position = new Vector3(46, 0, 0);

        RoomSeven = Instantiate(RoomBottomLeftCorner);
        RoomSeven.transform.position = new Vector3(-46, -46, 0);

        RoomEight = Instantiate(RoomCircle1111);
        RoomEight.transform.position = new Vector3(0, -46, 0);

        RoomNine = Instantiate(RoomBottomRightCorner);
        RoomNine.transform.position = new Vector3(46, -46, 0);

        EndRoom = Instantiate(EndRoom);
        EndRoom.transform.position = new Vector3(0, 92, 0);



    }
}
