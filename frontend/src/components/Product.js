import React from "react";
import { LazyLoadImage } from "react-lazy-load-image-component";
import "react-lazy-load-image-component/src/effects/blur.css";
import ProductStyle from "../style/ProductStyle.module.css";
import { Link } from "react-router-dom";
import BuyButton from "./BuyButton";
import InfoIcon from "@mui/icons-material/Info";

function Product({ name, price, img, id }) {
  return (
    <div className={ProductStyle.product}>
      <div>
        <LazyLoadImage width="100" effect="blur" src={img} alt="Undefined" />
        <p>{name}</p>
        <h4>{price} Ron</h4>
      </div>
      <Link to={`/products/${id}`} className={ProductStyle.link}>
        Details
        <InfoIcon color="primary" />
      </Link>
      <BuyButton />
    </div>
  );
}
export default Product;
