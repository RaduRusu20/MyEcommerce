import React, { useEffect, useState } from "react";
import Product from "./Product";
import Category from "./Category";
import Pagination from "./Pagination";
import Layout from "../Layouts/CustomerLayout";
import SearchIcon from "@mui/icons-material/Search";
import IconButton from "@mui/material/IconButton";

//CSS
import ListOfItems from "../style/ListOfItems.module.css";
import { display } from "@mui/system";

function AllItems({ url, isProduct }) {
  const [data, setData] = useState([]);
  // const [slicedData, setSlicedData] = useState(null);
  const [sortType, setSortType] = useState("price");
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage, setPostsPerPage] = useState(5);
  const [search, setSearch] = useState("");
  const [displaySearch, setDisplaySearch] = useState(false);
  const [clickCounter, setClickCounter] = useState(0);

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
    let sortedItems;
    if (type.startsWith("price") && isProduct) {
      sortedItems = [...data].sort((a, b) =>
        type.endsWith("_desc")
          ? b[sortProperty] - a[sortProperty]
          : a[sortProperty] - b[sortProperty]
      );
    } else if (type.startsWith("name")) {
      sortedItems = [...data].sort((a, b) =>
        type.endsWith("_desc")
          ? b[sortProperty] > a[sortProperty]
            ? 1
            : -1
          : b[sortProperty] > a[sortProperty]
          ? -1
          : 1
      );
    }
    setData(sortedItems);
  };

  useEffect(() => {
    getData();
  }, []);

  useEffect(() => {
    sortArray(sortType);
  }, [sortType]);

  // useEffect(() => {
  //   if (data) setSlicedData(data.slice(indexOfFirstPost, indexOfLastPost));
  // }, [sortType, currentPage, postsPerPage]);

  let slicedData = data ? data.slice(indexOfFirstPost, indexOfLastPost) : [];

  //get array of products range
  let GetRangeOfDisplayedItems = (() => {
    const itemsIndx = [];
    for (let i = 1; i <= 10; i++) {
      itemsIndx.push(i);
    }
    return itemsIndx;
  })();

  return (
    <>
      <Layout
        style={{
          display: "flex",
          flexDirection: "row",
          justifyContent: "space-between",
        }}
      >
        <div>
          <p className={ListOfItems.inline}>Sort type: </p>
          {!displaySearch && (
            <select
              className={ListOfItems.select}
              onChange={(e) => setSortType(e.target.value)}
            >
              {isProduct && <option value="price_asc">AscendingByPrice</option>}
              {isProduct && (
                <option value="price_desc">DescendingByPrice</option>
              )}
              <option value="name_asc">AscendingByName</option>
              <option value="name_desc">DescendingByName</option>
            </select>
          )}

          <p className={ListOfItems.inline}>Results per page: </p>
          {!displaySearch && (
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
          )}

          <IconButton
            className={ListOfItems.search}
            onClick={() => {
              if (clickCounter % 2 === 0) {
                setDisplaySearch(true);
              } else {
                setDisplaySearch(false);
              }
              setClickCounter(clickCounter + 1);
            }}
            onC
          >
            <SearchIcon />
          </IconButton>

          {displaySearch && (
            <input
              style={{ allign: "center", padding: "5px", margin: "15px" }}
              type={"text"}
              placeholder={"Search here"}
              onChange={(e) => {
                setSearch(e.target.value);
              }}
            ></input>
          )}

          {!displaySearch && (
            <input
              className={ListOfItems.inline}
              style={{ allign: "center", padding: "5px", margin: "15px" }}
              type={"text"}
              placeholder={"Search here"}
              onChange={(e) => {
                setSearch(e.target.value);
              }}
            ></input>
          )}
        </div>

        {data && (
          <p className={ListOfItems.right}>Total result: {data.length}</p>
        )}
        <ul className={ListOfItems.items}>
          {slicedData &&
            slicedData
              .filter((item) => {
                if (
                  item.name
                    .toLocaleLowerCase()
                    .includes(search.toLocaleLowerCase()) ||
                  item.name === ""
                ) {
                  return item;
                }
              })
              .map((item) => {
                const { name, price, img, id } = item;
                return (
                  <div key={id}>
                    {isProduct && (
                      <>
                        <Product
                          name={name}
                          price={price}
                          img={img}
                          id={id}
                        ></Product>
                      </>
                    )}
                    {!isProduct && <Category name={name} id={id}></Category>}
                  </div>
                );
              })}
        </ul>
        {data && (
          <Pagination
            postsPerPage={postsPerPage}
            totalPosts={data.length}
            paginate={paginate}
          ></Pagination>
        )}
        <br></br>
      </Layout>
    </>
  );
}

export default AllItems;
