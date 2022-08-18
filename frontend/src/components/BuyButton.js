import * as React from "react";
import Button from "@mui/material/Button";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import Stack from "@mui/material/Stack";
import { UserContext } from "../Contexts/UserContext";
import { useContext } from "react";
import { useGlobalContext } from "../Cart/context";
import { useState } from "react";
import { Navigate } from "react-router-dom";

export default function IconLabelButtons({ title, price, id, img }) {
  const { user } = useContext(UserContext);
  const { addProduct } = useGlobalContext();
  const [isLoggedIn, setIsLoggedIn] = useState(true);

  return (
    <Stack direction="row" spacing={2}>
      <Button
        size="large"
        variant="contained"
        endIcon={<AddShoppingCartIcon />}
        onClick={() => {
          if (user.auth === true) setIsLoggedIn(true);
          else setIsLoggedIn(false);

          if (isLoggedIn === true) addProduct(user, { title, price, id, img });
        }}
      >
        Add
      </Button>
      {!isLoggedIn && <Navigate to={"/SignIn"} />}
    </Stack>
  );
}
