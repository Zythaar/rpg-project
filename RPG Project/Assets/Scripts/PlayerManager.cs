using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
    #region Singleton
    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;    
    }
    #endregion

    public GameObject player;

    // Use this for initialization
    private void Start () 
	{
		
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}
}
