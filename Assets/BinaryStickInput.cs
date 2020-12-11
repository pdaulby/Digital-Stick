using System;
using UnityEngine;

public class BinaryStickInput
{
    public float HorizontalRatio { get; private set; }
    public float VerticalRatio { get; private set; }
    public float Deadzone { get; private set; }

    public static BinaryStickInput FromAngles(float horizontalAngle, float verticalAngle, float deadzone)
    {
        if (!AllowsAngles(horizontalAngle, verticalAngle)) throw new ArgumentException("angles not allowed");
        if (0 > deadzone || deadzone > 1) throw new ArgumentException("deadzone not between 0 and 1");

        float actualVertical = 90 - (verticalAngle / 2);

        return new BinaryStickInput()
        {
            HorizontalRatio = Mathf.Tan(horizontalAngle * Mathf.Deg2Rad / 2),
            VerticalRatio = Mathf.Tan(actualVertical * Mathf.Deg2Rad),
            Deadzone = deadzone
        };
    }

    public static bool AllowsAngles(float horizontalAngle, float verticalAngle)
    {
        if (horizontalAngle < 0 || verticalAngle < 0) return false;
        if (horizontalAngle + verticalAngle > 180) return false;
        return true;
    }

    public Direction GetDirection(float horizontal, float vertical)
    {
        if (Mathf.Sqrt(horizontal * horizontal + vertical * vertical) < Deadzone) return Direction.Neutral;

        float absX = Mathf.Abs(horizontal);
        float absY = Mathf.Abs(vertical);
        
        Quart quart =
            (absY < absX * HorizontalRatio) ? Quart.Horizontal
            : (absY < absX * VerticalRatio) ? Quart.Diagonal
            : Quart.Vertical;

        if (quart == Quart.Horizontal)
            return horizontal > 0 ? Direction.Right : Direction.Left;
        if (quart == Quart.Vertical)
            return vertical > 0 ? Direction.Up : Direction.Down;
            
        if (vertical > 0)
        {
            return horizontal > 0 ? Direction.UpRight : Direction.UpLeft;
        }
        else
        {
            return horizontal > 0 ? Direction.DownRight : Direction.DownLeft;
        }
    }

    private enum Quart { Horizontal, Diagonal, Vertical }
}
