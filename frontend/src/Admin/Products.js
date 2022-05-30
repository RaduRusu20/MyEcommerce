import React from "react";
import Table from "./Table";
import { useEffect, useState } from "react";
import ReadMoreReact from "read-more-react";
import ProductStyle from "../style/ProductStyle.module.css";

function Products() {
  const productsUrl = "https://localhost:7090/api/Products";
  // const categories = useFetch("https://localhost:7090/api/Categories");

  const [categories, setCategories] = useState([]);

  const getData = async () => {
    const response = await fetch("https://localhost:7090/api/Categories");
    const result = await response.json();
    setCategories(result);
  };

  useEffect(() => {
    getData();
  }, []);

  const [mapper, setMapper] = useState({});

  //mapping categoryId : categoryName
  useEffect(() => {
    const mapper = {};
    categories.map((x) => (mapper[x.id] = x.name));
    setMapper(mapper);
  }, [categories]);

  const columns = [
    {
      field: "id",
      title: "Id",
      editable: "never",
      width: "10%",
      filtering: false,
    },
    {
      field: "name",
      title: "Name",
      filtering: false,
      // width: "10%",
      validate: (rowData) => {
        if (rowData.name === "" || rowData.name === undefined) {
          return "Required";
        }
        return true;
      },
    },
    {
      field: "description",
      title: "Description",
      filtering: false,
      // width: "10%",
      render: (rowData) => (
        <ReadMoreReact
          text={rowData.description}
          min={10}
          readMoreText={<p style={{ color: "blue" }}>Read More...</p>}
        />
      ),
      validate: (rowData) => {
        if (rowData.description === "" || rowData.description === undefined) {
          return "Required";
        }
        return true;
      },
    },
    {
      field: "price",
      title: "Price",
      type: "currency",
      align: "left",
      filtering: false,
      currencySetting: { currencyCode: "RON" },
      // width: "5%",
      validate: (rowData) => {
        if (rowData.price === "" || rowData.price === undefined) {
          return "Required";
        } else if (rowData.price < 0) {
          return "Price cannot be negative!";
        }
        return true;
      },
    },
    {
      field: "availableQuantity",
      title: "Available quantity",
      type: "numeric",
      align: "center",
      filtering: false,
      // width: "5%",
      validate: (rowData) => {
        if (
          rowData.availableQuantity === "" ||
          rowData.availableQuantity === undefined
        ) {
          return "Required";
        }
        return true;
      },
    },
    {
      field: "img",
      title: "Image",
      sorting: false,
      filtering: false,

      // width: "20%",
      render: (rowData) => (
        <img
          src={rowData.img}
          // style={{ width: 100, borderRadius: "50%" }}
          className={ProductStyle.adminProduct}
        />
      ),
      validate: (rowData) => {
        if (rowData.img === "" || rowData.img === undefined) {
          return "Required";
        }
        return true;
      },
    },
    {
      field: "categoryId",
      title: "Category",
      filterPlaceholder: "Category",
      lookup: mapper,
      // width: "65%",
      validate: (rowData) => {
        if (rowData.categoryId === "" || rowData.categoryId === undefined) {
          return "Required";
        }
        return true;
      },
    },
  ];

  return <Table columns={columns} title={"Products"} url={productsUrl} />;
}

export default Products;
