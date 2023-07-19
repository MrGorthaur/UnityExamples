using System;
using UnityEngine;

public class PlayerIKAnimation : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _rightHandWeight;
    [SerializeField] private Transform _grabTarget;
    [SerializeField, Range(0, 1)] private float _switchWeight;
    [SerializeField] private Transform _basketTarget;
    [SerializeField, Range(0, 1)] private float _switchFinalWeight;
    [SerializeField] private Transform _basketFinalTarget;
    [SerializeField] private Transform _hintTarget;
    private Animator _animator;

    public Transform GrabTarget { get => _grabTarget; set => _grabTarget = value; }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void GrabAnimation()
    {
        _animator.SetTrigger("Grab");
    }
    public void WinAnimation()
    {
        Destroy(_basketTarget.gameObject);
        _animator.SetLayerWeight(1, 0f);
        _animator.SetTrigger("Victory");
    }
    private void OnAnimatorIK()
    {
        GrabIKAnimation();
        BasketHolderIKAnimation();

    }
    private void GrabIKAnimation()
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, _rightHandWeight);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, _grabTarget.position);
        
        _animator.SetIKHintPositionWeight(AvatarIKHint.RightElbow, 1f);
        _animator.SetIKHintPosition(AvatarIKHint.RightElbow, _hintTarget.position);
        if (_rightHandWeight > 0.9f)
            SwitchBetweenTargets();
        _animator.ResetTrigger("Grab");
    }
    private void BasketHolderIKAnimation()
    {
        if (_basketTarget != null)
        {
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _basketFinalTarget.position);
        }
    }
    private void SwitchBetweenTargets()
    {
        Vector3 interpolatedPosition = Vector3.Lerp(
            _grabTarget.position,
            _basketTarget.position,
            _switchWeight);

        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, interpolatedPosition);
        SwitchBetweenFinalTargets();
    }
    private void SwitchBetweenFinalTargets()
    {
        Vector3 interpolatedPosition = Vector3.Lerp(
            _basketTarget.position,
            _basketFinalTarget.position,
            _switchFinalWeight);

        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _animator.SetIKPosition(AvatarIKGoal.RightHand, interpolatedPosition);
    }
}

