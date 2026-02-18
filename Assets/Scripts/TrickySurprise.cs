using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TrickySurprise : MonoBehaviour
{
    [SerializeField] GameObject _canvas;
    [SerializeField] private AudioClip _audioclip;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private string _nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (_audioclip != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(_audioclip );
            }
            _canvas.SetActive(true);
            
            StartCoroutine(FinishGame());
            
        }
    }


    private IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(2.5f);

        SceneManager.LoadScene(_nextSceneName);
    }

}
