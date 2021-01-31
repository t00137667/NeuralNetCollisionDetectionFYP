using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ObserverScript : MonoBehaviour
{
    public GameObject[] objects;
    private List<DataEntry> DataEntries = new List<DataEntry>(10000);
    private bool output = true;
    private CubeOneMovement cube;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        objects = GameObject.FindGameObjectsWithTag("CubeObject");
        cube = FindObjectOfType<CubeOneMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(objects[0].name + " rotation: " + objects[0].transform.rotation.ToString());
        //Debug.Log(objects[1].name + " rotation: " + objects[1].transform.rotation.ToString());
        //Debug.Log(objects[0].name + " position: " + objects[0].transform.position.ToString());
        //Debug.Log(objects[1].name + " position: " + objects[1].transform.position.ToString());
        Debug.Log("Observer Update");

        if (DataEntries.Count < DataEntries.Capacity)
        {
            DataEntries.Add(new DataEntry(objects[0].transform, objects[1].transform, cube.IsColliding));
        }
        if (DataEntries.Count == DataEntries.Capacity && output)
        {
            output = false;
            SaveToFile();
        }
    }

    public void SaveToFile()
    {
        var content = ToCSV();
        var folder = Application.persistentDataPath;
        var filePath = Path.Combine(folder, "export.csv");
        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }

        Debug.Log($"CSV file written to /" + filePath + "/");
    }

    public string ToCSV()
    {
        var fileString = new StringBuilder("PositionA_X,PositionA_Y,PositionA_Z," + 
            "PositionB_X,PositionB_Y,PositionB_Z," + 
            "RotationA_X,RotationA_Y,RotationA_Z,RotationA_W," +
            "RotationB_X,RotationB_Y,RotationB_Z,RotationB_W," +
            "ScaleA_X,ScaleA_Y,ScaleA_Z," +
            "ScaleB_X,ScaleB_Y,ScaleB_Z," +
            "IsColliding");
        foreach(var entry in DataEntries)
        {
            fileString.AppendLine();
            fileString.Append(entry.PositionA_X.ToString()).Append(",");
            fileString.Append(entry.PositionA_Y.ToString()).Append(",");
            fileString.Append(entry.PositionA_Z.ToString()).Append(",");

            fileString.Append(entry.PositionB_X.ToString()).Append(",");
            fileString.Append(entry.PositionB_Y.ToString()).Append(",");
            fileString.Append(entry.PositionB_Z.ToString()).Append(",");

            fileString.Append(entry.RotationA_X.ToString()).Append(",");
            fileString.Append(entry.RotationA_Y.ToString()).Append(",");
            fileString.Append(entry.RotationA_Z.ToString()).Append(",");
            fileString.Append(entry.RotationA_W.ToString()).Append(",");

            fileString.Append(entry.RotationB_X.ToString()).Append(",");
            fileString.Append(entry.RotationB_Y.ToString()).Append(",");
            fileString.Append(entry.RotationB_Z.ToString()).Append(",");
            fileString.Append(entry.RotationB_W.ToString()).Append(",");

            fileString.Append(entry.ScaleA_X.ToString()).Append(",");
            fileString.Append(entry.ScaleA_Y.ToString()).Append(",");
            fileString.Append(entry.ScaleA_Z.ToString()).Append(",");

            fileString.Append(entry.ScaleB_X.ToString()).Append(",");
            fileString.Append(entry.ScaleB_Y.ToString()).Append(",");
            fileString.Append(entry.ScaleB_Z.ToString()).Append(",");

            fileString.Append(entry.IsColliding.ToString()).Append(",");
        }
        return fileString.ToString();
    }
    [Serializable]
    public class DataEntry
    {
        public float PositionA_X;
        public float PositionA_Y;
        public float PositionA_Z;

        public float PositionB_X;
        public float PositionB_Y;
        public float PositionB_Z;

        public float RotationA_X;
        public float RotationA_Y;
        public float RotationA_Z;
        public float RotationA_W;

        public float RotationB_X;
        public float RotationB_Y;
        public float RotationB_Z;
        public float RotationB_W;

        public float ScaleA_X;
        public float ScaleA_Y;
        public float ScaleA_Z;

        public float ScaleB_X;
        public float ScaleB_Y;
        public float ScaleB_Z;

        public bool IsColliding;

        public DataEntry() { }

        public DataEntry(
            Transform cubeOne,
            Transform cubeTwo,
            bool isColliding)
        {
            PositionA_X = cubeOne.position.x;
            PositionA_Y = cubeOne.position.y;
            PositionA_Z = cubeOne.position.z;

            PositionB_X = cubeTwo.position.x;
            PositionB_Y = cubeTwo.position.y;
            PositionB_Z = cubeTwo.position.z;

            RotationA_X = cubeOne.rotation.x;
            RotationA_Y = cubeOne.rotation.y;
            RotationA_Z = cubeOne.rotation.z;
            RotationA_W = cubeOne.rotation.w;

            RotationB_X = cubeTwo.rotation.x;
            RotationB_Y = cubeTwo.rotation.y;
            RotationB_Z = cubeTwo.rotation.z;
            RotationB_W = cubeTwo.rotation.w;

            ScaleA_X = cubeOne.localScale.x;
            ScaleA_Y = cubeOne.localScale.y;
            ScaleA_Z = cubeOne.localScale.z;

            ScaleB_X = cubeTwo.localScale.x;
            ScaleB_Y = cubeTwo.localScale.y;
            ScaleB_Z = cubeTwo.localScale.z;

            IsColliding = isColliding;
        }
    }
}
