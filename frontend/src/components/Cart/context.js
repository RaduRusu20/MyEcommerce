import React, { useState, useContext, useReducer, useEffect } from "react";
import reducer from "./reducer";
import { UserContext } from "../../Services/UserContext";
import data from "../Cart/data";

const AppContext = React.createContext();

const initialState = {
  cart: [],
  total: 0,
  amount: 0,
};

const AppProvider = ({ children }) => {
  const { user } = useContext(UserContext);

  const [state, dispatch] = useReducer(reducer, initialState);

  const clearCart = (user) => {
    dispatch({ type: "CLEAR_CART", payload: user });
  };

  const addProduct = (user, product) => {
    dispatch({ type: "ADD_ITEM", payload: { user, product } });
  };

  const remove = (id) => {
    dispatch({ type: "REMOVE", payload: id });
  };

  const increase = (id) => {
    dispatch({ type: "INCREASE", payload: id });
  };

  const decrease = (id) => {
    dispatch({ type: "DECREASE", payload: id });
  };

  const fetchCartData = () => {
    const cart = JSON.parse(localStorage.getItem(`${user.name}-cart`));
    dispatch({ type: "FETCH_DATA", payload: cart });
  };

  // useEffect(() => {
  //   console.log("aici");
  //   fetchCartData();
  // }, []);

  useEffect(() => {
    dispatch({ type: "GET_TOTALS" });
  }, [state.cart]);

  return (
    <AppContext.Provider
      value={{
        ...state,
        clearCart,
        addProduct,
        remove,
        increase,
        decrease,
        fetchCartData,
      }}
    >
      {children}
    </AppContext.Provider>
  );
};
// make sure use
export const useGlobalContext = () => {
  return useContext(AppContext);
};

export { AppContext, AppProvider };
