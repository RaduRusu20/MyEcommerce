import React, { useEffect } from "react";
import CartItem from "./CartItem";
import { useGlobalContext } from "./context";
import { UserContext } from "../Contexts/UserContext";
import { useContext } from "react";
import CheckoutButton from "./CheckoutButton";
import { Box } from "@material-ui/core";

const CartContainer = () => {
  const { cart, total, clearCart, fetchCartData } = useGlobalContext();
  const { user } = useContext(UserContext);

  useEffect(fetchCartData, []);

  if (cart.length === 0) {
    return (
      <section className="cart">
        {/* cart header */}
        <header>
          <h2>your bag</h2>
          <h4 className="empty-cart">is currently empty</h4>
        </header>
      </section>
    );
  }
  return (
    <section className="cart">
      {/* cart header */}
      <header>
        <h2>your bag</h2>
      </header>
      {/* cart items */}
      <div>
        {cart.map((item) => {
          return <CartItem key={item.id} {...item} />;
        })}
      </div>
      {/* cart footer */}
      <footer>
        <hr />
        <div className="cart-total">
          <h4>
            total <span>{total} RON</span>
          </h4>
        </div>
        <button className="btn clear-btn" onClick={() => clearCart(user)}>
          clear cart
        </button>
        <CheckoutButton />
      </footer>
    </section>
  );
};

export default CartContainer;
