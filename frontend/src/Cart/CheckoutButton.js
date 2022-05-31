import React from "react";
import StripeCheckout from "react-stripe-checkout";
import { useGlobalContext } from "../Cart/context";
import { UserContext } from "../Contexts/UserContext";
import { useContext } from "react";
import emailjs from "@emailjs/browser";

function CheckoutButton() {
  const { total, clearCart } = useGlobalContext();
  const { user } = useContext(UserContext);

  const onToken = (token) => {
    console.log(token);
    let shoppingCart = JSON.parse(localStorage.getItem(`${user.name}-cart`));
    console.log(shoppingCart);

    let receipt = "";

    for (let i = 0; i < shoppingCart.length; i++) {
      receipt +=
        shoppingCart[i].title +
        ", amount: " +
        shoppingCart[i].amount +
        ", price: " +
        parseFloat(
          (shoppingCart[i].price * shoppingCart[i].amount).toFixed(2)
        ) +
        " RON" +
        "<br/>";
    }

    receipt += "<br/><br/>";
    receipt += "Total: " + total + " RON";

    var templateParams = {
      email: user.name,
      receipt: receipt,
    };

    emailjs
      .send(
        "service_ttbx8wr",
        "template_ofe8zjw",
        templateParams,
        "3qzZsevFcsLlsPEEF"
      )
      .then(
        function (response) {
          console.log("SUCCESS!", response.status, response.text);
        },
        function (error) {
          console.log("FAILED...", error);
        }
      );
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
