
namespace ProducteurConsomateur
{
	/// <summary>
    /// Représente un objet pouvant contenir, ajouter ou retirer des objets dans un stockage 
    /// </summary>
    public interface Storable {

        /// <summary>
        /// Permet d'obtenir le nom/identifiant du stockage
        /// </summary>
        /// <returns>retourne le nom sous forme de string</returns>
        string GetName();

        /// <summary>
        /// Permet d'ajouter un objet dans le stockage
        /// </summary>
        void Add();

        /// <summary>
        /// Permet de retirer un objet dans le stockage
        /// </summary>
        void Take();

        /// <summary>
        /// Retourne le nombre d'objet contenu dans le stockage
        /// </summary>
        /// <returns>retourne un int</returns>
        int Count();

        /// <summary>
        /// Retourne le capacité maximal du stockage
        /// </summary>
        /// <returns>retourne la capacité sous forme de int</returns>
        int GetCapacity();

    }	 
}   
