public class EnemyAnimation : Animation
{
    private const string IsLookRightParameter = "IsLookRight";

    private EnemyMover _enemyMover;

    private void Start()
    {
        _enemyMover = GetComponent<EnemyMover>();
    }

    public void AnimateRun()
    {
        _animator.SetBool(IsLookRightParameter, _enemyMover.IsLookRight);
    }
}