﻿using Domain.Products;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryPattern
{
    public interface IShoppingCartRepository
    {
        public Task CreateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken);

        public Task UpdateShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken);

        public Task DeleteShoppingCartAsync(ShoppingCart shoppingCart, CancellationToken cancellationToken);

        public Task<ShoppingCart> FindShoppingCartByIdAsync(Guid shoppingCartId, CancellationToken cancellationToken);

        public Task<List<ShoppingCart>> GetAllShoppingCartAsync(CancellationToken cancellationToken);

        public Task AddProductToShoppingCartAsync(ShoppingCart shoppingCart, Product product, int Quantity, CancellationToken cancellationToken);

        public Task RemoveProductFromShoppingCartAsync(ShoppingCart shoppingCart, Product product, int Quantity, CancellationToken cancellationToken);

    }
}
