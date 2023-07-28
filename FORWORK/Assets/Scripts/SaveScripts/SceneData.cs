using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SceneData
{
    public string[] objectNames;
    public Hector[] objectPositions;
    public Rotactor[] objectRotations;
    public Scayler[] objectScale;
    public SceneData(Transform parentTransform)
    {
        var childCount = parentTransform.childCount;
        objectNames = new string[childCount];
        objectPositions = new Hector[childCount];
        objectRotations = new Rotactor[childCount];
        objectScale= new Scayler[childCount];

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            Transform currentObject = parentTransform.GetChild(i);

            objectNames[i] = currentObject.name;

            var position = currentObject.position;
            objectPositions[i] = new Hector(position.x, position.y, position.z);

            var rotation = currentObject.rotation;
            objectRotations[i] = new Rotactor(rotation.x, rotation.y, rotation.z, rotation.w);

            var scale = currentObject.localScale;
            objectScale[i] = new Scayler(scale.x,scale.y,scale.z);

        }
    }
    [System.Serializable]
    public class Hector
    {
        public float x;
        public float y;
        public float z;

        public Hector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public class Rotactor
    {
        public float x;
        public float y;
        public float z;
        public float w;
        public Rotactor(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
    [System.Serializable]
    public class Scayler
    {
        public float x;
        public float y;
        public float z;
       
        public Scayler(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
          
        }
    }

}

