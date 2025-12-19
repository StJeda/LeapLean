namespace ProjectAssets.Scripts.architecture.mvc.player
{
    public sealed class PlayerModel
    {
        public float Speed { get; set; } = 200f;
        public float JumpForce { get; set; } = 400f;
        public bool IsGrounded { get; set; }
    }
}