using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _tapForce = 100;
	[SerializeField] private float _rotationSpeed;
	[SerializeField] private float _maxRotationZ;
	[SerializeField] private float _minRotationZ;

	private float _startSpeed = 3;

    private float _currentSpeed;
    private Rigidbody2D _rigidBody;
	private Quaternion _maxRotation;
	private Quaternion _minRotation;

	private void Start()
	{
		_rigidBody = GetComponent<Rigidbody2D>();

		_maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
		_minRotation = Quaternion.Euler(0, 0, _minRotationZ);

		ResetBird();
	}

	private void Update()
	{
		_currentSpeed += (Time.deltaTime) / 50f;
		if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale > 0)
		{
			_rigidBody.velocity = new Vector2(_currentSpeed, 0);
			transform.rotation = _maxRotation;
			_rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
		}
		transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
	}

	public void ResetBird()
	{
		transform.position = _startPosition;
		transform.rotation = Quaternion.Euler(0,0,0);
		_rigidBody.velocity = Vector2.zero;
		_currentSpeed = _startSpeed;
	}
}
