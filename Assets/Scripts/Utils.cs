using UnityEngine;
using System;
using System.Collections.Generic;

public static class Utils {
    public static Rect Add(this Rect source, Vector2 displacement) {
        return new Rect(source.x + displacement.x, source.y + displacement.y, source.width, source.height);
    }
    public static Rect RightBottom(this Rect source, Vector2 corner) {
        return new Rect(corner.x - source.width, corner.y - source.height, source.width, source.height);
    }
    public static Rect Rect(float width, float height) {
        return new Rect(0, 0, width, height);
    }
    public static Rect Rect(this Vector2 size) {
        return new Rect(0, 0, size.x, size.y);
    }
    public static Rect Rect(this Vector2 source, Vector2 size) {
        return new Rect(source.x, source.y, size.x, size.y);
    }
}
