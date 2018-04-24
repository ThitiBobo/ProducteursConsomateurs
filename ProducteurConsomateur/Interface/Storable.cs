
namespace ProducteurConsomatteur
{
	/// <summary>
    /// Représente un objet pouvant contenir, ajouter ou retirer des objets dans un stokage 
    /// </summary>
    public interface Storable {

        /// <summary>
        /// Permet d'ajouter un ojbet dans le stokage
        /// </summary>
        void Add();

        /// <summary>
        /// permet de retirer un objet dans le stokage
        /// </summary>
        void Take();

        /// <summary>
        /// Retourne le nombre d'objet contenu dans le stokage
        /// </summary>
        /// <returns>retourne un int</returns>
        int Count();

    }	 
}   
