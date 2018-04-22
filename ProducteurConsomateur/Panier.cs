
using System;

/// <summary>
/// Représente une instance pouvant contenir, ajouter ou retirer des objets dans un stokage limité.
/// Implémente l'interface Storable ainsi que toutes ses méthodes.
/// </summary>
public class Panier : Storable {

    #region ATTRIBUTS
    /// <summary>
    /// Identifiant de l'intance <c>Panier</c>
    /// </summary>
    protected int _id;

    /// <summary>
    /// Capcaité maximum de l'intance <c>Panier</c>
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
    /// Permet de modifier la capacité de l'intance
    /// </summary>
    public uint Capacity {
        get { return _capacity; }
        set { _capacity = value; }
    }

    /// <summary>
    /// Permet de modifier le nombre d'objets contenu par l'intance
    /// </summary>
    public uint NbObject {
        get { return _nbObject; }
        set
        {
            if (NbObject > _capacity)
                throw new ArgumentOutOfRangeException("le nombre d'objet précisé est supérieur à la capacité","nbObject");
            _nbObject = value;
        }
    }
    #endregion

    #region CONSTRUCTORS
    /// <summary>
    /// Permet de créer une nouvelle intance de <c>Panier</c> en précisant son id,
    /// sa capacitée et son nombre d'objet au début. 
    /// </summary>
    /// <param name="id">Identifiant de l'intance</param>
    /// <param name="capacity">Nombre d'objet maximum que peux contenir l'instance</param>
    /// <param name="nbObject">Nombre d'objet contenue par l'instance au début</param>
    /// <remarks><c>nbObject</c> doit etre inférieur ou égal à <c>capacity</c> </remarks>
    /// <exception cref="ArgumentOutOfRangeException"
    public Panier(int id, uint capacity, uint nbObject)
    {
        _id = id;
        Capacity = capacity;
        NbObject = nbObject;

    }

    /// <summary>
    /// Permet de créer une nouvelle intance de <c>Panier</c> en précisant son id et
    /// sa capacitée.
    /// </summary>
    /// <param name="id">Identifiant de l'intance</param>
    /// <param name="capacity">Nombre d'objet maximum que peux contenir l'instance</param>
    public Panier(int id, uint capacity):
        this(id,capacity,0)
    {}

    #endregion

    /// <summary>
    /// Permet d'ajouter un objet dans le stokage de l'intance <c>Panier</c> 
    /// </summary>
    /// <remarks>Retourne une exception si la capacité a déja était atteinte</remarks>
    /// <exception cref="AddObjectException"
    public void Add()
    {
        if (_nbObject >= Capacity)
            throw new AddObjectException("Impossible d'ajouter un objet, la capacité a déja était atteinte");
        _nbObject++;
    }

    /// <summary>
    /// Permet de prendre un objet dans le stokage de l'intance <c>Panier</c> 
    /// </summary>
    /// <remarks>Retourne une exception si il n'y à plus d'objet</remarks>
    /// <exception cref="TakeObjectException"
    public void Take()
    {
        if (_nbObject <= 0)
            throw new TakeObjectException("Impossible, il n'y à plus d'objet à enlever dans le stokage");
        _nbObject--;
    }

    /// <summary>
    /// Permet de connaitre le nombre d'objet contenu dans le stokage de l'instance
    /// </summary>
    /// <returns>Retourne le nombre d'objet</returns>
    public int Count()
    {
        return (int)_nbObject;
    }

    /// <summary>
    /// Vide le stokage de l'intance
    /// </summary>
    public void Clean()
    {
        _nbObject = 0;
    }

    /// <summary>
    /// Permet de savoir si le stokage est vide
    /// </summary>
    /// <returns>retourne <c>true</c> si le stokage est vide, sinon <c>false</c></returns>
    public bool IsEmpty()
    {
        if (_nbObject <= 0)
            return true;
        return false;
    }

    /// <summary>
    /// Permet de savoir si le stokage est plein
    /// </summary>
    /// <returns>retourne <c>true</c> si le stokage est plein, sinon <c>false</c></returns>
    public bool IsFull()
    {
        if (_nbObject >= _capacity)
            return true;
        return false;
    }
}