using UnityEngine;
using System.Collections;

public class BoardManager : MonoBehaviour
{

    public GameObject floorTile;
    public GameObject wallTile;
    public GameObject pitTile;
    public GameObject ladderTile;

    public int rows;
    public int columns;

    private Transform boardTiles;

    //turned public void SetupBoard to private void SetupBoard since it is only used in Start
    void SetupBoard(int rows = 1, int columns = 1)
    {

        // Makes sure the rows value is greater than 0.
        if (rows > 0)
            this.rows = rows;
        else
            this.rows = 1;
        // Makes sure the columns value is greater than 0.
        if (columns > 0)
            this.columns = columns;
        else
            this.columns = 1;
    }

    // Use this for initialization
    void Start()
    {

        boardTiles = new GameObject("BoardTiles").transform;

        // Assigns values to the column and row variables.
        SetupBoard(9, 9);

        // Adds the floor tiles to the game board.
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Creates a new tile game object at position (i,j).
                GameObject newTile = Instantiate(floorTile, new Vector2(i, j), Quaternion.identity) as GameObject;

                // Adds the new tile to GameObject called 'BoardTiles' to help reduce clutter in the
                // heirarchy.
                newTile.transform.SetParent(boardTiles);
            }
        }

        // Adds the wall tiles around the game board.
        for (int i = -1; i <= rows; i++)
        {
            for (int j = -1; j <= columns; j++)
            {
                if (i == -1 || i == columns || j == -1 || j == columns)
                {
                    GameObject newTile = Instantiate(wallTile, new Vector2(i, j), Quaternion.identity) as GameObject;
                    newTile.transform.SetParent(boardTiles);
                }
            }
        }
    }

    public void LevelSelector(int level)
    {
        //Sets up a board with walls and grass tiles
        //Start();

        //sets the board to the level it corresponds to
        if (level == 1)
            LoadMap1();
        else if (level == 2)
            LoadMap2();
        else if (level == 3)
            LoadMap3();
        else if (level == 4)
            LoadMap4();
        else if (level == 5)
            LoadMap5();
        else if (level == 6)
            LoadMap6();
        else if (level == 7)
            LoadMap7();
        else if (level == 8)
            LoadMap8();
        else if (level == 9)
            LoadMap9();
        else if (level == 10)
            LoadMap10();
    }

    //Create an empty room with a door in the north wall
    void LoadMap1()
    {
        //Puts a ladder by the north wall
        //Instantiate(floorTile, new Vector3(4, 9, -1), Quaternion.identity);
        GameObject newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with curved walls on 3 corners
    void LoadMap2()
    {
        //Sets up upper left wall section
        GameObject newTile = Instantiate(wallTile, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Sets up upper right wall section
        newTile = Instantiate(wallTile, new Vector3(8, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Sets up lower right wall section
        newTile = Instantiate(wallTile, new Vector3(6, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(8, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with a large pillar in the center
    void LoadMap3()
    {
        //Put the Center Pillar in the room
        GameObject newTile = Instantiate(wallTile, new Vector3(4, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with a small path on the left and an area on the right surrounded by pits
    void LoadMap4()
    {
        //sets up top left wall
        GameObject newTile = Instantiate(wallTile, new Vector3(0, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        
        //Sets up bottom left wall
        newTile = Instantiate(wallTile, new Vector3(2, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //sets up pit border on right side
        newTile = Instantiate(pitTile, new Vector3(8, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(7, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(7, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with 3 medium sized pillars in the middle
    void LoadMap5()
    {
        //creates top left pillar
        GameObject newTile = Instantiate(wallTile, new Vector3(2, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //creates right pillar
        newTile = Instantiate(wallTile, new Vector3(7, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(6, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //creates bottom left pillar
        newTile = Instantiate(wallTile, new Vector3(2, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(2, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with a couple islands surrounded by pits
    void LoadMap6()
    {
        //Creates a pit surrounded area on the left
        GameObject newTile = Instantiate(pitTile, new Vector3(0, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);        
        newTile = Instantiate(pitTile, new Vector3(1, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(2, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(1, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(0, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Creates a pit surrounded area on the right side
        newTile = Instantiate(pitTile, new Vector3(6, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(7, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 0, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(8, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(7, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(pitTile, new Vector3(6, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with 3 walls in the room
    void LoadMap7()
    {
        //Puts the left wall in the room
        GameObject newTile = Instantiate(wallTile, new Vector3(1, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts the right wall in the room
        newTile = Instantiate(wallTile, new Vector3(7, 2, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 6, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts the center wall in the room
        newTile = Instantiate(wallTile, new Vector3(4, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with multiple small pillars in the room
    void LoadMap8()
    {
        //Sets up the various pillars
        GameObject newTile = Instantiate(wallTile, new Vector3(1, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts a ladder by the north wall
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room completely covered in pits with a single path running
    //to the exit
    void LoadMap9()
    {
        //covers the room in pits
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                    GameObject pitTiles = Instantiate(pitTile, new Vector3(i, j, -1), Quaternion.identity) as GameObject;
                    pitTiles.transform.SetParent(boardTiles);
            }
        }

        //Sets up the path to the exit
        GameObject newTile = Instantiate(floorTile, new Vector3(0, 0, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(0, 1, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(1, 1, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(2, 1, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(2, 2, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(2, 3, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(3, 3, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 3, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 2, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 1, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 0, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(5, 0, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(6, 0, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 0, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 1, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 2, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 3, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 4, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(6, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(5, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(3, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(2, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(1, 5, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(1, 6, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(1, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(2, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(3, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(4, 8, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Puts 2 random tiles off to the side (maybe for treasure or an enemy)
        newTile = Instantiate(floorTile, new Vector3(6, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(floorTile, new Vector3(7, 7, -2), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);

        //Ladder
        newTile = Instantiate(ladderTile, new Vector3(4, 8, -3), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    //Creates a room with a few small sized pillars (boss room?)
    void LoadMap10()
    {
        //Puts the pillars in the room
        GameObject newTile = Instantiate(wallTile, new Vector3(1, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 7, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 5, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(4, 4, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(3, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(5, 3, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(1, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
        newTile = Instantiate(wallTile, new Vector3(7, 1, -1), Quaternion.identity) as GameObject;
        newTile.transform.SetParent(boardTiles);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
