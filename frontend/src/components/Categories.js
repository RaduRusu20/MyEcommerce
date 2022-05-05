import React from "react";
import { useFetch } from "../hooks/useFetch";
import AllItems from "./AllItems";

function Categories() {
  const categories_url = "https://localhost:7090/api/Categories";
  const isProduct = false;

  return <AllItems url={categories_url} isProduct={isProduct}></AllItems>;
}

export default Categories;
