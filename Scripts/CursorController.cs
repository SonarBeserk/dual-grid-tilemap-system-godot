using Godot;

public partial class CursorController : Node2D {
    [Export] DualGridTilemap dualGridTilemap;
    public override void _Process(double delta) {
        Vector2I coords = dualGridTilemap.LocalToMap(Position);
        if (Input.IsActionPressed("left_click")) {
            dualGridTilemap.SetTile(coords, dualGridTilemap.dirtPlaceholderAtlasCoord);
        } else if (Input.IsActionPressed("right_click")) {
            dualGridTilemap.SetTile(coords, dualGridTilemap.grassPlaceholderAtlasCoord);
        }
    }

    public override void _PhysicsProcess(double delta) {
        GlobalPosition = GetWorldPosTile(GetGlobalMousePosition()) + new Vector2(16, 16);
    }

    public static Vector2I GetWorldPosTile(Vector2 worldPos) {
        int xInt = Mathf.FloorToInt(worldPos.X / 32) * 32;
        int yInt = Mathf.FloorToInt(worldPos.Y / 32) * 32;
        Vector2I result = new(xInt, yInt);
        return result;
    }
}
