using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _rangeSpread += Random.Range(-_transitionRange, _transitionRange);
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) < _rangeSpread)
        {
            NeedTransit = true;
        }

    }
}
