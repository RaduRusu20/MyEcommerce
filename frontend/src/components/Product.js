import React from "react";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import { LazyLoadImage } from "react-lazy-load-image-component";
import "react-lazy-load-image-component/src/effects/blur.css";
import "../style/AllProductsStyle.css";

function Product({ name, price, img }) {
  return (
    <div className="Product">
      <div>
        <LazyLoadImage width="100" effect="blur" src={img} alt="Undefined" />
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
