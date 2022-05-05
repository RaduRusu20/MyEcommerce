import React, { useEffect, useState } from "react";
import Product from "./Product";
import Category from "./Category";
import Pagination from "./Pagination";
//CSS
import ListOfItems from "../style/ListOfItems.module.css";

function AllItems({ url, isProduct }) {
  const [data, setData] = useState([]);
  const [sortType, setSortType] = useState("price");
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage, setPostsPerPage] = useState(5);

  //Get Current Post
  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;

  //Change Page
  const paginate = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  const getData = async () => {
    const response = await fetch(url);
    const result = await response.json();
    setData(result);
  };

  console.log(data);

  const sortArray = (type) => {
    //sorting types
    const types = {
      price_asc: "price",
      price_desc: "price",
      name_asc: "name",
      name_desc: "name",
    };
    const sortProperty = types[type];

    //sorting descending or ascending
    let sortedProducts;
    if (type.startsWith("price") && isProduct) {
      sortedProducts = [...data].sort((a, b) =>
        type.endsWith("_desc")
          ? b[sortProperty] - a[sortProperty]
          : a[sortProperty] - b[sortProperty]
      );
    } else if (type.startsWith("name")) {
      sortedProducts = [...data].sort((a, b) =>
        type.endsWith("_desc")
          ? b[sortProperty] > a[sortProperty]
            ? 1
            : -1
          : b[sortProperty] > a[sortProperty]
          ? -1
          : 1
      );
    }
    setData(sortedProducts);
  };

  useEffect(() => {
    getData();
  }, []);
  useEffect(() => {
    sortArray(sortType);
  }, [sortType]);

  const slicedProducts = data.slice(indexOfFirstPost, indexOfLastPost);

  //get array of products range
  let GetRangeOfDisplayedItems = (() => {
    const itemsIndx = [];
    for (let i = 5; i <= 10; i++) {
      itemsIndx.push(i);
    }
    return itemsIndx;
  })();

  return (
    <>
      <br></br>
      <h1
        style={{
          display: "flex",
          justifyContent: "center",
          alignItems: "center",
        }}
      >
        All products
      </h1>
      <br></br>
      <select
        className={ListOfItems.select}
        onChange={(e) => setSortType(e.target.value)}
      >
        {isProduct && <option value="price_asc">AscendingByPrice</option>}
        {isProduct && <option value="price_desc">DescendingByPrice</option>}
        <option value="name_asc">AscendingByName</option>
        <option value="name_desc">DescendingByName</option>
      </select>

      <select
        className={ListOfItems.select}
        onChange={(e) => {
          setPostsPerPage(e.target.value);
        }}
      >
        {GetRangeOfDisplayedItems.map((e, i) => (
          <option key={i}>{e}</option>
        ))}
      </select>

      <ul className={ListOfItems.products}>
        {slicedProducts.map((product) => {
          if (isProduct) {
            const { name, price, img, Id } = product;
            return (
              <Product key={Id} name={name} price={price} img={img}></Product>
            );
          } else {
            const { name } = product;
            return <Category name={name}></Category>;
          }
        })}
      </ul>
      <Pagination
        postsPerPage={postsPerPage}
        totalPosts={data.length}
        paginate={paginate}
      ></Pagination>
      <br></br>
    </>
  );
}

export default AllItems;
