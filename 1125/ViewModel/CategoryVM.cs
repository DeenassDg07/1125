using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using _1125.Model;
using _1125.View;
using _1125.VMTools;

namespace _1125.ViewModel
{
    internal class CategoryVM : BaseVM
    {
        public ICommand ProductsVacuumСleaner { get; set; }
        public ICommand ProductsMicrowave { get; set; }
        public ICommand ProductsFridge { get; set; }
        public ICommand ProductsTV { get; set; }
        public ICommand ProductsTelephone { get; set; }
    public CategoryVM()
        {
            ProductsVacuumСleaner = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow("Пылесос");
                close?.Invoke();
                productsWindow.ShowDialog();
            }, () => true);

            ProductsMicrowave = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow();
                close?.Invoke();
                productsWindow.ShowDialog();
            }, () => true);

            ProductsFridge = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow();
                close?.Invoke();
                productsWindow.ShowDialog();
            }, () => true);

            ProductsTV = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow();
                close?.Invoke();
                productsWindow.ShowDialog();
            }, () => true);

            ProductsTelephone = new CommandVM(() =>
            {
                ProductsWindow productsWindow = new ProductsWindow();
                close?.Invoke();
                productsWindow.ShowDialog();
            }, () => true);
        }
        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
