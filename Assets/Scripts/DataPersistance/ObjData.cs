using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class ObjData
{
    public ObjDataPos pos = new ObjDataPos();
    public ObjDataRot rot = new ObjDataRot();
    public ObjDataScale scale = new ObjDataScale();
    public ObjDataColor color = new ObjDataColor();
}
[Serializable]
public class ObjDataPos
{
    public float x, y, z;
}
[Serializable]
public class ObjDataRot
{
    public float x, y, z;
}
[Serializable]
public class ObjDataScale
{
    public float x, y, z;
}
[Serializable]
public class ObjDataColor
{
    public float r, g, b, a;
}

