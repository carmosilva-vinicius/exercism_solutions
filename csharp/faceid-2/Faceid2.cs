using System;
using System.Collections.Generic;
using System.Linq;

public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods

    public override bool Equals(object obj)
    {
        return obj is FacialFeatures features &&
            EyeColor == features.EyeColor &&
            PhiltrumWidth == features.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }

    public override bool Equals(object obj)
    {
        return obj is Identity identity &&
            Email == identity.Email &&
            FacialFeatures.Equals(identity.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class Authenticator
{
    private readonly List<Identity> _identities = new List<Identity>();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Email == "admin@exerc.ism" &&
        AreSameFace(identity.FacialFeatures, new FacialFeatures("green", 0.9m));
    }

    public bool Register(Identity identity)
    {
        if( !IsRegistered(identity))
        {
            _identities.Add(identity);
            return true;
        }
        return false;
    }

    public bool IsRegistered(Identity identity)
    {
        return _identities.Any(i => i.Equals(identity));
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA.GetHashCode() == identityB.GetHashCode();
    }
}
