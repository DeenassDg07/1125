using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1125.VMTools;
using System.Windows.Input;
using _1125.View;

namespace _1125.ViewModel
{
    internal class ProductsVM : BaseVM
    {
        public ICommand Back { get; set; }
        public ICommand Baket { get; set; }

        public ProductsVM(string productType)
        {
            if (!string.IsNullOrEmpty(productType))
            {
                Search(productType);
            }

            Back = new CommandVM(() =>
            {
                CategoryWindow categoryWindow = new CategoryWindow();
                close?.Invoke();
                categoryWindow.ShowDialog();
            }, () => true);

            Baket = new CommandVM(() =>
            {
                BasketWindow basketWindow = new BasketWindow();
                close?.Invoke();
                basketWindow.ShowDialog();
            }, () => true);
        }

        private void Search(string productType)
        {
            
        }

        Action close;
        internal void SetClose(Action close)
        {
            this.close = close;
        }
    }
}
