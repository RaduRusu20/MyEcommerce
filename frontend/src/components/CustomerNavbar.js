import React, { useContext, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import { Link, Navigate } from "react-router-dom";
import NavbarStyle from "../style/NavbarStyle.module.css";
import { UserContext } from "../Contexts/UserContext";
import LogoutIcon from "@mui/icons-material/Logout";
import LoginIcon from "@mui/icons-material/Login";
import Badge from "@material-ui/core/Badge";
import IconButton from "@material-ui/core/IconButton";
import ShoppingCartIcon from "@material-ui/icons/ShoppingCart";
import { createTheme } from "@mui/material/styles";
import { ThemeProvider } from "@material-ui/core/styles";
import { useGlobalContext } from "../Cart/context";

const myTheme = createTheme({
  palette: {
    primary: {
      main: "#ffffff",
    },
  },
});

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  menuButton: {
    marginRight: theme.spacing(2),
  },
  title: {
    flexGrow: 1,
  },
  fixed: {
    position: "-webkit-sticky",
  },
}));

export default function NavBar() {
  const classes = useStyles();
  const { amount } = useGlobalContext();
  const { user, logout } = useContext(UserContext);
  const [redirect, setRedirect] = useState(false);

  return (
    <div className={classes.root}>
      <AppBar position="static">
        <Toolbar
          style={{
            display: "flex",
            flexDirection: "row",
            justifyContent: "space-between",
          }}
        >
          {redirect !== true ? null : <Navigate to={"/"} />}
          <div
            style={{
              display: "flex",
              flexDirection: "row",
              justifyContent: "flex-start",
            }}
          >
            {user.auth && (
              <h4 className={NavbarStyle.userMessage}>Hello, {user.name}</h4>
            )}

            <Link to="/" className={NavbarStyle.btn}>
              Home
            </Link>
            <Link to="/products" className={NavbarStyle.btn}>
              Products
            </Link>
            <Link to="/categories" className={NavbarStyle.btn}>
              Categories
            </Link>
          </div>
          <div
            style={{
              display: "flex",
              flexDirection: "row",
              justifyContent: "space-around",
              alignItems: "center",
            }}
          >
            {!user.auth && (
              <p>
                <Link
                  to={"/SignUp"}
                  style={{
                    color: "white",
                    textDecoration: "none",
                    paddingLeft: "1rem",
                  }}
                >
                  Sign Up
                </Link>
              </p>
            )}

            {!user.auth && (
              <Link
                to={"/SignIn"}
                style={{
                  color: "white",
                  textDecoration: "none",
                  paddingLeft: "1rem",
                }}
              >
                <LoginIcon />
              </Link>
            )}

            {user.auth && (
              <LogoutIcon
                style={{ paddingLeft: "1rem" }}
                onClick={() => {
                  logout();
                  setRedirect(true);
                }}
              />
            )}

            {user.auth && (
              <Link to={"/shoppingCart"}>
                <IconButton aria-label="cart">
                  <Badge badgeContent={amount} color="secondary">
                    <ThemeProvider theme={myTheme}>
                      <ShoppingCartIcon color="primary" />
                    </ThemeProvider>
                  </Badge>
                </IconButton>
              </Link>
            )}
          </div>
        </Toolbar>
      </AppBar>
    </div>
  );
}
