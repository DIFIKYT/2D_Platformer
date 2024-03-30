using UnityEngine;

public class PlayerAnimation : Animation
{
    private const string AnimMoveXParameter = "AnimMoveX";
    private const string HorizontalAxis = "Horizontal";

    public void AnimateMove()
    {
        _animator.SetFloat(AnimMoveXParameter, Input.GetAxis(HorizontalAxis));
    }
}