using BusinessLogic;
using DataAccessLogic;

namespace UserInterface
{
    /// <summary>
    /// Designed to create menu objects
    /// </summary>
    public class MenuFactory : IFactoryPattern
    {
        public IMenu GetMenu(MenuType p_menu)
        {
            switch (p_menu)
            {
               case MenuType.MainMenu:
                        //If user choosed to go back to the MainMenu
                        //page will start pointing to a MainMenu object instead
                        return new MainMenu();
                    
                    case MenuType.LoginMenu:
                        //This will point the page reference variable to a new Restaurant Object
                        //Since Restaurant Object has different implementation/function of the Menu Method
                        //It will have different implementations/functions when the while loop goes back and
                        //repeat itself
                        return new LoginMenu(new BL(new Repository()));
                        
                    case MenuType.ShowCustomers:
                        return new ShowCustomers(new BL(new Repository()));
                     
                    case MenuType.AddCustomers:
                        return new AddCustomerMenu(new BL(new Repository()));
                  
                        case MenuType.loginconfirm:
                        return new LoginConfirmationMenu();
                      
                        case MenuType.StoreMenu:
                        
                       return new StoreMenu(new BL(new Repository()));
                     
                        case MenuType.ProductDisplayMenu:
                        
                        return new ProductMenuDisplay(new BL(new Repository()));
                    
                        case MenuType.ProductBuyMenu:
                        return new ProductBuyMenu(new BL(new Repository()));
                     
                        case MenuType.ReplenishMenu:
                        return new ReplenishInventoryMenu(new BL(new Repository()));
                  
                        case MenuType.MyProfile:
                        return new MyProfile(new BL(new Repository()));
              
                default:
                    return null;
            }
        }
    }
}