import React, {useEffect, useState} from 'react';
import Product from './Product'
import Pagination from './Pagination'
//CSS
import '../index.css'
import { CompressOutlined } from '@mui/icons-material';

const products_url = 'https://localhost:7090/api/Products';


function AllProducts(){
  const [products, setProducts] = useState([]);
  const [sortType, setSortType] = useState('price');
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage] = useState(14);

   //Get Current Post
   const indexOfLastPost = currentPage * postsPerPage;
   const indexOfFirstPost = indexOfLastPost - postsPerPage;

   //Change Page
   const paginate  =  pageNumber => {
    setCurrentPage(pageNumber);
   console.log(pageNumber);
  }
 
  const getProducts = async() =>{
    const response = await fetch(products_url);
    const products = await response.json();
    setProducts(products);
  }

  const sortArray = async (type) => {
   
    //sorting types
    const types = {
      price_asc: 'price',
      price_desc: 'price',
      name_asc: 'name',
      name_desc: 'name',
    };
    const sortProperty = types[type];

    //sorting descending or ascending
    if(type.endsWith('_desc'))
    {
    const sortedProducts_desc = [...products].sort((a, b) => b[sortProperty] - a[sortProperty]);
    //const currentProducts_desc = sortedProducts_desc.slice(indexOfFirstPost, indexOfLastPost); 
    setProducts(sortedProducts_desc);
    }
    else
    {
    const sortedProducts_asc = [...products].sort((a, b) => a[sortProperty] - b[sortProperty]);
    //const currentProducts_asc = sortedProducts_asc.slice(indexOfFirstPost, indexOfLastPost);
    setProducts(sortedProducts_asc);
    }
  };

  useEffect(() => {getProducts()}, []);
  useEffect(() => {sortArray(sortType)}, [sortType]);

  const slicedProducts = products.slice(indexOfFirstPost, indexOfLastPost);
  return (
    <React.Fragment>
      <br></br>
      <h1 
      style={{ 
          display: "flex",
          justifyContent: "center",
          alignItems: "center"
        }}>
          All products
      </h1>
      <br></br>
      <select onChange={(e) => setSortType(e.target.value)}>
        <option value="price_asc">AscendingByPrice</option>
        <option value="price_desc">DescendingByPrice</option>
        <option value="name_asc">AscendingByName</option>
        <option value="name_desc">DescendingByName</option>
      </select>
      <ul className='Products'>
        {slicedProducts.map((product) => {
          const {name, price, img} = product;
          return (
            <Product
            _name = {name}
            _price = {price}
            _img = {img}
            ></Product>
          );
        })}
        </ul>
        <Pagination postsPerPage={postsPerPage} totalPosts={products.length} paginate={paginate}></Pagination>
        <br></br>
        </React.Fragment>
  );
  }
  
  export default AllProducts;

  