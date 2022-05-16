import React from "react";
import AllItems from "../components/AllItems";

function Categories() {
  const url = "https://localhost:7090/api/Categories";
  const isProduct = false;

  return <AllItems url={url} isProduct={isProduct}></AllItems>;
}

export default Categories;
