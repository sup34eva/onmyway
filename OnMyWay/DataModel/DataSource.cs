using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// Le modèle de données défini par ce fichier sert d'exemple représentatif d'un modèle fortement typé
// modèle.  Les noms de propriétés choisis correspondent aux liaisons de données dans les modèles d'élément standard.
//
// Les applications peuvent utiliser ce modèle comme point de départ et le modifier à leur convenance, ou le supprimer complètement et
// le remplacer par un autre correspondant à leurs besoins. L'utilisation de ce modèle peut vous permettre d'améliorer votre application 
// réactivité en lançant la tâche de chargement des données dans le code associé à App.xaml lorsque l'application 
// est démarrée pour la première fois.

namespace OnMyWay.Data
{
    /// <summary>
    /// Modèle de données d'élément générique.
    /// </summary>

    public class Dish
    {
        public int id;
        public string name;
        public int price;

        public Dish(int id, string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

    }

    public class Table
    {
        public Table(int number, int places, int posX, int posY)
        {
            this.Items = new ObservableCollection<Dish>();

            this.number = number;
            this.places = places;
            this.posX = posX;
            this.posY = posY;
        }

        public ObservableCollection<Dish> Items { get; private set; }

        public int number { get; private set; }
        public int places { get; private set; }//occupées
        public int posX { get; private set; }
        public int posY { get; private set; }
    }

    public sealed class DataSource
    {
        private static DataSource _sampleDataSource = new DataSource();

        private ObservableCollection<Table> _groups = new ObservableCollection<Table>();
        public ObservableCollection<Table> Groups
        {
            get { return this._groups; }
        }

        public static async Task<IEnumerable<Table>> GetGroupsAsync()
        {
            await _sampleDataSource.GetSampleDataAsync();

            return _sampleDataSource.Groups;
        }

        public static async Task<Table> GetGroupAsync(string number)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Une simple recherche linéaire est acceptable pour les petits groupes de données
            var matches = _sampleDataSource.Groups.Where((group) => group.number.Equals(number));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static async Task<Dish> GetItemAsync(string id)
        {
            await _sampleDataSource.GetSampleDataAsync();
            // Une simple recherche linéaire est acceptable pour les petits groupes de données
            var matches = _sampleDataSource.Groups.SelectMany(group => group.Items).Where((item) => item.id.Equals(id));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        private async Task GetSampleDataAsync()
        {
            this.Groups.Add(group);
        }
    }
}