
using System;

/// <summary>
/// Repr�sente une instance pouvant contenir, ajouter ou retirer des objets dans un stokage limit�.
/// Impl�mente l'interface Storable ainsi que toutes ses m�thodes.
/// </summary>
public class Panier : Storable {

    #region ATTRIBUTS
    /// <summary>
    /// Identifiant de l'intance <c>Panier</c>
    /// </summary>
    protected int _id;

    /// <summary>
    /// Capcait� maximum de l'intance <c>Panier</c>
    /// </summary>
    protected uint _capacity;

    /// <summary>
    /// Nombre d'objet contenu par l'intance <c>Panier</c> 
    /// </summary>
    protected uint _nbObject;
    #endregion

    #region GETSET
    /// <summary>
    /// Permet de modifier l'id de l'intance
    /// </summary>
    public int Id {
        get { return _id; }
        set { _id = value; }
    }

    /// <summary>
    /// Permet de modifier la capacit� de l'intance
    /// </summary>
    public uint Capacity {
        get { return _capacity; }
        set { _capacity = value; }
    }

    public uint NbObject {
        get { return _nbObject; }
        set
        {
            if (NbObject > _capacity)
                throw new ArgumentOutOfRangeException();
            _nbObject = value;
        }
    }
    #endregion

    #region CONSTRUCTORS
    public Panier(int id, uint capacity, uint nbObject)
    {
        _id = id;
        Capacity = capacity;
        NbObject = nbObject;

    }

    public Panier(int id, uint capacity):
        this(id,capacity,0)
    {}

    #endregion

    public void Add()
    {
        if (_nbObject >= Capacity)
            throw new NotImplementedException();
    }

    public void Take()
    {
        throw new NotImplementedException();
    }

    public int Count()
    {
        return (int)_nbObject;
    }
}