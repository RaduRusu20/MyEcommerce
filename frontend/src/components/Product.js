import React from 'react'
import AddShoppingCartIcon from '@mui/icons-material/AddShoppingCart';
import { Button } from '@mui/material';
import '../style/AllProductsStyle.css'

function Product (product){
    const {_name, _price, _img} = product;
    return (
        <section className='Product'>
            <img
            width = "100"
            src = {_img}
            alt = 'Undefined'
            ></img>
             <p>{_name}</p>
             <h4>{_price} Ron</h4>
             <Button>
             <AddShoppingCartIcon></AddShoppingCartIcon>
                 Add
            </Button>
        </section>
    );
}
export default Product;