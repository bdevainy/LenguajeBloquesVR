using UnityEngine;

public class PuzzlePieceInteractableObject : RecyclableObject
{
    Transform _repositionTransform;
    [SerializeField] AudioClip _collisionAudioClip;
    [SerializeField] PuzzlePieceType _pieceType = PuzzlePieceType.right;

    CustomSocketInteractor _socket;
    AudioSource _audioSource;

    private void Awake()
    {
        _repositionTransform = GameObject.FindGameObjectWithTag("Reposition").transform;
        _audioSource = gameObject.GetComponent<AudioSource>();
        _socket = GetComponentInChildren<CustomSocketInteractor>();
        //_socket.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("OutsideBounds")) // if the object is unreacheable to the player return it back to the table
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.transform.position = _repositionTransform.position;
        }

        // _audioSource.PlayOneShot(_collisionAudioClip); // to play audio on collision, deactivated temporarily but should be on final version
    }

    #region Getters / setters etc

    public void ActivateSocket()
    {
        _socket.ActivateSocket();
    }

    public void DeactivateSocket()
    {
        _socket.DeactivateSocket();
    }

    public PuzzlePieceType GetPieceType()
    {
        return _pieceType;
    }

    public void SetFatherLoop(ForLoopPieceBehaviour fatherLoop)
    {
        _socket.SetFatherLoop(fatherLoop);
    }

    public void RemoveFatherLoop()
    {
        _socket.RemoveFatherLoop();
    }
    #endregion
}

public enum PuzzlePieceType { right, left, up, down, forLoop};

