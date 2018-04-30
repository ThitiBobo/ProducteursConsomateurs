
namespace ProducteurConsomatteur
{
	/// <summary>
    /// Représente un objet pouvant contenir, ajouter ou retirer des objets dans un stokage 
    /// </summary>
    public interface Storable {

        /// <summary>
        /// Permet d'obtenir le nom/identifiant du storage
        /// </summary>
        /// <returns>retourne le nom sous de string</returns>
        string GetName();

        /// <summary>
        /// Permet d'ajouter un ojbet dans le stokage
        /// </summary>
        void Add();

        /// <summary>
        /// Permet de retirer un objet dans le stokage
        /// </summary>
        void Take();

        /// <summary>
        /// Retourne le nombre d'objet contenu dans le stokage
        /// </summary>
        /// <returns>retourne un int</returns>
        int Count();

        /// <summary>
        /// Retourne le capacité maximal du storage
        /// </summary>
        /// <returns>retourne la capacité sous forme de int</returns>
        int GetCapacity();

    }	 
}   
