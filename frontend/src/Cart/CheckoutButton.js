import React from "react";
import StripeCheckout from "react-stripe-checkout";
import { useGlobalContext } from "../Cart/context";
import { UserContext } from "../Contexts/UserContext";
import { useContext } from "react";

function CheckoutButton() {
  const { total, clearCart } = useGlobalContext();
  const { user } = useContext(UserContext);

  const onToken = (token) => {
    console.log(token);
    clearCart(user);
  };

  return (
    <StripeCheckout
      token={onToken}
      name="Please enter payment data."
      currency="RON"
      amount={total * 100}
      email={user.name}
      shippingAddress={true}
      stripeKey="pk_test_51L2EvLCR1HVkClRDZrbAv9shbRGG81p5FDssf0ufzajtIjvYQZUaoyjmuQNx2HzzrX8Kn5oBC74ClEwE1yMyPf2x00yyS1F0Xu"
    />
  );
}

export default CheckoutButton;
