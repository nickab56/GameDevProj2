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
    public GameObject RoomCorner2;
    public GameObject Rooomswirl1111;
    public GameObject BlankRoom;
    public GameObject Key;
    


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
    private int temp = 0;

    void Start()
    {
        StartRoom = Instantiate(StartRoom);
        StartRoom.transform.position = new Vector3(0, -92, 0);

        temp = Random.Range(0, 4);
        if (temp == 0)
            RoomOne = Instantiate(Room1111);
        if (temp == 1)
            RoomOne = Instantiate(RoomCornerLeft);
        if (temp == 2)
            RoomOne = Instantiate(RoomCircle1111);
        if (temp == 3)
            RoomOne = Instantiate(Rooomswirl1111);
        RoomOne.transform.position = new Vector3(-46, 46, 0);
        
        temp = Random.Range(0, 2);
        if (temp == 0)
            RoomTwo = Instantiate(Room1111);
        if (temp == 1)
            RoomTwo = Instantiate(Rooomswirl1111);
        RoomTwo.transform.position = new Vector3(0, 46, 0);

        temp = Random.Range(0, 4);
        if (temp == 0)
            RoomThree = Instantiate(RoomCornerBasic);
        if (temp == 1)
            RoomThree = Instantiate(RoomCorner2);
        if (temp == 2)
            RoomThree = Instantiate(RoomCircle1111);
        if (temp == 3)
            RoomThree = Instantiate(Rooomswirl1111);
        RoomThree.transform.position = new Vector3(46, 46, 0);

        temp = Random.Range(0, 3);
        if (temp == 0)
            RoomFour = Instantiate(Room1110);
        if (temp == 1)
            RoomFour = Instantiate(RoomBottomLeftCorner);
        if (temp == 2)
            RoomFour = Instantiate(RoomCircle1111);
        RoomFour.transform.position = new Vector3(-46, 0, 0);

        temp = Random.Range(0, 3);
        if(temp == 0)
            RoomFive = Instantiate(RoomBottomRightCorner);
        if (temp == 1)
            RoomFive = Instantiate(RoomCircle1111);
        if (temp == 2)
            RoomFive = Instantiate(Rooomswirl1111);
        RoomFive.transform.position = Vector3.zero;

        temp = Random.Range(0, 4);
        if (temp == 0)
            RoomSix = Instantiate(Room1110);
        if (temp == 1)
            RoomSix = Instantiate(RoomBroken1011);
        if (temp == 2)
            RoomSix = Instantiate(RoomCircle1111);
        if (temp == 3)
            RoomSix = Instantiate(Rooomswirl1111);
        RoomSix.transform.position = new Vector3(46, 0, 0);

        temp = Random.Range(0, 3);
        if (temp == 0)
            RoomSeven = Instantiate(Room0101);
        if (temp == 1)
            RoomSeven = Instantiate(RoomCircle1111);
        if (temp == 2)
            RoomSeven = Instantiate(Rooomswirl1111);
        RoomSeven.transform.position = new Vector3(-46, -46, 0);

        temp = Random.Range(0, 4);
        if (temp == 0)
            RoomEight = Instantiate(Room1110);
        if (temp == 1)
            RoomEight = Instantiate(RoomCornerLeft);
        if (temp == 2)
            RoomEight = Instantiate(RoomCircle1111);
        if (temp == 3)
            RoomEight = Instantiate(Rooomswirl1111);
        RoomEight.transform.position = new Vector3(0, -46, 0);

        temp = Random.Range(0, 3);
        if (temp == 0)
            RoomNine = Instantiate(Room1111);
        if (temp == 1)
            RoomNine = Instantiate(RoomBottomRightCorner);
        if (temp == 2)
            RoomNine = Instantiate(RoomCircle1111);
        RoomNine.transform.position = new Vector3(46, -46, 0);

        EndRoom = Instantiate(EndRoom);
        EndRoom.transform.position = new Vector3(0, 92, 0);

        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(46, 92, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(-46, 92, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(46, -92, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(-46, -92, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(92, 46, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(92, 0, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(92, -46, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(-92, 46, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(-92, 0, 0);
        BlankRoom = Instantiate(BlankRoom);
        BlankRoom.transform.position = new Vector3(-92, -46, 0);

        Key = Instantiate(Key);
        temp = Random.Range(0, 5);
        if (temp == 0)
            Key.transform.position = new Vector3(46, -23, -1);
        if (temp == 1)
            Key.transform.position = new Vector3(23, 46, -1);
        if (temp == 2)
            Key.transform.position = new Vector3(-23, 46, -1);
        if (temp == 3)
            Key.transform.position = new Vector3(-46, 23, -1);
        if (temp == 4)
            Key.transform.position = new Vector3(-23, 0, -1);
    }
}
