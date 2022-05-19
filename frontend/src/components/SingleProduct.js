import React from "react";
import { useParams } from "react-router-dom";
import { useFetch } from "../hooks/useFetch";
import "react-lazy-load-image-component/src/effects/blur.css";
import ProductDetailsStyle from "../style/ProductStyle.module.css";
import Rating from "./Rating";
import BuyButton from "./BuyButton";
import Box from "@mui/material/Box";
import CustomerLayout from "../Layouts/CustomerLayout";

function SingleProduct() {
  const { productId } = useParams();

  const product = useFetch(`https://localhost:7090/api/Products/${productId}`);
  const { name, price, img, description, availableQuantity } = product.data;

  let oldPrice = (price + 0.1 * price).toFixed(2);

  return (
    <>
      <CustomerLayout>
        <div className={ProductDetailsStyle.center}>
          <div className={ProductDetailsStyle.productDetails}>
            <img
              className={ProductDetailsStyle.pictures}
              width="400"
              src={img}
              alt="Undefined"
            />
            <div>
              <h2>{name}</h2>
              <div className={ProductDetailsStyle.strike}>
                <h4 style={{ color: "black" }}>{oldPrice} Ron</h4>
              </div>
              <h2>{price} Ron</h2>
              <hr></hr>
              <br></br>
              <p>{description}</p>
              <br></br>
              <hr></hr>
              <br></br>
              <p>Available quantity: {availableQuantity}</p>
              <Box gap={1} display={"flex"}>
                <p>Rating: </p>
                <Rating />
              </Box>
              <br></br>
              <BuyButton />
            </div>
          </div>
        </div>
      </CustomerLayout>
    </>
  );
}

export default SingleProduct;
