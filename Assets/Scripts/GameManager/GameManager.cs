using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    

    public Flask flask;
    public IceBomb icebomb;

    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    

    public void ObtainFlaskDamage(Flask flask)
    {
        this.flask = flask;
    }

    public void ObtainIceDamage(IceBomb icebomb)
    {
        this.icebomb = icebomb;
    }
}
