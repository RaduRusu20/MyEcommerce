const Reducer = (state, action) => {
  if (action.type === "CLEAR_CART") {
    console.log(action.payload.name);
    localStorage.setItem(`${action.payload.name}-cart`, JSON.stringify([]));

    return { ...state, cart: [] };
  }
  if (action.type === "REMOVE") {
    let products = JSON.parse(
      localStorage.getItem(`${action.payload.email}-cart`)
    );
    products = products.filter((product) => product.id !== action.payload.id);
    localStorage.setItem(
      `${action.payload.email}-cart`,
      JSON.stringify(products)
    );

    return {
      ...state,
      cart: state.cart.filter((item) => item.id !== action.payload.id),
    };
  }
  if (action.type === "INCREASE") {
    let products = JSON.parse(
      localStorage.getItem(`${action.payload.email}-cart`)
    );
    products.map((product) => {
      if (product.id === action.payload.id) {
        product.amount += 1;
      }
    });
    localStorage.setItem(
      `${action.payload.email}-cart`,
      JSON.stringify(products)
    );
    let tempCart = state.cart.map((cartItem) => {
      if (cartItem.id === action.payload.id) {
        return { ...cartItem, amount: cartItem.amount + 1 };
      }
      return { ...cartItem };
    });
    return { ...state, cart: tempCart };
  }

  if (action.type === "DECREASE") {
    let products = JSON.parse(
      localStorage.getItem(`${action.payload.email}-cart`)
    );
    products.map((product) => {
      if (product.id === action.payload.id) {
        if (product.amount > 1) {
          product.amount -= 1;
        } else {
          products = products.filter((item) => item.id !== product.id);
        }
      }
    });
    localStorage.setItem(
      `${action.payload.email}-cart`,
      JSON.stringify(products)
    );

    let tempCart = state.cart
      .map((cartItem) => {
        if (cartItem.id === action.payload.id) {
          return { ...cartItem, amount: cartItem.amount - 1 };
        }
        return cartItem;
      })
      .filter((cartItem) => cartItem.amount !== 0);
    return { ...state, cart: tempCart };
  }

  if (action.type === "GET_TOTALS") {
    let { total, amount } = state.cart.reduce(
      (cartTotal, cartItem) => {
        const { price, amount } = cartItem;
        const itemTotal = price * amount;

        cartTotal.total += itemTotal;
        cartTotal.amount += amount;
        return cartTotal;
      },
      {
        total: 0,
        amount: 0,
      }
    );

    total = parseFloat(total.toFixed(2));
    return { ...state, total, amount };
  }

  if (action.type === "FETCH_DATA") {
    return { ...state, cart: action.payload };
  }

  if (action.type === "ADD_ITEM") {
    let user = action.payload.user;
    let product = action.payload.product;

    if (user.auth === true) {
      let alreadyExits = false;
      let products = JSON.parse(localStorage.getItem(`${user.name}-cart`));

      products.map((item) => {
        if (item.title === product.title) {
          console.log("heer");
          item.amount += 1;
          alreadyExits = true;
        }
      });

      if (alreadyExits === false) {
        product.amount = 1;
        products.push(product);
      }
      localStorage.setItem(`${user.name}-cart`, JSON.stringify(products));
    }
    return { ...state, amount: state.amount + 1 };
  }
  return state;
};

export default Reducer;
