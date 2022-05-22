import React from "react";
import CartContainer from "../Cart/CartContainer";
import "../Cart/cartStyle.css";
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
