const Reducer = (state, action) => {
  if (action.type === "CLEAR_CART") {
    console.log(action.payload.name);
    localStorage.setItem(`${action.payload.name}-cart`, JSON.stringify([]));

    return { ...state, cart: [] };
  }
  if (action.type === "REMOVE") {
    return {
      ...state,
      cart: state.cart.filter((item) => item.id !== action.payload),
    };
  }
  if (action.type === "INCREASE") {
    let tempCart = state.cart.map((cartItem) => {
      if (cartItem.id === action.payload) {
        return { ...cartItem, amount: cartItem.amount + 1 };
      }
      return { ...cartItem };
    });
    return { ...state, cart: tempCart };
  }

  if (action.type === "DECREASE") {
    let tempCart = state.cart
      .map((cartItem) => {
        if (cartItem.id === action.payload) {
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
