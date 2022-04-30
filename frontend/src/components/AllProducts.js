import React, {useEffect, useState} from 'react';
import Product from './Product'
//CSS
import '../index.css'

const url = 'https://localhost:7090/api/Products';


function AllProducts(){
  const [products, setProducts] = useState([]);

  const getProducts = async() =>{
    const response = await fetch(url);
    const products = await response.json();
    setProducts(products);
    //console.log(products);
  }

  useEffect(() => {getProducts()}, []);

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
      <section className='Products'>
        {products.map((product) => {
          const {name, price, img} = product;
          return (
            <Product 
            _name = {name}
            _price = {price}
            _img = {img}
            ></Product>
          );
        })}
        </section>
        </React.Fragment>
  );
  }
  
  export default AllProducts;

  