using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Data.Entity;

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
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

        public Dish(string name, int price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }

    }

    public class Table
    {
        public Table(int places, int posX, int posY)
        {
            this.Items = new ObservableCollection<Dish>();

            this.number = number;
            this.places = places;
            this.posX = posX;
            this.posY = posY;
        }

        public ObservableCollection<Dish> Items { get; private set; }

        public int number { get; set; }
        public int places { get; set; }//places occupées
        public int posX { get; set; }
        public int posY { get; set; }
    }

    public sealed class DataSource
    {
        static OnmyWayDB db = new OnmyWayDB();

        public static async Task<IEnumerable<Table>> GetGroupsAsync()
        {
            return db.Table;
        }

        public static async Task<Table> GetGroupAsync(string number)
        {
            return db.Table.Find(number);
        }

        public static async Task<Dish> GetItemAsync(string id)
        {
            return db.Dish.Find(id);
        }

        private async Task GetSampleDataAsync()
        {
            
        }
    }
}