using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleConstructor : MonoBehaviour
{
    public static PeopleConstructor Instance { get; private set; }

    [SerializeField] private Sprite[] _maleBodySprites;
    [SerializeField] private Sprite[] _femaleBodySprites;
    [SerializeField] private Sprite[] _maleHeadSprites;
    [SerializeField] private Sprite[] _femaleHeadSprites;
    [SerializeField] private Sprite[] _employeeBodySprites;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("SingletonError");
            return;
        }
        Instance = this;
    }

    public Dictionary<BodyPart, Sprite> GetRandomEmployeeSprites()
    {
        Sprite[] headSprites = new Sprite[1];
        switch (Random.Range(0, 1)) 
        {
            case 0:
                {
                    headSprites = _femaleHeadSprites;
                    break;
                }
            case 1:
                {
                    headSprites = _maleHeadSprites;
                    break;
                }
        }

        return Construct(headSprites[Random.Range(0, headSprites.Length)], _employeeBodySprites[Random.Range(0, _employeeBodySprites.Length)]);
    }

    public Dictionary<BodyPart, Sprite> GetRandomGuestSprites()
    {
        Sprite[] headSprites = new Sprite[1];
        Sprite[] bodySprites = new Sprite[1];
        switch (Random.Range(0, 2))
        {
            case 0:
                {
                    headSprites = _femaleHeadSprites;
                    bodySprites = _femaleBodySprites;
                    break;
                }
            case 1:
                {
                    headSprites = _maleHeadSprites;
                    bodySprites = _maleBodySprites;
                    break;
                }
        }

        return Construct(headSprites[Random.Range(0, headSprites.Length)], bodySprites[Random.Range(0, bodySprites.Length)]);
    }

    public Dictionary<BodyPart, Sprite> Construct(Sprite head, Sprite body)
    {
        Dictionary<BodyPart, Sprite> sprites = new Dictionary<BodyPart, Sprite>();
        sprites.Add(BodyPart.Head, head);
        sprites.Add(BodyPart.Body, body);

        return sprites;
    }

    public enum BodyPart 
    { 
        Head,
        Body
    }
}
