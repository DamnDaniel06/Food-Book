using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Food_Book;

namespace Food_Book_GUI
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        //CookBook newBook = new CookBook();

        public ListWindow()
        {
            
            InitializeComponent();
            ShowInitialList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //Get list
            CookBook Book = new CookBook();
            Book = Food_Book.Convert.Convert_to_object();
            CookBook newBook = new CookBook();
            ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();

            //Fields 
            string input1 = UserInput.Text;

            //Ingredient
            if (CbFilterby.SelectedIndex == 0)
            {
                foreach (var recipe in Book.recipes)
                {
                    if (CbFilterMust.SelectedIndex == 0)
                    {
                        foreach (var ing in recipe.ingediants.Where(p => p.name.Contains(input1)))
                        {
                            newBook.recipes.Add(recipe);
                        }
                    }
                    if (CbFilterMust.SelectedIndex == 1)
                    {
                        foreach (var ing in recipe.ingediants.Where(p => !p.name.Contains(input1)))
                        {
                            newBook.recipes.Add(recipe);
                        }
                    }
                }
            }//--->> finding a way to create action every time ComboBox changes
            //food type
            if (CbFilterby.SelectedIndex == 1)
            {//get selecte food group


                if (CbFilterMust.SelectedIndex == 0)
                {

                }
                else
                {

                }
            }
            //calories
            if (CbFilterby.SelectedIndex == 2)
            {

            }
            //Add list to ListView
            foreach (var rept in newBook.recipes)
            {
                recipes.Add(new Recipe { Name = rept.Name, Calory = rept.TotalCalories });
            }
            ListRecipes.ItemsSource = recipes;

        }
        public void ShowInitialList()
        {

            CookBook newBook = new CookBook();

            newBook = Food_Book.Convert.Convert_to_object();

            if (newBook != null)
            {
                HiddenStack.Visibility = Visibility.Hidden;
                ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
                foreach (var rept in newBook.recipes)
                {
                    recipes.Add(new Recipe { Name = rept.Name, Calory = rept.TotalCalories });
                }
                ListRecipes.ItemsSource = recipes;
            }
            else
            {
                HiddenStack.Visibility = Visibility.Visible;
            }
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null && item.IsSelected)
            {
                //Do your stuff
            }
        }

        private void CbFilterby_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CbFilterMust != null)
            {
                if (CbFilterby.SelectedIndex == 0)
                {
                    CbFilterMust.IsEnabled = true;
                    UserInput.IsEnabled = true;
                    ListFood.IsEnabled = false;
                    CbFilterMinMax.IsEnabled = false;
                }
                else if (CbFilterby.SelectedIndex == 1)
                {
                    CbFilterMust.IsEnabled = true;
                    CbFilterMinMax.IsEnabled = false;
                    UserInput.IsEnabled = false;
                    ListFood.IsEnabled = true;
                }
                else
                {
                    CbFilterMust.IsEnabled = false;
                    ListFood.IsEnabled = false;
                    CbFilterMinMax.IsEnabled = true;
                    UserInput.IsEnabled = true;
                }
            }
            
            
        }
        public IEnumerable<string> choosing = new List<string> { "Ingredients", "Food Group", "Categories" };
    }
}
