using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	#region Public Fields

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Jump;

    public float WalkSpeed;
    public float JumpSpeed;

    public GameObject Model;


    public int Score { get; set; }

	#endregion	
	#region Private Fields	

    private Rigidbody _rigidBody;
    private GroundChecker _groundChecker;


    public BoxCollider BoxCollider { get; set; }

	#endregion
	#region Events

    void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _groundChecker = GetComponent<GroundChecker>();
        BoxCollider = GetComponent<BoxCollider>();

        // TODO: if time
        //CombineBounds();        
    }

	void Start() 
	{
	
	}

	void Update() 
	{
	    if (Input.GetKey(Left))
	    {
	        transform.Translate(new Vector3(-WalkSpeed, 0, 0) * Time.deltaTime);
	        Model.transform.rotation = Quaternion.Euler(0, 180, 0);
	    }
        else if (Input.GetKey(Right))
        {
            transform.Translate(new Vector3(WalkSpeed, 0, 0) * Time.deltaTime);
            Model.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        HorizontalMovement();
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            if (c.gameObject.tag == "Candy")
            {                
                Score += 100;
                AudioManager.Instance.Play(GameManager.Instance.PlayerCollecetCandySfx, transform.position);
            }
            else if (c.gameObject.tag == "Fruit")
            {
                Score -= 50;
                AudioManager.Instance.Play(GameManager.Instance.PlayerCollectFruitSfx, transform.position);
            }

            Destroy(c.gameObject);
        }
    }

    #endregion

    #region Private Methods

    private void HorizontalMovement()
    {
        if (Input.GetKeyDown(Jump))
        {
            if (_groundChecker.IsGrounded)
            {
                _rigidBody.AddForce(Vector3.up * JumpSpeed);
                AudioManager.Instance.Play(GameManager.Instance.PlayerJumpsSfx[Random.Range(0, GameManager.Instance.PlayerJumpsSfx.Length)], transform.position);
            }
        }
    }

    private void CombineBounds()
    {
        var combinedBounds = new Bounds();
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var render in renderers)
        {
            combinedBounds.Encapsulate(render.bounds);
        }

        BoxCollider.size = combinedBounds.extents;
        BoxCollider.center = combinedBounds.center;
    }

    #endregion
}
