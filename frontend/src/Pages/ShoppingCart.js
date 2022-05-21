import React from "react";
import CartContainer from "../components/Cart/CartContainer";
import "../components/Cart/cartStyle.css";
import CustomerLayout from "../Layouts/CustomerLayout";

function ShoppingCart() {
  return (
    <>
      <CustomerLayout>
        <CartContainer />
      </CustomerLayout>
    </>
  );
}

export default ShoppingCart;
