using System.Linq;
using UnityEditor;
using UnityEngine;

public static class ResetPositionOnlyParent
{
    [MenuItem( "CONTEXT/Transform/Reset Position Only Parent" )]
    private static void Reset( MenuCommand command )
    {
        var parent     = command.context as Transform;
        var tempParent = new GameObject();
        var children   = parent.Cast<Transform>().ToList();

        foreach ( var child in children )
        {
            child.parent = tempParent.transform;
        }

        parent.position = Vector3.zero;

        foreach ( var child in children )
        {
            child.parent = parent;
        }

        GameObject.DestroyImmediate( tempParent );
    }
}
