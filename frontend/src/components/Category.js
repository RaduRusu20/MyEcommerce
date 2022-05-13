import React from "react";
import CategoryStyle from "../style/CategoryStyle.module.css";
import { Link } from "react-router-dom";
import Product from "../style/ProductStyle.module.css";
import ArrowForwardRoundedIcon from "@mui/icons-material/ArrowForwardRounded";

function Category({ name, id }) {
  return (
    <div className={CategoryStyle.category}>
      <h4>{name}</h4>
      <Link to={`/categories/${id}/products`} className={Product.link}>
        <ArrowForwardRoundedIcon fontSize="large" />
      </Link>
    </div>
  );
}

export default Category;
