import React from "react";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import "../style/AllProductsStyle.css";

function Product({ name, price, img }) {
  return (
    <div className="Product">
      <div>
        <img width="100" src={img} alt="Undefined" />
        <p>{name}</p>
        <h4>{price} Ron</h4>
      </div>
      <Button>
        <AddShoppingCartIcon />
        Add
      </Button>
    </div>
  );
}
export default Product;
