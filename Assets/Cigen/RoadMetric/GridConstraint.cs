﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cigen.MetricConstraint;
using System;

/// <summary>
/// Aligns intersection points to be on grid nodes. Check CitySettings for grid spacing params.
/// </summary>
public class GridConstraint : ManhattanConstraint {
    public GridConstraint(CitySettings settings) : base(settings) { }

    public Vector3 RoundToScale(Vector3 v) {
        float scale = settings.minimumRoadLength;
        Func<float, float> rts = i => Mathf.Round(i/scale)*scale; //round to scale
        return new Vector3(rts(v.x), rts(v.y), rts(v.z));
    }

    public override Vector3[] ProcessPoints(params Vector3[] points)
    {
        Vector3[] ret = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++) {
            ret[i] = RoundToScale(points[i]);
        }

        return ret;
    }
}
