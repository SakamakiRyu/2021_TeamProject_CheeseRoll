using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectPlayerCon : MonoBehaviour
{
    [SerializeField]
    public StagePopupController _StagePopupController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * 10f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * 10f * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Stage trigger"))
        {
            
            var namae = collision.GetComponent<stageID>();
            _StagePopupController.PopUp((int)namae._id);
            Debug.Log("in");
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Stage trigger"))
        {
            Debug.Log("out");
        }
    }
}
