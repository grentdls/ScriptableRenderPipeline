using System;
using System.Linq;
using UnityEngine;

namespace UnityEditor.VFX
{
    [VFXInfo(category = "Geometry")]
    class VFXOperatorDistanceToSphere : VFXOperator
    {
        public class InputProperties
        {
            [Tooltip("The sphere used for the distance calculation.")]
            public Sphere sphere = new Sphere();
            [Tooltip("The position used for the distance calculation.")]
            public Position position = new Position();
        }

        override public string name { get { return "Distance (Sphere)"; } }

        override protected VFXExpression[] BuildExpression(VFXExpression[] inputExpression)
        {
            VFXExpression sphereDelta = new VFXExpressionSubtract(inputExpression[0], inputExpression[2]);
            VFXExpression sphereDistance = new VFXExpressionSubtract(VFXOperatorUtility.Length(sphereDelta), inputExpression[1]);
            VFXExpression pointOnSphere = new VFXExpressionAdd(inputExpression[2], VFXOperatorUtility.Normalize(sphereDelta));
            return new VFXExpression[] { pointOnSphere, sphereDistance };
        }
    }
}
