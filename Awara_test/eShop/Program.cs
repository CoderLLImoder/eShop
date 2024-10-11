using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var productService = new ShopService();
        var shoppingCart = new ShoppingCart();

        // Загрузка товаров из файла
        productService.LoadProductsFromFile("products.json");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(@"
            ___________________________
            Главное меню:
            1. Просмотр списка товаров
            2. Добавить товар в корзину
            3. Удалить товар из корзины
            4. Просмотр корзины
            5. Выход
            ___________________________");

            Console.Write("Выберите опцию: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    productService.ShowProducts();
                    break;

                case "2":
                    Console.Write("Введите артикул товара для добавления в корзину: ");
                    productService.ShowProducts();
                    if (int.TryParse(Console.ReadLine(), out int productArticul))
                    {
                        var product = productService.GetProductByArticul(productArticul);
                        if (product != null)
                        {
                            Console.Write("Введите количество: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 )
                            {
                                shoppingCart.AddItem(product, quantity);
                                Console.WriteLine("Товар добавлен в корзину.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректное количество.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Товар не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный артикул.");
                    }
                    break;

                case "3":
                    shoppingCart.ShowCart();
                    Console.Write("Введите артикул товара для удаления из корзины: ");
                    if (int.TryParse(Console.ReadLine(), out int removeArt))
                    {
                        var cartItem = shoppingCart.GetItemByArticul(removeArt);
                        if (cartItem != null)
                        {
                            Console.Write("Введите количество: ");
                            if (int.TryParse(Console.ReadLine(), out int quantity) && quantity > 0 && quantity <= cartItem.Quantity )
                            {
                                shoppingCart.RemoveItem(removeArt, quantity);
                                Console.WriteLine("Товар удалён из корзины.");
                            }
                            else
                            {
                                Console.WriteLine("Некорректное количество.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Товар не найден.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный артикул.");
                    }
                    break;

                case "4":
                    shoppingCart.ShowCart();
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
