import React from "react";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { Button } from "@mui/material";
import { LazyLoadImage } from "react-lazy-load-image-component";
import "react-lazy-load-image-component/src/effects/blur.css";
import ProductStyle from "../style/ProductStyle.module.css";
import { Link } from "react-router-dom";

function Product({ name, price, img, id }) {
  return (
    <div className={ProductStyle.product}>
      <div>
        <LazyLoadImage width="100" effect="blur" src={img} alt="Undefined" />
        <p>{name}</p>
        <h4>{price} Ron</h4>
        <Link to={`/products/${id}`}>more info</Link>
      </div>
      <Button>
        <AddShoppingCartIcon />
        Add
      </Button>
    </div>
  );
}
export default Product;
