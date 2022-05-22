import * as React from "react";
import Button from "@mui/material/Button";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import Stack from "@mui/material/Stack";
import { UserContext } from "../Services/UserContext";
import { useContext } from "react";
import { useGlobalContext } from "./Cart/context";

export default function IconLabelButtons({ title, price, id, img }) {
  const { user } = useContext(UserContext);
  const { addProduct } = useGlobalContext();

  // const addToCart = () => {
  //   if (user.auth === true) {
  //     let alreadyExits = false;
  //     let products = JSON.parse(localStorage.getItem(`${user.name}-cart`));

  //     increase(id);

  //     products.map((product) => {
  //       if (product.title === title) {
  //         product.amount += 1;
  //         alreadyExits = true;
  //       }
  //     });

  //     if (alreadyExits === false) {
  //       let product = { title, price, id, img };
  //       product.amount = 1;
  //       products.push(product);
  //     }
  //     localStorage.setItem(`${user.name}-cart`, JSON.stringify(products));
  //   }
  // };

  return (
    <Stack direction="row" spacing={2}>
      <Button
        size="large"
        variant="contained"
        endIcon={<AddShoppingCartIcon />}
        onClick={() => {
          addProduct(user, { title, price, id, img });
        }}
      >
        Add
      </Button>
    </Stack>
  );
}
