public enum Direction
{
    UpLeft, Up, UpRight,
    Left, Neutral, Right,
    DownLeft, Down, DownRight
}

static class DirectionExtensions
{
    public static bool IsLeftward(this Direction duration)
    { return duration == Direction.UpLeft || duration == Direction.Left || duration == Direction.DownLeft; }

    public static bool IsRightward(this Direction duration)
    { return duration == Direction.UpRight || duration == Direction.Right || duration == Direction.DownRight; }

    public static bool IsUpward(this Direction duration)
    { return duration == Direction.UpLeft || duration == Direction.Up || duration == Direction.UpRight; }

    public static bool IsDownward(this Direction duration)
    { return duration == Direction.DownLeft || duration == Direction.Down || duration == Direction.DownRight; }

    public static bool IsNeutralVertically(this Direction duration)
    { return duration == Direction.Left || duration == Direction.Neutral || duration == Direction.Right; }

    public static bool IsNeutralHorizontally(this Direction duration)
    { return duration == Direction.Up || duration == Direction.Neutral || duration == Direction.Down; }
}