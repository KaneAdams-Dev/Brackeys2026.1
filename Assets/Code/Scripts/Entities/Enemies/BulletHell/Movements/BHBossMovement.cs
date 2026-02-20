using UnityEngine;

namespace Brackeys2026
{
    public class BHBossMovement : BHMovement
    {
        #region Variables

        [SerializeField] float _xScale = 24;
        [SerializeField] float _yScale = 4;

        [SerializeField] float _xOffset = 0;
        [SerializeField] float _yOffset = 0;

        Vector3 _pivot;
        Vector3 _pivotOffset;
        float _phase;
        bool _isInvert = false;
        private float _circumference = Mathf.PI * 2;

        bool _reachedTarget;

        public bool isLinkOffsetScalePositiveX = false;
        public bool isLinkOffsetScaleNegativeX = false;
        public bool isLinkOffsetScalePositiveZ = false;
        public bool isLinkOffsetScaleNegativeZ = false;

        bool isRunning = false;

        #endregion Variables

        #region Unity Methods

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        override protected void Start() {
            base.Start();

            _pivot = transform.position;
            _reachedTarget = false;
            isRunning = true;
        }

        private void OnEnable() {
            if (isLinkOffsetScalePositiveX)
                _phase = Mathf.PI / 2f + Mathf.PI;
            else if (isLinkOffsetScaleNegativeX)
                _phase = Mathf.PI / 2f;
            else if (isLinkOffsetScalePositiveZ)
                _phase = Mathf.PI;
            else
                _phase = 0;

            _pivot = transform.position;
            _reachedTarget = false;
            isRunning = true;
        }

        void OnDrawGizmos() {
            if (isLinkOffsetScalePositiveX)
                _xOffset = _xScale;
            else if (isLinkOffsetScaleNegativeX)
                _xOffset = _xScale * -1;
            else
                _xOffset = 0;

            if (isLinkOffsetScalePositiveZ)
                _yOffset = _yScale;
            else if (isLinkOffsetScaleNegativeZ)
                _yOffset = _yScale * -1;
            else
                _yOffset = 0;

            if (isRunning) {
                Gizmos.DrawLine(new Vector3(_targetPosition.x + _xOffset, _targetPosition.y, _targetPosition.y + _yScale + _yOffset), new Vector3(_targetPosition.x + _xScale, _targetPosition.y, _targetPosition.y + _yOffset));
                Gizmos.DrawLine(new Vector3(_targetPosition.x + _xOffset, _targetPosition.y, _targetPosition.y - _yScale + _yOffset), new Vector3(_targetPosition.x + _xScale, _targetPosition.y, _targetPosition.y + _yOffset));
                Gizmos.DrawLine(new Vector3(_targetPosition.x + _xScale + _xOffset, _targetPosition.y + _yOffset, _targetPosition.y), new Vector3(_targetPosition.x + _xScale, _targetPosition.y, _targetPosition.y + _yOffset));
                Gizmos.DrawLine(new Vector3(_targetPosition.x - _xScale + _xOffset, _targetPosition.y + _yOffset, _targetPosition.y), new Vector3(_targetPosition.x + _xScale, _targetPosition.y, _targetPosition.y + _yOffset));
            } else {
                Gizmos.DrawLine(new Vector3(transform.position.x + _xOffset, transform.position.y, transform.position.z + _yScale + _yOffset), new Vector3(transform.position.x + _xScale, transform.position.y, transform.position.z + _yOffset));
                Gizmos.DrawLine(new Vector3(transform.position.x + _xOffset, transform.position.y, transform.position.z - _yScale + _yOffset), new Vector3(transform.position.x + _xScale, transform.position.y, transform.position.z + _yOffset));
                Gizmos.DrawLine(new Vector3(transform.position.x + _xScale + _xOffset, transform.position.y, transform.position.z + _yOffset), new Vector3(transform.position.x + _xScale, transform.position.y, transform.position.z + _yOffset));
                Gizmos.DrawLine(new Vector3(transform.position.x - _xScale + _xOffset, transform.position.y, transform.position.z + _yOffset), new Vector3(transform.position.x + _xScale, transform.position.y, transform.position.z + _yOffset));
            }
        }

        #endregion Unity Methods

        #region Custom Methods

        internal override void Move(Transform a_target = null) {
            base.Move(a_target);

            //ColourLogger.Log(this, transform.position.ToString());
            //ColourLogger.Log(this, _targetPosition.ToString());

            //if (transform.position.y > _targetPosition.y) {
            //    _rbdy.linearVelocityY = _enemy.moveSpeed * -1f;
            //} else {
            //    _rbdy.linearVelocityY = 0f;
            //}

            if (transform.position.y > _targetPosition.y && !_reachedTarget) {
                transform.Translate(new Vector3(0, _enemy.moveSpeed * -1 * Time.deltaTime, 0));
            } else {
                _reachedTarget = true;
                FigureOfEight();
            }
        }

        private void FigureOfEight() {
            //ColourLogger.Log(this, "To infinity, and beyond!");

            //_pivotOffset = Vector3.up * 2 * _yScale;

            //_phase += _enemy.moveSpeed * Time.deltaTime;
            //if (_phase > _circumference) {
            //    _isInvert = !_isInvert;
            //    _phase -= _circumference;
            //}
            //if (_phase < 0) {
            //    _phase += _circumference;
            //}

            ////transform.position = _pivot + (_isInvert ? _pivotOffset : Vector2.zero);
            ////transform.position += new Vector3(Mathf.Sin(_phase) * _xScale, Mathf.Cos(_phase) * (_isInvert ? -1 : 1) * _yScale);

            //Vector3 newPos = (Vector3)_targetPosition + (_isInvert ? _pivotOffset : Vector3.zero);
            //transform.position = new Vector3(newPos.x + Mathf.Sin(_phase) * _xScale + _xOffset, newPos.y + Mathf.Cos(_phase) * (_isInvert ? -1 : 1) * _yScale + _yScale, newPos.z);

            transform.position = (Vector3)_targetPosition +
                (Vector3.right * Mathf.Sin(Time.timeSinceLevelLoad / 2 * (_enemy.moveSpeed * 0.5f)) * _xScale -
                Vector3.up * Mathf.Sin(Time.timeSinceLevelLoad * (_enemy.moveSpeed * 0.5f)) * _yScale);
        }

        #endregion Custom Methods
    }
}
